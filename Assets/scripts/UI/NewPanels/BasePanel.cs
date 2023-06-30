using UnityEngine;
using UnityEngine.UI;
public class BasePanel : MonoBehaviour
{
    [SerializeField] private int canShowIndex;
    [SerializeField] private TypePanel myType;
    [SerializeField] private bool isDecka;
    [SerializeField] private Image panelImage;
    [SerializeField] private Sprite ShotGunImage;
    public BasePanel ChestBasePanel, upgradeBasePanel;
    public UnityEngine.Events.UnityEvent unityAction;
    public bool isChest;
    private void Awake()
    {
        LoadPanel();
        gameObject.SetActive(false);
    }

    public void LoadPanel()
    {

        if (myType == TypePanel.sniper)
        {
            canShowIndex = PlayerPrefs.GetInt("sniperBuyUp", canShowIndex);
            isDecka = PlayerPrefsExtra.GetBool("SniperDecka", isDecka);
        }
        else if (myType == TypePanel.spider)
        {
            canShowIndex = PlayerPrefs.GetInt("spiderP", canShowIndex);
            isDecka = PlayerPrefsExtra.GetBool("SpiderDecka", isDecka);
        }
        else if (myType == TypePanel.FrezeRay)
        {
            canShowIndex = PlayerPrefs.GetInt("Ray", canShowIndex);
            isDecka = PlayerPrefsExtra.GetBool("RayDecka", isDecka);
        }
        else if (myType == TypePanel.Grenade)
        {
            canShowIndex = PlayerPrefs.GetInt("GrenadeCard", canShowIndex);
          isDecka =  PlayerPrefsExtra.GetBool("GrenadeDecka", isDecka);
        }
        else if (myType == TypePanel.CritDamage)
        {
            canShowIndex = PlayerPrefs.GetInt("ExplosiveBullets", canShowIndex);
            isDecka = PlayerPrefsExtra.GetBool("CritDamageDecka", isDecka);
        }
        else if (myType == TypePanel.Armor)
        {
            canShowIndex = PlayerPrefs.GetInt("Armor", canShowIndex);
            isDecka = PlayerPrefsExtra.GetBool("ArmorDecka", isDecka);
        }
        else if (myType == TypePanel.Speed)
        {
            canShowIndex = PlayerPrefs.GetInt("SppedCard", canShowIndex);
            isDecka = PlayerPrefsExtra.GetBool("SpeedDecka", isDecka);
        }
        else if (myType == TypePanel.ShotGun)
        {
            canShowIndex = PlayerPrefs.GetInt("ShotGun", canShowIndex);
            isDecka = PlayerPrefsExtra.GetBool("ShotGunDecka", isDecka);
        }
      
        else if (myType == TypePanel.MaxHealth)
        {
            canShowIndex = PlayerPrefs.GetInt("MaxHealthCard", canShowIndex);
            isDecka = PlayerPrefsExtra.GetBool("MaxHealthDecka", isDecka);
        }
        else if (myType == TypePanel.Regen)
        {
            canShowIndex = PlayerPrefs.GetInt("RegenCard", canShowIndex);
            isDecka = PlayerPrefsExtra.GetBool("RegenDecka", isDecka);
        }
        else if (myType == TypePanel.Petrol)
        {
            canShowIndex = PlayerPrefs.GetInt("PetrolCatd", canShowIndex);
            isDecka = PlayerPrefsExtra.GetBool("PetrolDecka", isDecka);
        }
        else if (myType == TypePanel.MagicField)
        {
            canShowIndex = PlayerPrefs.GetInt("MagicFieldCard", canShowIndex);
            isDecka = PlayerPrefsExtra.GetBool("MagicFieldDecka", isDecka);
        }
        else if (myType == TypePanel.Shoker)
        {
            canShowIndex = PlayerPrefs.GetInt("ShokerCard", canShowIndex);
            isDecka = PlayerPrefsExtra.GetBool("ShokerDecka", isDecka);
        }
        else if (myType == TypePanel.Saw)
        {
            canShowIndex = PlayerPrefs.GetInt("SawCard", canShowIndex);
            isDecka = PlayerPrefsExtra.GetBool("SawDecka", isDecka);
        }
        else if (myType == TypePanel.Damage)
        {
            canShowIndex = PlayerPrefs.GetInt("Damage", canShowIndex);
            isDecka = PlayerPrefsExtra.GetBool("DamageDecka", isDecka);
        }
        else if (myType == TypePanel.FireRate)
        {
            canShowIndex = PlayerPrefs.GetInt("FireRate", canShowIndex);
            isDecka = PlayerPrefsExtra.GetBool("FireRateDecka", isDecka);
        }
        else if (myType == TypePanel.Magnit)
        {
          canShowIndex =  PlayerPrefs.GetInt("Magnit", canShowIndex);
           isDecka = PlayerPrefsExtra.GetBool("MagnitDecka", isDecka);
        }
        else if (myType == TypePanel.ReduceCD)
        {
           canShowIndex = PlayerPrefs.GetInt("ReduceCD", canShowIndex);
          isDecka = PlayerPrefsExtra.GetBool("ReduceCDDecka", isDecka);
        }
        else if (myType == TypePanel.Radius)
        {
          canShowIndex =  PlayerPrefs.GetInt("RadiusCard", canShowIndex);
          isDecka =   PlayerPrefsExtra.GetBool("RadiusDecka", isDecka);
        }
        else if (myType == TypePanel.Drone)
        {
            canShowIndex = PlayerPrefs.GetInt("DroneCard", canShowIndex);
            isDecka = PlayerPrefsExtra.GetBool("DroneDecka", isDecka);
        }

        if (myType == TypePanel.MKGun)
        {
            canShowIndex = PlayerPrefs.GetInt("MKGun", canShowIndex);
            isDecka = PlayerPrefsExtra.GetBool("MKGunDecka", isDecka);
            if (isDecka)
                SetImage(ShotGunImage);
        }
    } 

