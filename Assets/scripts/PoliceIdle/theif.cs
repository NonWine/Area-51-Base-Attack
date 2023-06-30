using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class theif : MonoBehaviour
{
    [SerializeField] private int RouteId;
    private DetectorTheif _detector;
    private NavMeshAgent agent;
    private Transform endPos;
    private Vector3 direction;
    private EndPointManager pointManager;

    private void Start()
    {
        pointManager = GameObject.FindWithTag("PointManager").GetComponent<EndPointManager>();
        endPos = pointManager.GetStartRoute(RouteId);
        agent = GetComponent<NavMeshAgent>();
        _detector = GetComponentInChildren<DetectorTheif>();
    }

    void Update()
    {
        if (_detector.isDetected())
        {
            Move();
            Rotate();
        }
    }

    private void Move()
    {
        if (Vector3.Distance(endPos.position, transform.position) < 10f)
        {
            if (pointManager.isEndPoint())
            {
                PointerManager.Instance.RemoveFromList(GetComponentInChildren<EnemyPointer>());
                Destroy(gameObject);
                return;
            }
            else
                endPos = pointManager.ChangeEndPoint();
        }
        direction = (endPos.position - transform.position).normalized;
        agent.Move(direction * (agent.speed * Time.deltaTime));
    }

    private void Rotate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), agent.angularSpeed * Time.deltaTime);
    }

}
