using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apteka : Item
{
    protected override void Action()
    {
        Player.Instance.Heal(80);
        Debug.Log("HEAL");
        Spawn();
    }

    protected override IEnumerator Respawn()
    {
        UnitManager.Instance.haveApteka = false;
        Destroy(gameObject);
        yield break;
    }
}
