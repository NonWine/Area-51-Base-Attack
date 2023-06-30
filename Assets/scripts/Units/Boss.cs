using UnityEngine.AI;
using UnityEngine;
using System.Collections;
public class Boss : MonoBehaviour
{
    [SerializeField] private GameObject mobs;
    [SerializeField] private int count;
    [SerializeField] private Animator anim;
    [SerializeField] private float spawnCd;
    private NavMeshAgent agent;
    private Unit unit;
    private bool casting;
    private void Start()
    {
        unit = GetComponent<Unit>();
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(SpawnZombie());
    }

    private IEnumerator SpawnZombie()
    {
        yield return new WaitForSeconds(spawnCd);
        casting = true;
        agent.isStopped = true;
        agent.velocity = Vector3.zero;
        Debug.Log("beforeSpawn");
        anim.SetInteger("state", 4);
        for (int i = 0; i < count; i++)
        {
            //UnitManager.Instance.SpawnSmallZombie(mobs);
            yield return new WaitForSeconds(0.5f);
        }
        Debug.Log("after spawn");
        anim.SetInteger("state", 2);
        agent.isStopped = false;
        casting = false;
        yield return StartCoroutine(SpawnZombie());
    }

    public void Move(Transform target)
    {
        if (!casting)
        {
            if (Vector3.Distance(transform.position, target.position) >= unit.GetDistance())
            {
                anim.SetInteger("state", 1);
                agent.isStopped = false;
                unit.SetAttacking(false);
            }
            else if (Vector3.Distance(transform.position, target.position) <= unit.GetDistance())
            {
                agent.isStopped = true;
                agent.velocity = Vector3.zero;
                unit.GiveDamage();
                unit.SetAttacking(true);
            }
                agent.SetDestination(target.position);
        }
   
    }
}
