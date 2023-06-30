using System.Collections.Generic;
using UnityEngine;
using MadPixelAnalytics;
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] private SpawnManager wave;
    //[SerializeField] private List<GameObject> _levels;
    [SerializeField] private int testLevelIndex;
    public int VisualCurrentLevel { private set; get; }

    private GameObject level;
    private int startLevel;
    public float timerLevel;
    private int countContinueLevel;
    
    private void Awake()
    {
      //  DontDestroyOnLoad(this);
        Instance = this;
        VisualCurrentLevel = 0;
        VisualCurrentLevel = PlayerPrefs.GetInt("VisualCurrentLevel",1);
        startLevel = VisualCurrentLevel;
    }

    private void Update()
    {
        timerLevel += Time.deltaTime;
    }

    public void FinishLevel()
    {
        //SAVE LEVEL
      
        AnalyticsManager.CustomEvent("level_finish", new Dictionary<string, object> {
                {"level_number",startLevel },
                {"level_name", "level " + LevelManager.Instance.VisualCurrentLevel.ToString() },
                {"level_count", LevelManager.Instance.VisualCurrentLevel },
                {"level_diff","hard" },
                {"level_loop", GameManager.Instance.GetLoopLevel() },
                {"level_random",0 },
                {"level_type","normal" },
                {"result","win" },
                {"time", timerLevel },
                {"progress",100 },
                {"continue",1 }

            },true);
        VisualCurrentLevel++;
        PlayerPrefs.SetInt("VisualCurrentLevel", VisualCurrentLevel);
        timerLevel = 0f;
        wave.AddlevelWave();
    }

    public void LoadLevel()
    {
        
        

    }

    [ContextMenu("SetTestLevel")]
    public void SetTestLevel()
    {
        PlayerPrefs.SetInt("CurrentLevel", testLevelIndex);
    }
}