    public void SavePanel()
    {
     
        if (myType == TypePanel.sniper)
        {
            PlayerPrefs.SetInt("sniperBuyUp", canShowIndex);
            PlayerPrefsExtra.SetBool("SniperDecka", isDecka);
        }
        else if (myType == TypePanel.spider)
        {
            PlayerPrefs.SetInt("spiderP", canShowIndex);
            PlayerPrefsExtra.SetBool("SpiderDecka", isDecka);
        }

        else if(myType == TypePanel.FrezeRay)
        {
            PlayerPrefs.SetInt("Ray", canShowIndex);
            PlayerPrefsExtra.SetBool("RayDecka", isDecka);
        }
        else if(myType == TypePanel.Grenade)
        {
            PlayerPrefs.SetInt("GrenadeCard", canShowIndex);
            PlayerPrefsExtra.SetBool("GrenadeDecka", isDecka);
        }
        else if(myType == TypePanel.CritDamage)
        {
            PlayerPrefs.SetInt("ExplosiveBullets", canShowIndex);
            PlayerPrefsExtra.SetBool("CritDamageDecka", isDecka);
        }
        else if (myType == TypePanel.Armor)
        {
            PlayerPrefs.SetInt("Armor", canShowIndex);
            PlayerPrefsExtra.SetBool("ArmorDecka", isDecka);
        }
        else if(myType == TypePanel.Speed)
        {
            PlayerPrefs.SetInt("SppedCard", canShowIndex);
            PlayerPrefsExtra.SetBool("SpeedDecka", isDecka);

        }
        else if(myType == TypePanel.ShotGun)
        {
            PlayerPrefs.SetInt("ShotGun", canShowIndex);
            PlayerPrefsExtra.SetBool("ShotGunDecka", isDecka);
        }
      
        else if(myType == TypePanel.MaxHealth)
        {
            PlayerPrefs.SetInt("MaxHealthCard", canShowIndex);
            PlayerPrefsExtra.SetBool("MaxHealthDecka", isDecka);
        }
        else if(myType == TypePanel.Regen)
        {
            PlayerPrefs.SetInt("RegenCard", canShowIndex);
            PlayerPrefsExtra.SetBool("RegenDecka", isDecka);
        }
        else if(myType == TypePanel.Petrol)
        {
            PlayerPrefs.SetInt("PetrolCatd", canShowIndex);
            PlayerPrefsExtra.SetBool("PetrolDecka", isDecka);
        }

        else if(myType == TypePanel.MagicField)
        {
            PlayerPrefs.SetInt("MagicFieldCard", canShowIndex);
            PlayerPrefsExtra.SetBool("MagicFieldDecka", isDecka);
        }
        else if(myType == TypePanel.Shoker)
        {
            PlayerPrefs.SetInt("ShokerCard", canShowIndex);
            PlayerPrefsExtra.SetBool("ShokerDecka", isDecka);
        }
 
        else if (myType == TypePanel.Saw)
        {
            PlayerPrefs.SetInt("SawCard", canShowIndex);
            PlayerPrefsExtra.SetBool("SawDecka", isDecka);
        }
        else if(myType == TypePanel.Drone)
        {
            PlayerPrefs.SetInt("DroneCard", canShowIndex);
            PlayerPrefsExtra.SetBool("DroneDecka", isDecka);
        }
        else if(myType == TypePanel.Damage)
        {
            PlayerPrefs.SetInt("Damage", canShowIndex);
            PlayerPrefsExtra.SetBool("DamageDecka", isDecka);
        }
        else if(myType == TypePanel.FireRate)
        {
            PlayerPrefs.SetInt("FireRate", canShowIndex);
            PlayerPrefsExtra.SetBool("FireRateDecka", isDecka);
        }
        else if (myType == TypePanel.Magnit)
        {
            PlayerPrefs.SetInt("Magnit", canShowIndex);
            PlayerPrefsExtra.SetBool("MagnitDecka", isDecka);
        }
        else if(myType == TypePanel.ReduceCD)
        {
            PlayerPrefs.SetInt("ReduceCD", canShowIndex);
            PlayerPrefsExtra.SetBool("ReduceCDDecka", isDecka);
        }
        else if(myType == TypePanel.Radius)
        {
            PlayerPrefs.SetInt("RadiusCard", canShowIndex);
            PlayerPrefsExtra.SetBool("RadiusDecka", isDecka);
        }

        if (myType == TypePanel.MKGun)
        {
            PlayerPrefs.SetInt("MKGun", canShowIndex);
            PlayerPrefsExtra.SetBool("MKGunDecka", isDecka);
        }
    }

