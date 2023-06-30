using UnityEngine;
using UnityEngine.Events;
using TMPro;
using MAXHelper;
public class UpgradeManger : MonoBehaviour
{
    public static UpgradeManger Instance { get; private set; }
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private MobStats archerstats;
    [SerializeField] private GameObject archer;
    [SerializeField] private PanelsDeluxe panelsDeluxe;
    [SerializeField] private Granate grenade;
    [SerializeField] private RayFroze rayFroze;
    [SerializeField] private BurnCanistr burnCanistr;
    [SerializeField] private MagicField magicField;
    [SerializeField] private RotatingAxes rotatingAxes;
    [SerializeField] private Shoker shoker;
    [SerializeField] private Drone[] drones;
    [SerializeField] private SLowerMan[] spiders;
    [SerializeField] private BasePanel[] activeAbility;
    [SerializeField] private BasePanel[] passiveAbilty;
    [SerializeField] private int maxCountForDecka;
    [SerializeField] private int maxCountActiveDecka;
    [SerializeField] private DeckaController deckaControllerActive, v2Active;
    [SerializeField] private DeckaController deckaControllerPassive, v2Pasive;
    [SerializeField] private GameObject _chestPanel;
    [SerializeField] private PanelsDeluxe panelsDeluxeChest;
    private int maxLevel = 5;
    public UnityEvent onShotGunEvent;
    public UnityEvent onMkGunEvent;
    private bool isArcher, isSpider,isDrone;
    private int droneIndex;
    private int spiderIndex;
    public int currentDeckaCount;
    public int currentActiveDeckaCout;

    private void Awake()
    {
        Instance = this;
        EventManager.onAddSpider += AddSpider;
        EventManager.onCardsPress += OpenPanel;
        isArcher = PlayerPrefsExtra.GetBool("Archer", isArcher);
        isSpider = PlayerPrefsExtra.GetBool("Spider", isSpider);
        isDrone = PlayerPrefsExtra.GetBool("isDrone", isDrone);
        droneIndex = PlayerPrefs.GetInt("DroneIndex", droneIndex);
        spiderIndex = PlayerPrefs.GetInt("SpiderIndex", spiderIndex);
        currentDeckaCount = PlayerPrefs.GetInt("currentDecka", currentDeckaCount);
        currentActiveDeckaCout = PlayerPrefs.GetInt("currentActiveDecka", currentActiveDeckaCout);
        //  OpenPanel();
        _mainPanel.SetActive(true);

        _mainPanel.SetActive(false);
    }

    private void Start()
    {
        if (isArcher)
            archer.gameObject.SetActive(true);
        if (isSpider)
        {
            for (int i = 0; i < spiderIndex; i++)
            {
                spiders[i].gameObject.SetActive(true);
            }
        }
        if (isDrone)
        {
            for (int i = 0; i < droneIndex; i++)
            {
                drones[i].gameObject.SetActive(true);
            }
        }
    }
    
    public void ClosePanels() 
    {
      
        if(currentActiveDeckaCout >= maxCountActiveDecka)
        {
           
            panelsDeluxe.SetActiveDecka();
        }
        if(currentDeckaCount >= maxCountForDecka)
        {
            panelsDeluxe.SetPassiveDecka();
        }
        panelsDeluxe.SaveTest();
        EventManager.InvokeResetZone();
        EventManager.InvokeUnlockMove();
        EventManager.InvokeTutorail();
        SpawnManager.Instance.OffTutors();
        //  _mainPanel.gameObject.SetActive(false);
        UIManager.Instance.CloseUpgradePanek();
        if(LevelManager.Instance.VisualCurrentLevel >=5)
        {

            ADSManagerSDK.Instance.ShowMyInter("ShowAfterUpgrade");           


        }

     
    
    }

    

    public void CloseChestPanel()
    {
        if (currentActiveDeckaCout >= maxCountActiveDecka)
        {

            panelsDeluxe.SetActiveDecka();
        }
        if (currentDeckaCount >= maxCountForDecka)
        {
            panelsDeluxe.SetPassiveDecka();
        }
        panelsDeluxe.SaveTest();
        EventManager.InvokeUnlockMove();
        _chestPanel.SetActive(false);
        AdsManager.Instance.OnAdAvailable -= ADSManagerSDK.Instance.AdsOpenedChest;
        Chest.Instance.Spawn();
    }



