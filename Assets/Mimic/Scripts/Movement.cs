using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MimicSpace
{
    /// <summary>
    /// This is a very basic movement script, if you want to replace it
    /// Just don't forget to update the Mimic's velocity vector with a Vector3(x, 0, z)
    /// </summary>
    public class Movement : MonoBehaviour, IControllable
    {
        [Header("Controls")]
        [Tooltip("Body Height from ground")]
        [Range(0.5f, 5f)]
        public float height = 0.8f;
        public float speed = 5f;
        Vector3 velocity = Vector3.zero;
        public float velocityLerpCoef = 4f;
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Mimic myMimic;
        [SerializeField] private MeshRenderer mimicColor;
        [SerializeField] private Transform forcePoint;
        private bool dead;
        private bool isForce;
        private float timer;
        private float unFrostTimer;
        private bool isFrost;
        private Vector3 forceDistance;
        private float frozenDuration;
        private void Start()
        {
            forceDistance = Vector3.zero;
        }

        private void Update()
        {
            if (isForce)
            {
                if (forceDistance == Vector3.zero)
                    forceDistance = forcePoint.position;

                if (transform.position != forceDistance)
                {

                    GetComponent<Unit>().SetMove(false);
                    timer += Time.deltaTime;
                    agent.enabled = false;
                    myMimic.velocity = Vector3.zero;
                    transform.position = Vector3.Lerp(transform.position, forceDistance, 2f * timer);
                }
                else if (transform.position == forceDistance)
                {
                    isForce = false;
                    agent.enabled = true;
                    forceDistance = Vector3.zero;
                    GetComponent<Unit>().SetMove(true);
                    timer = 0f;
                }

            }
            //if (isFrost)
            //{
            //    agent.enabled = false;
            //    GetComponent<Unit>().SetMove(false);
            //    myMimic.velocity = Vector3.zero;
            //    unFrostTimer += Time.deltaTime;
            //    if(unFrostTimer >= frozenDuration)
            //    {
            //        isFrost = false;
            //        agent.enabled = true;
            //        GetComponent<Unit>().SetMove(true);
            //        unFrostTimer = 0f;
            //        Debug.Log("froze");
            //    }
            //}

        }

        public void MoveToPlayer(Transform target, Unit unit)
        {
            if (Vector3.Distance(transform.position, target.position) >= unit.GetDistance())
            {
                agent.isStopped = false;
                unit.SetAttacking(false);
                myMimic.velocity = agent.velocity;
            }
            else if (Vector3.Distance(transform.position, target.position) <= unit.GetDistance())
            {
                unit.GiveDamage();
                unit.SetAttacking(true);
            }
            agent.SetDestination(target.position);
            myMimic.velocity = agent.velocity;
        }


        public void DeathMimic()
        {
        
            GetComponent<Unit>().SetDeath();
            ParticlePool.Instance.MimicDead(transform.position);
            GetComponent<Unit>().SpawnCoins();
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<HealthUI>().TurnOffUiHP();
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            SpawnManager.Instance.AddDeathEnemy();
        }

        public void FrozeStateMimic(float time)
        {
            GetComponent<Unit>().Death();

        }

        public NavMeshAgent GetNavMesh() { return agent; }

        public void Move(Transform target, Unit unit)
        {
            MoveToPlayer(target, unit);
        }

        public void Death()
        {
            DeathMimic();
        }

        public bool isDeath()
        {
            return dead;
        }
        public void ForceState()
        {

            isForce = true;
        }
    }

}