    public Image GetImage() { return panelImage; }
    public void OpenIt(ref int k, Animator anim)
    {
        isChest = false;
        if (canShowIndex == 1 && !gameObject.activeInHierarchy)
        {
            gameObject.SetActive(true);
            anim.SetTrigger("PlayPanel");
            k++;
            Debug.Log(gameObject.name);
        }
          
    }

    public void OpenWirhDecka(ref int k, Animator anim)
    {
       isChest = false;
        if (canShowIndex == 1 && isDecka && !gameObject.activeInHierarchy)
        {
            gameObject.SetActive(true);
            anim.SetTrigger("PlayPanel");
            k++;
        }

    }

    public void OpenWirhDeckaChest(ref int k, Animator anim)
    {
        if(upgradeBasePanel != null)
        upgradeBasePanel.isChest = true;
        if (canShowIndex == 1 && isDecka && !gameObject.activeInHierarchy)
        {
            gameObject.SetActive(true);
            anim.SetTrigger("PlayPanel");
            k++;
        }

    }

    public void AplyToShow()
    {   
        canShowIndex = 1;
    }

    public void DoNotShow()
    {
        if(ChestBasePanel != null)
        ChestBasePanel.DoNotShow();
        canShowIndex = 0;
    }
    
    public void SetToDeccka()
    {
        if(ChestBasePanel != null)
        ChestBasePanel.SetToDeccka();
        isDecka = true;
    }

    public void RemoveFromDecka()
    {
        isDecka = false;
    }

    public int GetShowIndex() { return canShowIndex; }

    public bool isSetDekca() { return isDecka; }

    public TypePanel GetType() { return myType; }

    private void OnDisable()
    {
        SavePanel();
        LoadPanel();
    }

    public void SetImage(Sprite sprite)
    {
        panelImage.sprite = sprite;
    }
}
 public enum TypePanel
{
    sniper,
    spider,
    FrezeRay,
    Grenade,
    CritDamage,
    Armor,
    Speed,
    ShotGun,
    MKGun,
    MaxHealth,
    Regen,
    Petrol,
    MagicField,
    Shoker,
    Saw,
    Drone,
    Damage,
    FireRate,
    Magnit,
    ReduceCD,
    Radius
}