    public void AddSpider()
    {
        if (spiderIndex < 3)
        {
            isSpider = true;
            spiders[spiderIndex].gameObject.SetActive(true);
            spiderIndex++;
            PlayerPrefs.SetInt("SpiderIndex", spiderIndex);
            PlayerPrefsExtra.SetBool("Spider", isSpider);
        }
     
    }

    public void AddDrone()
    {
        if(droneIndex < 3)
        {
            isDrone = true;
            drones[droneIndex].gameObject.SetActive(true);
            droneIndex++;
            PlayerPrefs.SetInt("DroneIndex", droneIndex);
            PlayerPrefsExtra.SetBool("isDrone", isDrone);
        }
        //ClosePanels();
    }

    private void AddActiveDecka(BasePanel basePanel)
    {
        Debug.Log(currentActiveDeckaCout);
        v2Active.SetImage(basePanel, currentActiveDeckaCout);
        deckaControllerActive.SetImage(basePanel, currentActiveDeckaCout);
        currentActiveDeckaCout++;
     //   activeDeckText.text =  currentActiveDeckaCout + "/" + maxCountActiveDecka; 
        PlayerPrefs.SetInt("currentActiveDecka", currentActiveDeckaCout);
    }

    private void AddPassiveDecka(BasePanel basePanel)
    {
        v2Pasive.SetImage(basePanel, currentDeckaCount);
        deckaControllerPassive.SetImage(basePanel, currentDeckaCount);
        currentDeckaCount++;
        // passiveDeckText.text = currentDeckaCount + "/" + maxCountForDecka;
        PlayerPrefs.SetInt("currentDecka", currentDeckaCount);
    }

    public void ReduceCoolDown(BasePanel basePanel)
    {
        if (UnitLevelManager.Instance.GetReduceCoolDownLevel() >= maxLevel)
            basePanel.DoNotShow();
        if (!basePanel.isSetDekca())
        {
            basePanel.SetToDeccka();
            AddPassiveDecka(basePanel);
        }
        UnitLevelManager.Instance.ReduceAllCoolDownUpgrade();
        if(!basePanel.isChest)
        ClosePanels();
    }

    public void AllRadiusUP(BasePanel basePanel)
    {
        if (UnitLevelManager.Instance.GetRadiusLevel() >= maxLevel)
            basePanel.DoNotShow();
        if (!basePanel.isSetDekca())
        {
            basePanel.SetToDeccka();
            AddPassiveDecka(basePanel);
        }
        UnitLevelManager.Instance.AllRadiusUpgrade();
        if (!basePanel.isChest)
            ClosePanels();
    }

    public void DroneUP(BasePanel basePanel)
    {

        if(UnitLevelManager.Instance.GetDroneLevel() >= maxLevel)
        {
            basePanel.DoNotShow();
        }
        if (!basePanel.isSetDekca())
        {
            basePanel.SetToDeccka();
            AddActiveDecka(basePanel);
        }
        UnitLevelManager.Instance.DroneUpgrade();
        if (!basePanel.isChest)
            ClosePanels();
    }

    public void ShokerUp(BasePanel basePanel)
    {
        if (UnitLevelManager.Instance.GetShokerLevel() >= maxLevel)
            basePanel.DoNotShow();
        if (!basePanel.isSetDekca())
        {
            basePanel.SetToDeccka();
            AddActiveDecka(basePanel);
        }
        UnitLevelManager.Instance.ShockerUpgrade();
        if (!basePanel.isChest)
            ClosePanels();
    }

    public void AxesUp(BasePanel basePanel)
    {
        if (UnitLevelManager.Instance.GetSawLevel() >= maxLevel)
            basePanel.DoNotShow();
        if (!basePanel.isSetDekca())
        {
            basePanel.SetToDeccka();
            AddActiveDecka(basePanel);
        }
        UnitLevelManager.Instance.SawUpgrade();
        if (!basePanel.isChest)
            ClosePanels();
    }

    public void MagicFieldUp(BasePanel basePanel)
    {
        if (UnitLevelManager.Instance.GetMagicFieldLevel() >= maxLevel)
            basePanel.DoNotShow();
        if (!basePanel.isSetDekca())
        {
            basePanel.SetToDeccka();
            AddActiveDecka(basePanel);
        }
        UnitLevelManager.Instance.MagicFieldUpgrade();
        if (!basePanel.isChest)
            ClosePanels();
    }

