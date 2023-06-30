using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using MAXHelper;
using MadPixelAnalytics;
using UnityEngine.Events;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private ParticleSystem _confettiFx;
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _endPanel;
    [SerializeField] private GameObject _beforeDiedVideoPanel;
    [SerializeField] private GameObject _x2CoinsADPanel;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private LineProgress lineProgress;
    [SerializeField] private TimerText timerText;
    [SerializeField] private Unlocking unlock;
    [SerializeField] private UpgradeManger upgrade;
    [SerializeField] private GameObject[] players;
    [SerializeField] private GameObject _weaponPanel;
    [SerializeField] private GameObject settngsPanel;
    private int playerIndex;
    private bool isFinish;
    private bool isReset;
    private bool isTutor;
    public UnityAction<AdInfo> adInfoDead;
    private AdInfo adInfo;
    private int currentLevelStart;
    private int currentloopLevel;
    private void Awake()
    {
        Instance = this;
        Application.targetFrameRate = 60;
        playerIndex = PlayerPrefs.GetInt("playerIndex", 0);
        isReset = PlayerPrefsExtra.GetBool("reset", false);
        //    players[playerIndex].SetActive(true); 
        currentloopLevel = PlayerPrefs.GetInt("loopLevel", 1);
    //   AppMetricaComp.

    }

    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        _gamePanel.SetActive(true);
        _levelText.SetText((LevelManager.Instance.VisualCurrentLevel).ToString());
        Time.timeScale = 1f;
    
        currentLevelStart = LevelManager.Instance.VisualCurrentLevel;
      //  Bank.Instance.AddCoins(10000);
    }

    private void OnApplicationQuit()
    {
        Screen.sleepTimeout = SleepTimeout.SystemSetting;
    }



    public void GameLose()
    {
        _losePanel.SetActive(true);
       // _beforeDiedVideoPanel.SetActive(false);
        _gamePanel.SetActive(false);
        Time.timeScale = 0f;
        timerText.UpdateTimer();
        Debug.Log(lineProgress.GetFillAmount() * 100f);
        Debug.Log(LevelManager.Instance.timerLevel);
        AnalyticsManager.CustomEvent("level_finish", new Dictionary<string, object> {
                {"level_number",currentLevelStart },
                {"level_name", "level " + LevelManager.Instance.VisualCurrentLevel.ToString() },
                {"level_count", LevelManager.Instance.VisualCurrentLevel },
                {"level_diff","hard" },
                {"level_loop", GameManager.Instance.GetLoopLevel() },
                {"level_random",0 },
                {"level_type","normal" },
                {"result","lose" },
                {"time", LevelManager.Instance.timerLevel },
                {"progress", Mathf.FloorToInt(lineProgress.GetFillAmount() * 100f) },
                {"continue",1 }

            }, true);
        LevelManager.Instance.timerLevel = 0f;
    }

    public void SettingsManage(bool flag) 
    {
        if (flag)
        {
            _gamePanel.SetActive(false);
            
          //  Time.timeScale = 0f;
        }

        else
        {
            _gamePanel.SetActive(true);
         
      //      lineProgress.StartIncoming();
        }

        if (flag)
        {
            Time.timeScale = 0f;
            settngsPanel.SetActive(flag);
            settngsPanel.transform.localScale = Vector3.zero;
            settngsPanel.transform.DOScale(new Vector3(1f, 1f, 1f), 0.3f)
                .SetUpdate(UpdateType.Normal, true);
        }
        else
        {
            settngsPanel.transform.localScale = new Vector3(1f,1f,1f);
            settngsPanel.transform.DOScale(Vector3.zero, 0.3f)
                 .SetUpdate(UpdateType.Normal, true);
                   // .OnComplete(SettingsPanel);
            
          
        }
    }
    
    public void SettingsOff(Button button)
    {
        _gamePanel.SetActive(true);
        settngsPanel.transform.localScale = new Vector3(1f, 1f, 1f);
        settngsPanel.transform.DOScale(Vector3.zero, 0.3f)
             .SetUpdate(UpdateType.Normal, true)
                .OnComplete(() => SettingsPanel(button));

    }

    public void SettingsTurnOn(Button button)
    {
        if(settngsPanel.activeSelf == false)
        {
            button.interactable = false;
            _gamePanel.SetActive(false);
            Time.timeScale = 0f;
            settngsPanel.SetActive(true);
            settngsPanel.transform.localScale = Vector3.zero;
            settngsPanel.transform.DOScale(new Vector3(1f, 1f, 1f), 0.3f)
                .SetUpdate(UpdateType.Normal, true)
                .OnComplete(() => button.interactable = true);
        }
     
    }

    private void SettingsPanel(Button button) { button.interactable = true; settngsPanel.SetActive(false); Time.timeScale = 1f;  }

    public void GameWin()
    {
       
        if (isFinish)
            return;
        isFinish = true;
        _gamePanel.SetActive(false);
        _winPanel.SetActive(true);
        Invoke(nameof(PlayConfetti), 0.25f);
        Invoke(nameof(NextLevel), 1.5f);
        
    }

    public void NextLevel()
    {

        LevelManager.Instance.FinishLevel();
        if (LevelManager.Instance.VisualCurrentLevel == 46)
            EndGame();
        else
        {
            AnalyticsManager.CustomEvent("level_start", new Dictionary<string, object> {
                {"level_number",currentLevelStart },
                {"level_name", "level " + LevelManager.Instance.VisualCurrentLevel.ToString() },
                {"level_count", LevelManager.Instance.VisualCurrentLevel },
                {"level_diff","hard" },
                {"level_loop", currentloopLevel },
                {"level_random",0 },
                {"level_type","normal" },
               
            },true) ;
            isFinish = false;
            _winPanel.SetActive(false);
            _gamePanel.SetActive(true);
            _levelText.SetText((LevelManager.Instance.VisualCurrentLevel).ToString());
            //lineProgress.RestartLineProgress();
            lineProgress.Incoming();
        }
        

    }

    public void EndGame()
    {
        _gamePanel.SetActive(false);
        _winPanel.SetActive(false);
        _endPanel.SetActive(true
            );
        timerText.UpdateTimer();
        ADSManagerSDK.Instance.ShowAdsAfterWin();
    }

    public void StartLevel()
    {
        _levelText.SetText((LevelManager.Instance.VisualCurrentLevel).ToString());
        //lineProgress.RestartLineProgress();
        lineProgress.Incoming();
    }

    public void RestartGame(int countCoin)
    {
        isFinish = false;
        _gamePanel.SetActive(true);
        _losePanel.SetActive(false);
        PlayerPrefs.DeleteAll();
        Bank.Instance.ClearCoins();
        Bank.Instance.AddCoins(countCoin);
        currentloopLevel++;
        PlayerPrefs.SetInt("loopLevel", currentloopLevel);
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     //   _x2CoinsADPanel.SetActive(true);
    }

    private void PlayConfetti()
    {
        _confettiFx.Play();
    }

    public int GetLoopLevel() { return currentloopLevel; }

    public GameObject GetGamePanel() { return _gamePanel; }

    public GameObject GetLosePanel() { return _losePanel; }
}