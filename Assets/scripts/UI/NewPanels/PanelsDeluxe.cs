using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MAXHelper;
public class PanelsDeluxe : MonoBehaviour
{
    public static PanelsDeluxe Instance { get; private set; }
    [SerializeField] private List<BasePanel> activeUpgrades = new List<BasePanel>();
    [SerializeField] private List<BasePanel> passiveUpgrades = new List<BasePanel>();
    [SerializeField] private List<BasePanel> testPanel = new List<BasePanel>();
    [SerializeField] private GameObject main;
    [SerializeField] private Animator anim;
    [SerializeField] private bool isTest;
    [SerializeField] private FillZonaWithMoney zona;
    [SerializeField] private PanelsDeluxe deluxe;
    public List<BasePanel> basePanels { get; set; }
    private int count = 0;
    public bool isFoolDecka;
    public bool fullActiveDecka;
    
    private void Awake()
    {
        Instance = this;
      isFoolDecka =    PlayerPrefsExtra.GetBool("FullDecka", isFoolDecka);
      fullActiveDecka =  PlayerPrefsExtra.GetBool("FullActiveDacka", fullActiveDecka);
        
   
    }

    private void Start()
    {
        basePanels = new List<BasePanel>();
        foreach (var item in activeUpgrades)
        {
            basePanels.Add(item);
        }
        foreach (var item in passiveUpgrades)
        {
            basePanels.Add(item);
        }
    }


    public void SelectUpgrade()
    {
        foreach (var item in activeUpgrades)
        {
            item.gameObject.SetActive(false);
        }
        foreach (var item in passiveUpgrades)
        {
            item.gameObject.SetActive(false);
        }
        count = 0;
        if (isTest)
        {
            foreach (var item in testPanel)
            {
                item.OpenIt(ref count, anim);
            }
        }
          
        else
        {
          
            if (isFoolDecka && fullActiveDecka)
            {
                int maxCard = 0;
                foreach (var item in passiveUpgrades)
                {
                    if(item.isSetDekca() && item.GetShowIndex() == 1)
                    {
                        maxCard++;
                        Debug.Log("yes");
                    }
                }
                foreach (var item in activeUpgrades)
                {
                    if (item.isSetDekca() && item.GetShowIndex() == 1)
                    {
                        maxCard++;
                        Debug.Log("yes");
                    }
                }
                Debug.Log(maxCard);
                switch (maxCard)
                {
                    case 1:
                        count = 2;
                        zona.SetMaxLevel();
                        break;
                    case 2:
                        count = 1;
                        break;
                    case 0:
                        UpgradeManger.Instance.ClosePanels();
                        zona.SetMaxLevel();
                        return;
                    default:
                        break;
                }
            }
            

            while (count != 3)
            {

                float randmodify = Random.value;
                if (randmodify >= 0.5f)
                {
                    int randex = Random.Range(0, activeUpgrades.Count);
                    if (!fullActiveDecka)
                        activeUpgrades[randex].OpenIt(ref count, anim);
                    if(fullActiveDecka)
                        activeUpgrades[randex].OpenWirhDecka(ref count, anim);
                }
                else
                {
                    int randex = Random.Range(0, passiveUpgrades.Count);
                    if (!isFoolDecka)
                        passiveUpgrades[randex].OpenIt(ref count, anim);
                    else if (isFoolDecka)
                        passiveUpgrades[randex].OpenWirhDecka(ref count, anim);
                }
            }
        
        }
      
    }

    public void SelectChest()
    {
        foreach (var item in activeUpgrades)
        {
            item.gameObject.SetActive(false);
        }
        foreach (var item in passiveUpgrades)
        {
            item.gameObject.SetActive(false);
        }
        count = 0;
        if (isTest)
        {
            foreach (var item in testPanel)
            {
                item.OpenIt(ref count, anim);
            }
        }

        else
        {
            isFoolDecka = deluxe.isFoolDecka;
            fullActiveDecka = deluxe.fullActiveDecka;
            if (true)
            {
                int maxCard = 0;
                foreach (var item in passiveUpgrades)
                {
                    if (item.isSetDekca() && item.GetShowIndex() == 1)
                    {
                        maxCard++;
                        Debug.Log("yes");
                    }
                }
                foreach (var item in activeUpgrades)
                {
                    if (item.isSetDekca() && item.GetShowIndex() == 1)
                    {
                        maxCard++;
                        Debug.Log("yes");
                    }
                }
                Debug.Log(maxCard);
                switch (maxCard)
                {
                    case 1:
                        count = 2;
                        break;
                    case 2:
                        count = 1;
                        break;
                    case 0:
                        UpgradeManger.Instance.CloseChestPanel();
                    
                        return;
                    default:
                        break;
                }
            }


            while (count != 3)
            {

                float randmodify = Random.value;
                if (randmodify >= 0.5f)
                {
                    int randex = Random.Range(0, activeUpgrades.Count);
                        activeUpgrades[randex].OpenWirhDeckaChest(ref count, anim);
                }
                else
                {
                    int randex = Random.Range(0, passiveUpgrades.Count);
                        passiveUpgrades[randex].OpenWirhDeckaChest(ref count, anim);
                }
            }

        }
    }


    public void SaveTest()
    {
        foreach (var item in testPanel)
        {
            item.SavePanel();
        }
        foreach (var item in activeUpgrades)
        {
            item.SavePanel();
            item.gameObject.SetActive(false);
        }

        foreach (var item in passiveUpgrades)
        {
            item.SavePanel();
            item.gameObject.SetActive(false);
        }

    }

    public void SetPassiveDecka()
    {
        isFoolDecka = true;
        PlayerPrefsExtra.SetBool("FullDecka", isFoolDecka);
    }

    public void SetActiveDecka()
    {
        fullActiveDecka = true;
        PlayerPrefsExtra.SetBool("FullActiveDacka", fullActiveDecka);
    }

    private void OnDisable()
    {
        SaveTest();
    }

    public void GiveAllUpgrades()
    {
        foreach (var item in basePanels)
        {
            if (item.gameObject.activeSelf)
            {
                item.unityAction.Invoke();
            }
        }
        UpgradeManger.Instance.CloseChestPanel();
    }

    public void GiveRandomAbility()
    {
        Vector3 pos = Chest.Instance.transform.position;
        for (int i = 0; i < zona.GetPercentMoney(); i++)
        {
            CoinSpawner.Instance.CoinSpawn(pos + (Vector3.up * 6f));
        }
     
        UpgradeManger.Instance.CloseChestPanel();
        //        AdsManager.ShowInter("OpenedChest");
        ADSManagerSDK.Instance.ShowMyInter("Chest");
    }
}