    public void CanistrUp(BasePanel basePanel)
    {
        if (UnitLevelManager.Instance.GetCanistrLevel() >= maxLevel)
            basePanel.DoNotShow();
        if (!basePanel.isSetDekca())
        {
            basePanel.SetToDeccka();
            AddActiveDecka(basePanel);
        }
        UnitLevelManager.Instance.CanistrUpgrade();
        if (!basePanel.isChest)
            ClosePanels();
    }

    public void CritDamage(BasePanel basePanel)
    {
        if (UnitLevelManager.Instance.GetCritDamageLevel() >= maxLevel)
            basePanel.DoNotShow();
        if (!basePanel.isSetDekca())
        {
            basePanel.SetToDeccka();
            AddPassiveDecka(basePanel);
        }
        UnitLevelManager.Instance.CritDamageUpgrade();
        if (!basePanel.isChest)
            ClosePanels();
    }

    public void IncreaseMaxHealth(BasePanel basePanel)
    {
        if (UnitLevelManager.Instance.GetMaxHealthLevel() >= maxLevel)
            basePanel.DoNotShow();
        if (!basePanel.isSetDekca())
        {
            basePanel.SetToDeccka();
            AddPassiveDecka(basePanel);
        }
        UnitLevelManager.Instance.MaxHealthUpgrade();
        if (!basePanel.isChest)
            ClosePanels();
    }

    public void IncreaseRegenCd(BasePanel basePanel)
    {
        if (UnitLevelManager.Instance.GetRegenLevel() >= maxLevel)
            basePanel.DoNotShow();
        if (!basePanel.isSetDekca())
        {
            basePanel.SetToDeccka();
            AddPassiveDecka(basePanel);
        }
        UnitLevelManager.Instance.RegenUpgrade();
        if (!basePanel.isChest)
            ClosePanels();
    }

    public void WeaponUp(BasePanel basePanel)
    {

        if (UnitLevelManager.Instance.GetWeaponLevel() >= 1)
            basePanel.DoNotShow();
        if (!basePanel.isSetDekca())
        {
            basePanel.SetToDeccka();
            AddActiveDecka(basePanel);

        }
        UnitLevelManager.Instance.WeaponUp();
        if (!basePanel.isChest)
            ClosePanels();
    }

    public void MkGun(BasePanel basePanel)
    {
        AddActiveDecka(basePanel);
        basePanel.SetToDeccka();
      //  basePanel.DoNotShow();
        onMkGunEvent?.Invoke();
        if (!basePanel.isChest)
            ClosePanels();
    }

    public void ShotGun(BasePanel basePanel)
    {
        AddActiveDecka(basePanel);
       /// basePanel.SetToDeccka();
        basePanel.DoNotShow();
        onShotGunEvent?.Invoke();
        if (!basePanel.isChest)
            ClosePanels();
    }

    public void Armor(BasePanel basePanel)
    {

        if (UnitLevelManager.Instance.GetResistanceLevel() >= maxLevel)
            basePanel.DoNotShow();
        if (!basePanel.isSetDekca())
        {
            basePanel.SetToDeccka();
            AddPassiveDecka(basePanel);
        }
        UnitLevelManager.Instance.ResistanceUpgrade();
        if (!basePanel.isChest)
            ClosePanels();
    }

    public void SpeedUp(BasePanel basePanel)
    {
        if (UnitLevelManager.Instance.GetSpeedLevel() >= maxLevel)
            basePanel.DoNotShow();
        if (!basePanel.isSetDekca())
        {
            basePanel.SetToDeccka();
            AddPassiveDecka(basePanel);
        }
        UnitLevelManager.Instance.SpeedUpgrade();
        if (!basePanel.isChest)
            ClosePanels();
    }

    public void GranateUp(BasePanel basePanel)
    {
        if (UnitLevelManager.Instance.GetGrenadeLevel() >= maxLevel)
            basePanel.DoNotShow();
        if (!basePanel.isSetDekca())
        {
            basePanel.SetToDeccka();
            AddActiveDecka(basePanel);
        }
        UnitLevelManager.Instance.GrenadeUpgrade();
        if (!basePanel.isChest)
            ClosePanels();
    }

