using UnityEngine;

public class UnitLevelManager : MonoBehaviour
{
    public static UnitLevelManager Instance { get; private set; }
    [SerializeField] private SLowerMan[] spiders;
    [SerializeField] private Drone[] drones;
    [Header("Abilities")]
    [SerializeField] private BurnCanistr burnCanistr;
    [SerializeField] private MagicField magicField;
    [SerializeField] private Granate grenade;
    [SerializeField] private RayFroze rayFroze;
    [SerializeField] private Shoker shoker;
    [SerializeField] private DroneBullets droneBullets;
    [SerializeField] private RotatingAxes rotatingAxes;
    [SerializeField] private Archer sniper;
    [Header("Weapons")]
    [SerializeField] private PistolBullets pistol;
    [SerializeField] private RifleBullets rifle;
    [SerializeField] private MKBulelts mK;
    [SerializeField] private GlobalAbilitiesUP reduceCoolDown;
    private int currentGrenadeLevel;
    private int currentSpiderLevel;
    private int currentCanistLevel;
    private int currentMagicFieldLevel;
    private int currentRayFrozeLevel;
    private int currentShokerLevel;
    private int currnetDroneLevel;
    private int currentSawLevel;
    private int currentMaxHealthLevel;
    private int currentRegenLevel;
    private int currentResistanceLevel;
    private int currentSpeedLevel;
    private int currentSniperLevel;
    private int currentDamageLevel;
    private int currentFireRateLevel;
    private int currentCritDamageLevel;
    private int currentMagnetLevel;
    private int currentReduceCoolDownLevel;
    private int currentAllRadiusLevel;
    private int currentWeaponLevel;
    private void Awake()
    {
        Instance = this;
        currentCritDamageLevel = PlayerPrefs.GetInt("currentCritDamageLevel",currentCritDamageLevel);
        currentGrenadeLevel = PlayerPrefs.GetInt("currentGrenadeLevel", currentGrenadeLevel); 
        currentSpiderLevel = PlayerPrefs.GetInt("currentSpiderLevel", currentSpiderLevel);
        currentCanistLevel = PlayerPrefs.GetInt("currentCanistrLevel", currentCanistLevel);
        currentMagicFieldLevel = PlayerPrefs.GetInt("currentMagicFieldLevel", currentMagicFieldLevel);
        currentRayFrozeLevel = PlayerPrefs.GetInt("currentRayFrozeLevel", currentRayFrozeLevel);
        currentShokerLevel = PlayerPrefs.GetInt("currentShokerLevel", currentShokerLevel);
        currnetDroneLevel = PlayerPrefs.GetInt("currentDroneLevel", currnetDroneLevel);
        currentSawLevel = PlayerPrefs.GetInt("currentSawLevel", currentSawLevel);
        currentMaxHealthLevel = PlayerPrefs.GetInt("currentMaxHealthLevel", currentMaxHealthLevel);
        currentRegenLevel = PlayerPrefs.GetInt("currentRegenLevel", currentRegenLevel);
        currentResistanceLevel = PlayerPrefs.GetInt("currentResistanceLevel", currentResistanceLevel);
        currentSpeedLevel = PlayerPrefs.GetInt("currentSpeedLevel", currentSpeedLevel);
        currentSniperLevel = PlayerPrefs.GetInt("currentSniperLevel", currentSniperLevel);
        currentDamageLevel = PlayerPrefs.GetInt("currentDamageLevel", currentDamageLevel);
        currentFireRateLevel = PlayerPrefs.GetInt("currentFireRateLevel", currentFireRateLevel);
        currentMagnetLevel = PlayerPrefs.GetInt("currentMagnetLevel", currentMagnetLevel);
        currentReduceCoolDownLevel = PlayerPrefs.GetInt("currentReduceCoolDownLevel", currentReduceCoolDownLevel);
        currentAllRadiusLevel = PlayerPrefs.GetInt("currentAllRadiusLevel", currentAllRadiusLevel);
        currentWeaponLevel = PlayerPrefs.GetInt("currentWeaponLevel", currentWeaponLevel);
    }

