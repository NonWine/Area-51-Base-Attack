using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;
    private int dmg;
    private float perSec;
    private float timeToLive;
    private List<Unit> units = new List<Unit>();
    private bool isMagicField;
    private void Start()
    {
        Invoke(nameof(EndField), timeToLive -0.5f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dire"))
        {
            units.Add(other.GetComponent<Unit>());
            if (isMagicField)
            {
                Unit unit = other.GetComponent<Unit>();
                if (unit.GetType() == Mob.Zombie)
                {
                    unit.SetAttacking(false);
                    unit.Death();
                }
                    
                else
                    other.GetComponent<Unit>().GetPeriodDamage(perSec, dmg);
            }
            else 
                other.GetComponent<Unit>().GetPeriodDamage(perSec, dmg);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Dire"))
        {
            other.GetComponent<Unit>().StopPerSecDamage();
            Debug.Log("exit");
        }
    }

    private void EndField()
    {
        foreach (var item in units)
        {
            if (item != null)
            {

                item.StopPerSecDamage();
            }

        }
        Destroy(gameObject, 0.5f);
    }


    public void SetDamage(int value) => dmg = value;

    public void SetPerSec(float time) => perSec = time;

    public void SetTimeToLive(float time) => timeToLive = time;

    public void SetMagicField() => isMagicField = true;

    public void SetRadius(float rad)
    {
        //GetComponent<SphereCollider>().radius = rad;

        BoxCollider boxCollider = GetComponent<BoxCollider>();
        boxCollider.size = new Vector3(rad, 20, rad);
        if (isMagicField)
        ps.gameObject.transform.localScale = new Vector3(rad / 2.5f, rad / 2.5f, rad / 2.5f);
        else
            ps.gameObject.transform.localScale = new Vector3(rad / 4f, rad / 4f, rad / 4f);
    }

}
