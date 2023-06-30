using System.Collections.Generic;
using UnityEngine;

public static class MobList
{
    private static List<Unit> mob = new List<Unit>();

    public static void AddMobInList(Unit obj) => mob.Add(obj);
    public static int GetAmount() { return mob.Count; }
    public static Unit GetMob(int index) { return mob[index]; }

    public static void RemoveFromList(GameObject unit)
    {
        foreach (var item in mob)
        {
            if(item.name == unit.name)
            {
                mob.Remove(item);
                break;
            }
        }
    }
}