    public void WeaponUp()
    {
        switch (currentWeaponLevel)
        {
            case 0:
                Player.Instance.GetComponent<Weapon>().SetMkBullets();
                break;
            case 1:
                Player.Instance.GetComponent<Weapon>().SetRifle();

                break;
            default:

                break;
        }
        currentWeaponLevel++;
        PlayerPrefs.SetInt("currentWeaponLevel", currentWeaponLevel);
    }

    public void AllRadiusUpgrade()
    {
        switch (currentAllRadiusLevel)
        {
            case 0:
                reduceCoolDown.RadiusUpByPercent(10f);
                break;
            case 1:
                reduceCoolDown.RadiusUpByPercent(5f);

                break;

            case 2:
                reduceCoolDown.RadiusUpByPercent(5f);

                break;
            case 3:
                reduceCoolDown.RadiusUpByPercent(10f);
                break;
            case 4:
                reduceCoolDown.RadiusUpByPercent(10f);
                break;
            case 5:
                reduceCoolDown.RadiusUpByPercent(15f);

                break;
            default:

                break;
        }
        currentAllRadiusLevel++;
        PlayerPrefs.SetInt("currentAllRadiusLevel", currentAllRadiusLevel);
    }

    public void ReduceAllCoolDownUpgrade()
    {
        switch (currentReduceCoolDownLevel)
        {
            case 0:
                reduceCoolDown.ReduceAllAbilyty(10f);
                break;
            case 1:
                reduceCoolDown.ReduceAllAbilyty(5f);

                break;

            case 2:
                reduceCoolDown.ReduceAllAbilyty(5f);

                break;
            case 3:
                reduceCoolDown.ReduceAllAbilyty(10f);
                break;
            case 4:
                reduceCoolDown.ReduceAllAbilyty(10f);
                break;
            case 5:
                reduceCoolDown.ReduceAllAbilyty(15f);

                break;
            default:

                break;
        }
        currentReduceCoolDownLevel++;
        PlayerPrefs.SetInt("currentReduceCoolDownLevel", currentReduceCoolDownLevel);
    }    

    public void CanistrUpgrade()
    {
      
        switch (currentCanistLevel)
        {
            case 0:
                burnCanistr.UnlockBullet();
                break;
            case 1:
                burnCanistr.IncreaseCountCanistr();
                burnCanistr.AddDamage(80);
                break;

            case 2:
                burnCanistr.IncreaseCountCanistr();
                burnCanistr.IncreaseRadius(2);

                break;
            case 3:
                burnCanistr.IncreaseCountCanistr();
                burnCanistr.AddDamage(80);
                break;
            case 4:
                burnCanistr.IncreaseCountCanistr();
                burnCanistr.ReduceThrowCD(0.5f);
                //burnCanistr.IncreaseRadius(2);
                break;
            case 5:
                burnCanistr.IncreaseCountCanistr();
                // burnCanistr.ReduceThrowCD(3f);
                burnCanistr.AddDamage(80);
                
                break;
            default:
             
                break;
        }
        currentCanistLevel++;
        PlayerPrefs.SetInt("currentCanistrLevel", currentCanistLevel);


    }

    public void SpiderUpgrade()
    {

      
        switch (currentSpiderLevel)
        {
            case 0:
                UpgradeManger.Instance.AddSpider();
                break;
            case 1:
                foreach (var item in spiders)
                {
                    item.IncreaseReduceSpeed(3);
                    item.SetDamageExplose(100);
                }
                break;

            case 2:
                foreach (var item in spiders)
                {
                    item.IncreaseTimeDuration(2);
                }

                break;
            case 3:
                EventManager.InvokeAddSpiderEvent();
                break;
            case 4:
                foreach (var item in spiders)
                {
                    item.ReduceTimeToRespawn(1.5f);
                    item.SetDamageExplose(300);
                }
                break;
            case 5:
                EventManager.InvokeAddSpiderEvent();
                break; 
            default:
          
                break;
        }
        currentSpiderLevel++;
        PlayerPrefs.SetInt("currentSpiderLevel", currentSpiderLevel);


    }

