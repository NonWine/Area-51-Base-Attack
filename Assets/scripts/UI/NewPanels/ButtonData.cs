using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class ButtonData : MonoBehaviour
{
 //   [SerializeField] private Image icon;
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text subTitle;
    [SerializeField] private UpgradeData[] upgradeDatas;
    [SerializeField] private Image[] stars;
    private int level;

    public void Set(UpgradeData upgradeData)
    {
     //   icon.sprite = upgradeData.image;
        title.text = upgradeData.title;
        subTitle.text = upgradeData.subTitle;
    }

    private void DefineLevel()
    {
        TypePanel type = GetComponent<BasePanel>().GetType();
        UnitLevelManager levelManager = UnitLevelManager.Instance;
        if(type  != null && levelManager != null)
        switch (type)
        {
            case TypePanel.Armor:
                level = levelManager.GetResistanceLevel();
                break;
            case TypePanel.Damage:
                level = levelManager.GetDamageLevel();
                break;
            case TypePanel.Drone:
                level = levelManager.GetDroneLevel();
                break;
            case TypePanel.FireRate:
                level = levelManager.GetFireRateLevel();
                break;
            case TypePanel.FrezeRay:
                level = levelManager.GetRayFrozeLevel();
                break;
            case TypePanel.Grenade:
                level = levelManager.GetGrenadeLevel();
                break;
            case TypePanel.MagicField:
                level = levelManager.GetMagicFieldLevel();
                break;
            case TypePanel.MaxHealth:
                level = levelManager.GetMaxHealthLevel();
                break;
            case TypePanel.Petrol:
                level = levelManager.GetCanistrLevel();
                break;
            case TypePanel.Regen:
                level = levelManager.GetRegenLevel();
                break;
            case TypePanel.Saw:
                level = levelManager.GetSawLevel();
                break;
            case TypePanel.Shoker:
                level = levelManager.GetShokerLevel();
                break;
            case TypePanel.sniper:
                level = levelManager.GetSniperLevel();
                break;
            case TypePanel.Speed:
                level = levelManager.GetSpeedLevel();
                break;
            case TypePanel.spider:
                level = levelManager.GetSpiderLevel();
                break;
            case TypePanel.CritDamage:
                level = levelManager.GetCritDamageLevel();
                break;
            case TypePanel.Magnit:
                level = levelManager.GetMagnetLevel();
                break;
            case TypePanel.Radius:
                level = levelManager.GetRadiusLevel();
                break;
            case TypePanel.ReduceCD:
                level = levelManager.GetReduceCoolDownLevel();
                break;
            case TypePanel.MKGun:
                level = levelManager.GetWeaponLevel();
                break;
            default:
                break;
        }

        if(type != TypePanel.MKGun)
        {
            for (int i = 0; i < 6; i++)
            {

                stars[i].gameObject.SetActive(false);
            }
        }
        if(type == TypePanel.MKGun)
        {
            for (int i = 0; i < 2; i++)
            {

                stars[i].gameObject.SetActive(false);
            }
        }
        for (int i = 0; i < level; i++)
        {
             stars[i].GetComponent<Animator>().SetBool("playstar", false);

                stars[i].gameObject.SetActive(true);
        }
        stars[level].gameObject.SetActive(true);
          stars[level].GetComponent<Animator>().SetBool("playstar", true);
      
            


    }


    private void OnEnable()
    {
        DefineLevel();
        Set(upgradeDatas[level]);
    }
}
