using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageByPrecent : MonoBehaviour
{
    [SerializeField] private int _percent;
    [SerializeField] private MobStats stats;
    [SerializeField] private Animator _anim;
    private float forpercent;
    private int startHealth;
    private float sum;

    public void TakeDamage(int count)
    {
        float   percent = ((forpercent - (startHealth - count)) / forpercent);
        sum += (percent * 100f);
        if(sum >= _percent)
        {
            _anim.SetTrigger("takeDamage");
            sum -= _percent;
        }
    }

}