    public void MagicFieldUpgrade()
    {

        switch (currentMagicFieldLevel)
        {
            case 0:
                magicField.UnlockBullet();
                break;
            case 1:
                magicField.IncreaseRadius(2);
               // magicField.AddDamage(40);
             /*
              если я все же зафикшу беск заморозку , то каждый лвл ап поля + урон
              */  // magicField.AddDamage(40);
                break;

            case 2:
                magicField.AddDamage(50);

                break;
            case 3:
                magicField.IncreaseRadius(2);
            //    magicField.AddDamage(60);
                break;
            case 4:
                magicField.AddDamage(50);
                break;
            case 5:
                magicField.IncreaseRadius(2);
             ///   magicField.AddDamage(50);
                break;
            default:
               
                break;
        }
        currentMagicFieldLevel++;
        PlayerPrefs.SetInt("currentMagicFieldLevel", currentMagicFieldLevel);
    }

    public void GrenadeUpgrade()
    {
       
        switch (currentGrenadeLevel)
        {
            case 0:
                grenade.UnlockBullet();
                break;
            case 1:
                grenade.AddDamage(200);
                break;

            case 2:
               // grenade.AddDamage(50);
                grenade.InreaseRadius(5);

                break;
            case 3:
                grenade.AddSpeed(20);
                grenade.AddDamage(300);

                break;
            case 4:
                grenade.AddDamage(400);
                break;
            case 5:
                grenade.InreaseRadius(5);
                break;
            default:
            
                break;
        }
        currentGrenadeLevel++;
        PlayerPrefs.SetInt("currentGrenadeLevel", currentGrenadeLevel);
    }

    public void RayFrozeUpgrade()
    {
        switch (currentRayFrozeLevel)
        {
            case 0:
                rayFroze.UnlockBullet();
                break;
            case 1:
                  rayFroze.ReduceThrowCD(0.5f);
                // rayFroze.IncreaseFrostTime(1f);
            //    rayFroze.AddDamage(40);
                break;

            case 2:
                rayFroze.IncreaseFrostTime(1f);
               // rayFroze.AddDamage(40);

                break;
            case 3:
               // rayFroze.IncreaseFrostTime(1f);
                rayFroze.AddDamage(100);
                break;
            case 4:
             //   rayFroze.IncreaseFrostTime(1f);
                rayFroze.AddDamage(120);
                break;
            case 5:
                rayFroze.ReduceThrowCD(0.5f);
                break;
            default:
              
                break;
        }
        currentRayFrozeLevel++;
        PlayerPrefs.SetInt("currentRayFrozeLevel", currentRayFrozeLevel);
    }

    public void ShockerUpgrade()
    {
       
        switch (currentShokerLevel)
        {
            case 0:
                shoker.UnlockBullet();
                break;
            case 1:
                shoker.IncreaseMaxRd();
                shoker.AddDamage(60);
                break;

            case 2:
                shoker.IncreaseMaxRd();
                shoker.AddDamage(100);

                break;
            case 3:
                shoker.IncreaseMaxRd();
                shoker.ReduceThrowCD(1f);
                break;
            case 4:
                shoker.IncreaseMaxRd();
                shoker.AddDamage(70);
                break;
            case 5:
                shoker.AddDamage(50);
                break;
            default:
             
                break;
        }
        currentShokerLevel++;
        PlayerPrefs.SetInt("currentShokerLevel", currentShokerLevel);
    }

