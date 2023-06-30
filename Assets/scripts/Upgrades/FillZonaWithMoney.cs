using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FillZonaWithMoney : MonoBehaviour
{
    [SerializeField] private Image _FilledImage;
    [SerializeField] private TextMeshProUGUI _costTexts;
    [SerializeField] private int[] cost;
    [SerializeField] private Image coinSprite;
    [SerializeField] private UpgradeType upgradeType;
    private Coroutine cor;
    private float percent;
    private float forpercent;
    private bool trig;
    private int indexCost;
    private int _speed;
    private int currentCoin;
    private int startIndexCoin;
    private float Tcost;
    private void Awake()
    {
        EventManager.onResetZona += ResetZona;

        if (upgradeType == UpgradeType.Knight)
            GetArcherSave();
        else if (upgradeType == UpgradeType.Upgrade)
            GetUpgradeSave();
    }

    private void Start()
    {
        if (indexCost == 100)
            SetMaxLevel();
        else
        {
          //  _FilledImage.fillAmount = percent;
            forpercent = cost[indexCost];
            _costTexts.text = currentCoin.ToString();
            Tcost = currentCoin;
        }
        //   Bank.Instance.AddCoins(1109000);
        startIndexCoin = cost[indexCost];

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //cost[indexCost] = currentCoin;
            cor = StartCoroutine(FillZona());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine(cor);
            SavePercent(percent);
          //  SaveCoin(currentCoin);
        }
    }

    private IEnumerator FillZona()
    {
        // currentCoin = PlayerPrefs.GetInt("UpgradeCoin",cost[0]);
     //   float Tcost = currentCoin;
        _FilledImage.fillAmount = percent;
        while (Tcost > 0)
        {
            if(Bank.Instance.CoinsCount > 0)
            {
                percent = ((forpercent - (Tcost - _speed)) / forpercent);            
                _FilledImage.fillAmount = percent;
                Bank.Instance.ReduceCoins(_speed);
                Tcost -= _speed;
                cost[indexCost] -= _speed;
            //    currentCoin = (int)Tcost;
             //   SavePercent(percent);
            //    SaveCoin(currentCoin);
                if (Tcost < 0)
                {
                    Tcost = 0;
                    cost[indexCost] = 0;
                }
               
                _costTexts.SetText(Mathf.RoundToInt(Tcost).ToString());
            }
            else
                StopCoroutine(cor);
            yield return null;
        }
        if (_FilledImage.fillAmount == 1f && !trig)
        {
            trig = true;
            if (upgradeType == UpgradeType.Upgrade)
                EventManager.LaunchUpgrade();


        }
    }

    public void SetMaxLevel()
    {
        _costTexts.enabled = false;
        coinSprite.enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        SaveIndex(100);
    }

    public void ResetZona()
    {
        if (trig)
        {
            trig = false;
            StopAllCoroutines();
            _FilledImage.fillAmount = 0f;
            percent = 0f;
            indexCost++;
            if (indexCost > 3)
                _speed++;
          //  _speed = 1;
            if (indexCost == cost.Length)
            {
                SetMaxLevel();
                return;
            }
            SaveIndex(indexCost);
            SaveSpeedFill(_speed);
            //  SavePercent(percent);
            SaveCoin(cost[indexCost]);
            startIndexCoin = cost[indexCost];
            Tcost = cost[indexCost];
            _costTexts.text = cost[indexCost].ToString();
            forpercent = cost[indexCost];

        }

    }

    private void GetUpgradeSave()
    {
        percent = PlayerPrefs.GetFloat("UpgradePercent", 0f);
        currentCoin = PlayerPrefs.GetInt("UpgradeCoin", cost[0]);
        _speed = PlayerPrefs.GetInt("UpgradeSpeedFill", 1);
        indexCost = PlayerPrefs.GetInt("UpgradeIndexCost", 0);
    }

    private void GetArcherSave()
    {
        percent = PlayerPrefs.GetFloat("ArcherPercent", 0f);
        currentCoin = PlayerPrefs.GetInt("ArcherCoin", cost[0]);
        _speed = PlayerPrefs.GetInt("ArcherSpeedFill", 1);
        indexCost = PlayerPrefs.GetInt("ArcherIndexCost", 0);
    }

    private void SaveCoin(int value)
    {
        if (upgradeType == UpgradeType.Upgrade)
        {
            PlayerPrefs.SetInt("UpgradeCoin", value);
            currentCoin = PlayerPrefs.GetInt("UpgradeCoin");
        }
        else if (upgradeType == UpgradeType.Knight)
        {
            PlayerPrefs.SetInt("ArcherCoin", value);
            currentCoin = PlayerPrefs.GetInt("ArcherCoin");
        }
    }

    private void SavePercent(float value)
    {
        if (upgradeType == UpgradeType.Upgrade)
        {
            PlayerPrefs.SetFloat("UpgradePercent", value);
        }
        else if (upgradeType == UpgradeType.Knight)
        {
            PlayerPrefs.SetFloat("ArcherPercent", value);
        }
    }

    private void SaveSpeedFill(int value)
    {
        if (upgradeType == UpgradeType.Upgrade)
        {
            PlayerPrefs.SetInt("UpgradeSpeedFill", value);
        }
        else if (upgradeType == UpgradeType.Knight)
        {
            PlayerPrefs.SetInt("ArcherSpeedFill", value);
        }
    }
    private void SaveIndex(int value)
    {
        if (upgradeType == UpgradeType.Upgrade)
        {
            PlayerPrefs.SetInt("UpgradeIndexCost", value);
        }
        else if (upgradeType == UpgradeType.Knight)
        {
            PlayerPrefs.SetInt("ArcherIndexCost", value);
        }
    }

    private void OnDestroy()
    {
        EventManager.onResetZona -= ResetZona;
    }

    public int GetPercentMoney()
    {
        float x = ((float)startIndexCoin / 100f) * 20f;
        return (int)x;

    }
}


public enum UpgradeType {Upgrade,Knight }