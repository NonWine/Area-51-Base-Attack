using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DamageController : MonoBehaviour
{
    public static DamageController Instance { get; private set; }
    public float sliderPercentstart;
    public Slider slider;
    public TMP_Text text;
    public Bullet[] playerBulletes;
    private void Awake()
    {
        Instance = this;
       
       
     
    }

    private void Start()
    {
        //slider.value = sliderPercentstart;
        //text.text = slider.value.ToString();

    }

    public int SetDamage(int dmg)
    {
        float t = ((float)dmg / 100f) * 15f;
        return (int)t;
    }

    public void ValueChangeCheck()
    {
        ObjectPoolManager.Instance.ChangeDamage();
        text.text = slider.value.ToString() + "%";
    }

    public void PlayerChangeSlider()
    {
        foreach (var item in playerBulletes)
        {
            item.SetDamage(item.GetDamage() + this.SetDamage(item.GetDamage()));
        }
    }
}