    public void DroneUpgrade()
    {
       
        switch (currnetDroneLevel)
        {
            case 0:
                UpgradeManger.Instance.AddDrone();
                break;
            case 1:
                UpgradeManger.Instance.AddDrone();
                break;

            case 2:
                //foreach (var item in drones)
                //{
                //    без ФОРИЧА КАЧАЙ ДРОН БУЛЕТС
                //    item.IncreaseDamage(5);
                //}
                droneBullets.AddDamage(15);

                break;
            case 3:
                foreach (var item in drones)
                {
                    droneBullets.AddDamage(15);
                }
             //   droneBullets.AddDamage(20);
                break;
            case 4:
                UpgradeManger.Instance.AddDrone();
             //   droneBullets.AddDamage(40);
                break;
            case 5:
                droneBullets.IncreaseMaxCountInQueue(2);
                break;
            default:
              
                break;
        }
        currnetDroneLevel++;
        PlayerPrefs.SetInt("currentDroneLevel", currnetDroneLevel);
    }

    public void SawUpgrade()
    {
    
        //dmg
        switch (currentSawLevel)
        {
            case 0:
                rotatingAxes.UnlockBullet();
                break;
            case 1:
                rotatingAxes.AddCount();
                rotatingAxes.AddDamage(10);
                rotatingAxes.ReduceThrowCD(0.25f);
                rotatingAxes.AddTimeToLive(0.25f);
                break;

            case 2:
               // rotatingAxes.AddTimeToLive(0.5f);
                rotatingAxes.AddCount();
                rotatingAxes.AddDamage(10);
                rotatingAxes.ReduceThrowCD(0.25f);
                break;
            case 3:
                rotatingAxes.AddDamage(10);
                rotatingAxes.AddCount();
                rotatingAxes.AddTimeToLive(0.25f);
                rotatingAxes.ReduceThrowCD(0.25f);
                break;
            case 4:
                rotatingAxes.AddDamage(10);
                rotatingAxes.AddCount();
              //  rotatingAxes.AddTimeToLive(0.5f);
                rotatingAxes.ReduceThrowCD(0.25f);
                break;
            case 5:
                rotatingAxes.AddDamage(15);
                rotatingAxes.AddCount();
                rotatingAxes.ReduceThrowCD(0.5f);
             //   rotatingAxes.SetForever();
                break;
            default:
             
                break;
        }
        currentSawLevel++;
        PlayerPrefs.SetInt("currentSawLevel", currentSawLevel);
    }

    public void MaxHealthUpgrade()
    {
       
        switch (currentMaxHealthLevel)
        {
            case 0:
                Player.Instance.IncreaseHealth(100);
                break;
            case 1:
                Player.Instance.IncreaseHealth(25);
                break;

            case 2:
                Player.Instance.IncreaseHealth(50);
                break;
            case 3:
                Player.Instance.IncreaseHealth(75);
                break;
            case 4:
                Player.Instance.IncreaseHealth(50);
                break;
            case 5:
                Player.Instance.IncreaseHealth(100);
                break;
            default:
          
                break;
        }
        currentMaxHealthLevel++;
        PlayerPrefs.SetInt("currentMaxHealthLevel", currentMaxHealthLevel);
    }

    public void RegenUpgrade()
    {
        switch (currentRegenLevel)
        {
            case 0:
                Player.Instance.SetCanRegen();
                break;
            case 1:
                Player.Instance.UpRegenValue(1);
                break;

            case 2:
                Player.Instance.UpRegenValue(1);
                break;
            case 3:
                Player.Instance.UpRegenValue(1);
                break;
            case 4:
                Player.Instance.UpRegenValue(1);
                break;
            case 5:
                Player.Instance.UpRegenValue(1);
                break;
            default:
            
                break;
        }
        currentRegenLevel++;
        PlayerPrefs.SetInt("currentRegenLevel", currentRegenLevel);
    }