    public void SpiderUp(BasePanel basePanel)
    {
        if (UnitLevelManager.Instance.GetSpiderLevel() >= maxLevel)
            basePanel.DoNotShow();
        if (!basePanel.isSetDekca())
        {
            basePanel.SetToDeccka();
            AddActiveDecka(basePanel);
        }
        isSpider = true;
        PlayerPrefsExtra.SetBool("Spider", isSpider);
        UnitLevelManager.Instance.SpiderUpgrade();
        if (!basePanel.isChest)
            ClosePanels();
    }


    public void RayFrozeUp(BasePanel basePanel)
    {
        if (UnitLevelManager.Instance.GetRayFrozeLevel() >= maxLevel)
            basePanel.DoNotShow();
        if (!basePanel.isSetDekca())
        {
            basePanel.SetToDeccka();
            AddActiveDecka(basePanel);
        }
        UnitLevelManager.Instance.RayFrozeUpgrade();
        if (!basePanel.isChest)
            ClosePanels();
    }

    public void SniperUp(BasePanel basePanel)
    {
        if (UnitLevelManager.Instance.GetSniperLevel() >= maxLevel)
            basePanel.DoNotShow();
        if (!basePanel.isSetDekca())
        {
            basePanel.SetToDeccka();
            AddActiveDecka(basePanel);
        }
        UnitLevelManager.Instance.SniperUpgrade();

        if (!basePanel.isChest)
            ClosePanels();
    }

    public void ArcherDamage(int value)
    {
        archerstats.AddDamage(value);
        PlayerPrefs.SetInt("ArcherDamage", archerstats.GetDamage());
       // ClosePanels();
    }

    public void ArcherFireRate(float value)
    {
        archerstats.ReduceCD(value);
        PlayerPrefs.SetFloat("ArcherCD", archerstats.GetCD());
     //   ClosePanels();
    }

    public void ArcherRadius(int value)
    {
        archer.GetComponent<Archer>().UpgradeRadius(value); 
    //    ClosePanels();
    }

    public void FireRate(BasePanel basePanel)
    {
        if (UnitLevelManager.Instance.GetFireRateLevel() >= maxLevel)
            basePanel.DoNotShow();
        if (!basePanel.isSetDekca())
        {
            basePanel.SetToDeccka();
            AddPassiveDecka(basePanel);
        }
        UnitLevelManager.Instance.FiraRateUpgrade();
        if (!basePanel.isChest)
            ClosePanels();
    }

    public void DamageUpgrade(BasePanel basePanel)
    {
        if (UnitLevelManager.Instance.GetDamageLevel() >= maxLevel)
            basePanel.DoNotShow();
        if (!basePanel.isSetDekca())
        {
            basePanel.SetToDeccka();
            AddPassiveDecka(basePanel);
        }
        UnitLevelManager.Instance.DamageUpgrade();
        if (!basePanel.isChest)
            ClosePanels();
    }


    public void Magnit(BasePanel basePanel)
    {
        if (UnitLevelManager.Instance.GetMagnetLevel() >= maxLevel)
            basePanel.DoNotShow();
        if (!basePanel.isSetDekca())
        {
            basePanel.SetToDeccka();
            AddPassiveDecka(basePanel);
        }
        UnitLevelManager.Instance.MagnetUP();
        if (!basePanel.isChest)
            ClosePanels();
    }


    public void SetSniper()
    {
        archer.SetActive(true);
        PlayerPrefsExtra.SetBool("Archer", true);
    }

    public void OpenPanel()
    {
        Time.timeScale = 0f;
      //  UIManager.Instance.OpenUpgradePanel();
         _mainPanel.gameObject.SetActive(true);
  //      GetComponent<Tutor>().OffTutor();
        panelsDeluxe.SelectUpgrade();
    }

    public void OpenChestPanel()
    {
        if(currentActiveDeckaCout > 0 || currentDeckaCount > 0)
        {
            ADSManagerSDK.Instance.AvailableChestADS();
            Time.timeScale = 0f;
            _chestPanel.SetActive(true);
            panelsDeluxeChest.SelectChest();
        }
     

    }

    private void OnDestroy()
    {
        EventManager.onCardsPress -= OpenPanel;
        EventManager.onAddSpider -= AddSpider;
    }
}
