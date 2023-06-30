using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalAbilitiesUP : MonoBehaviour
{

    [SerializeField] private Bullet[] bullets;
    [SerializeField] private BurnCanistr burnCanistr;
    [SerializeField] private MagicField magicField;
    [SerializeField] private Granate granate;
    [SerializeField] private Drone[] drones;
    [SerializeField] private SLowerMan[] spider;
    [SerializeField] private Archer archer;

    public void ReduceAllAbilyty(float percent)
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].ReduceThrowCD(ReduceByPercent(bullets[i].GetThromCD(), percent));
 
        }
    }
   
    public void RadiusUpByPercent(float percent) 
    {
        burnCanistr.IncreaseRadius(GetPercent(burnCanistr.GetRadius(), percent));
        magicField.IncreaseRadius(GetPercent(magicField.GetRadius(), percent));
        granate.InreaseRadius(GetPercent(granate.GetRadius(), percent));
    //    archer.UpgradeRadius(GetPercent(archer.GetRadius(), percent));
        foreach (var item in drones)
        {
           item.IncreaseRadius((int)GetPercent(burnCanistr.GetRadius(), percent));
        }
    }

    private float ReduceByPercent(float currentCoolDown, float reductionPercentage)
    {
        return currentCoolDown * reductionPercentage / 100f;
    }

    private float GetPercent(float currentRadius, float percent)
    {
        return currentRadius * percent / 100f;
    }
}