    public void ResistanceUpgrade()
    {
      
        switch (currentResistanceLevel)
        {
            case 0:
                Player.Instance.IncreaseResistance(3);
                break;
            case 1:
                Player.Instance.IncreaseResistance(2);
                break;

            case 2:
                Player.Instance.IncreaseResistance(3);
                break;
            case 3:
                Player.Instance.IncreaseResistance(2);
                break;
            case 4:
                Player.Instance.IncreaseResistance(3);
                break;
            case 5:
                Player.Instance.IncreaseResistance(3);
                break;
            default:
                break;
        }
        currentResistanceLevel++;
        PlayerPrefs.SetInt("currentResistanceLevel", currentResistanceLevel);
    }

    public void SpeedUpgrade()
    {
      
        switch (currentSpeedLevel)
        {
            case 0:
                Player.Instance.IncreaseSpeed(1.5f);
                break;
            case 1:
                Player.Instance.IncreaseSpeed(0.5f);
                break;

            case 2:
                Player.Instance.IncreaseSpeed(1);
                break;
            case 3:
                Player.Instance.IncreaseSpeed(0.5f);
                break;
            case 4:
                Player.Instance.IncreaseResistance(1);
                break;
            case 5:
                Player.Instance.IncreaseSpeed(0.5f);
                break;
            default:
            
                break;
        }
        currentSpeedLevel++;
        PlayerPrefs.SetInt("currentSpeedLevel", currentSpeedLevel);
    }

    public void SniperUpgrade()
    {
     
        switch (currentSniperLevel)
        {
            case 0:
                UpgradeManger.Instance.SetSniper();
                break;
            case 1:
                UpgradeManger.Instance.ArcherDamage(60);
                break;

            case 2:
                UpgradeManger.Instance.ArcherDamage(50);
                break;
            case 3:
                UpgradeManger.Instance.ArcherDamage(50);
                break;
            case 4:
                UpgradeManger.Instance.ArcherDamage(80);
                break;
            case 5:
                UpgradeManger.Instance.ArcherDamage(100);
                break;
            default:
              
                break;
        }
        currentSniperLevel++;
        PlayerPrefs.SetInt("currentSniperLevel", currentSniperLevel);
    }

    public void DamageUpgrade()
    {

    
        switch (currentDamageLevel)
        {
            case 0:
                mK.AddDamage(37);
                rifle.AddDamage(37);
                pistol.AddDamage(37);
                break;
            case 1:
                mK.AddDamage(45);
                rifle.AddDamage(45);
                pistol.AddDamage(45);
                break;

            case 2:
                mK.AddDamage(55);
                rifle.AddDamage(55);
                pistol.AddDamage(55);
                break;
            case 3:
                mK.AddDamage(60);
                rifle.AddDamage(60);
                pistol.AddDamage(60);
                break;
            case 4:
                mK.AddDamage(60);
                rifle.AddDamage(60);
                pistol.AddDamage(60);
                break;
            case 5:
                mK.AddDamage(70);
                rifle.AddDamage(70);
                pistol.AddDamage(70);
                break;
            default:

                break;
        }
        currentDamageLevel++;
        PlayerPrefs.SetInt("currentDamageLevel", currentDamageLevel);
    }

    public void FiraRateUpgrade()
    {
       
        switch (currentFireRateLevel)
        {
            case 0:
                mK.ReduceThrowCD(0.025f);
                rifle.ReduceThrowCD(0.025f);
                pistol.ReduceThrowCD(0.025f);
                break;
            case 1:
                mK.ReduceThrowCD(0.025f);
                rifle.ReduceThrowCD(0.025f);
                pistol.ReduceThrowCD(0.025f);
                break;

            case 2:
                mK.ReduceThrowCD(0.025f);
                rifle.ReduceThrowCD(0.025f);
                pistol.ReduceThrowCD(0.025f);
                break;
            case 3:
                mK.ReduceThrowCD(0.025f);
                rifle.ReduceThrowCD(0.025f);
                pistol.ReduceThrowCD(0.025f);
                break;
            case 4:
                mK.ReduceThrowCD(0.02f);
                rifle.ReduceThrowCD(0.02f);
                pistol.ReduceThrowCD(0.02f);
                break;
            case 5:
                mK.ReduceThrowCD(0.02f);
                rifle.ReduceThrowCD(0.02f);
                pistol.ReduceThrowCD(0.02f);
                break;
            default:
   
                break;
        }
        currentFireRateLevel++;
        PlayerPrefs.SetInt("currentFireRateLevel", currentFireRateLevel);
    }

    public void CritDamageUpgrade()
    {
        switch (currentCritDamageLevel)
        {
            case 0:
                mK.UnlockCritDamage();
                rifle.UnlockCritDamage();
                pistol.UnlockCritDamage();
                break;
            case 1:
                mK.IncreaseCritDamage(60);
                rifle.IncreaseCritDamage(60);
                pistol.IncreaseCritDamage(60);
                break;

            case 2:
                mK.IncreaseCritChance(10);
                rifle.IncreaseCritChance(10);
                pistol.IncreaseCritChance(10);

                break;
            case 3:
                mK.IncreaseCritDamage(60);
                rifle.IncreaseCritDamage(60);
                pistol.IncreaseCritDamage(60);
                break;
            case 4:
                mK.IncreaseCritChance(10);
                rifle.IncreaseCritChance(10);
                pistol.IncreaseCritChance(10);
                break;
            case 5:
                mK.IncreaseCritDamage(60);
                rifle.IncreaseCritDamage(60);
                pistol.IncreaseCritDamage(60);

                break;
            default:

                break;
        }
        currentCritDamageLevel++;
        PlayerPrefs.SetInt("currentCritDamageLevel", currentCritDamageLevel);

    }

    public void MagnetUP()
    {
        switch (currentMagnetLevel)
        {
            case 0:
                CoinSpawner.Instance.IncreaseDistance(10);
                
                break;
            case 1:
                CoinSpawner.Instance.IncreaseDistance(5);
                break;

            case 2:
                CoinSpawner.Instance.IncreaseDistance(5);

                break;
            case 3:
                CoinSpawner.Instance.IncreaseDistance(5);
                break;
            case 4:
                CoinSpawner.Instance.IncreaseDistance(5);
                break;
            case 5:
                CoinSpawner.Instance.IncreaseDistance(5);

                break;
            default:

                break;
        }
        currentMagnetLevel++;
        PlayerPrefs.SetInt("currentMagnetLevel", currentMagnetLevel);
    }

    public int GetWeaponLevel() { return currentWeaponLevel; }

    public int GetMagnetLevel() { return currentMagnetLevel; }

    public int GetCritDamageLevel() { return currentCritDamageLevel; }

    public int GetFireRateLevel() { return currentFireRateLevel; }

    public int GetDamageLevel() { return currentDamageLevel; }

    public int GetSniperLevel() { return currentSniperLevel; }

    public int GetSpeedLevel() { return currentSpeedLevel; }

    public int GetResistanceLevel() { return currentResistanceLevel;  }

    public int GetRegenLevel() { return currentRegenLevel; }

    public int GetMaxHealthLevel() { return currentMaxHealthLevel; }

    public int GetSawLevel() { return currentSawLevel; }

    public int GetDroneLevel() { return currnetDroneLevel; }

    public int GetShokerLevel() { return currentShokerLevel; }

    public int GetRayFrozeLevel() { return currentRayFrozeLevel; }

    public int GetGrenadeLevel() { return currentGrenadeLevel; }
    
    public int GetMagicFieldLevel() { return currentMagicFieldLevel; }
    
    public int GetSpiderLevel() { return currentSpiderLevel; }

    public int GetCanistrLevel() { return currentCanistLevel; }

    public int GetRadiusLevel() { return currentAllRadiusLevel; }
    
    public int GetReduceCoolDownLevel() { return currentReduceCoolDownLevel; }
    
} 
