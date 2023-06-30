using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MimicSpace;
using UnityEngine.AI;
public class ControllStateUnit : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private SkinnedMeshRenderer bodyMesh;
    [SerializeField] private SkinnedMeshRenderer headMesh;
    [SerializeField] private Transform forcePoint;
    [SerializeField] private Transform body;
    private Texture texture, headTexture;
    private Vector3 forceDistance;
    private Unit unit;
    private NavMeshAgent agent;
    private bool isForce;
    private float timer;
    public bool isFrost;
    private void Start()
    {
        forceDistance = Vector3.zero;
        unit = GetComponent<Unit>();
        agent = GetComponent<NavMeshAgent>();
        texture = bodyMesh.materials[0].mainTexture;
        headTexture = headMesh.materials[0].mainTexture;
    }

    private void Update()
    {
        if (isForce)
        {
            if (forceDistance == Vector3.zero)
                forceDistance = forcePoint.position;
       
            if(transform.position != forceDistance)
            {

                unit.SetMove(false);
                timer += Time.deltaTime;
                agent.enabled = false;
                transform.position = Vector3.Lerp(transform.position, forceDistance, 2f * timer);
            }
            else if(transform.position == forceDistance)
            {
                isForce = false;
                agent.enabled = true;
                forceDistance = Vector3.zero;
                unit.SetMove(true);
                timer = 0f;
            }
            
        }
    }


    private void UnFroze()
    {
        if (unit.GetType() == Mob.Zombie || unit.GetType() == Mob.Alien ||unit.GetType() ==  Mob.Samurai || unit.GetType() == Mob.BigSamurai ||unit.GetType() == Mob.BigRadioActive || unit.GetType() == Mob.BigAlien )
        {
            bodyMesh.materials[0].mainTexture = texture;
            bodyMesh.materials[0].color = Color.white;
            headMesh.materials[0].mainTexture = headTexture;
            headMesh.materials[0].color = Color.white;

            agent.speed = unit.GetStats().GetSpeed();
        }

        else if(unit.GetType() == Mob.RadiactiveType2 || unit.GetType() == Mob.BigRadioActiveType2)
        {
            bodyMesh.materials[0].mainTexture = texture;
            bodyMesh.materials[0].color = new Color32(255, 0, 0, 255);
            headMesh.materials[0].mainTexture = headTexture;
            headMesh.materials[0].color = new Color32(255, 0, 0, 255);
            agent.speed = unit.GetStats().GetSpeed();
        }

        else if (unit.GetType() == Mob.AlianType2 || unit.GetType() == Mob.BigAlianType2)
        {
            bodyMesh.materials[0].mainTexture = texture;
            bodyMesh.materials[0].color = new Color32(114, 255, 0, 255);
            headMesh.materials[0].mainTexture = headTexture;
            headMesh.materials[0].color =  new Color32(114, 255, 0, 255);
            agent.speed = unit.GetStats().GetSpeed();
        }

        else if (unit.GetType() == Mob.PolzunType2)
        {
            bodyMesh.materials[0].color = new Color32(41, 49, 212, 255);
            agent.speed = unit.GetStats().GetSpeed();
        }

        else if (unit.GetType() == Mob.Runner || unit.GetType() == Mob.SmallRunner || unit.GetType() == Mob.BigPolzun || unit.GetType() == Mob.BigPolzunType2)
        {
            agent.speed = unit.GetStats().GetSpeed();
            bodyMesh.materials[0].color = new Color32(212, 48, 41, 255);

        }

        else if (unit.GetType() == Mob.Necromants)
        {
            agent.speed = unit.GetStats().GetSpeed();
            bodyMesh.materials[0].color = new Color32(212, 48, 41, 255);

        }
        else if(unit.GetType() == Mob.SamuraiType2 || unit.GetType() == Mob.BigSamuraiType2 || unit.GetType() == Mob.FinalSamurai)
        {
            bodyMesh.materials[0].mainTexture = texture;
            bodyMesh.materials[0].color = new Color32(0, 109, 140, 255);
            headMesh.materials[0].mainTexture = headTexture;
            headMesh.materials[0].color = new Color32(0, 109, 140, 255);
            agent.speed = unit.GetStats().GetSpeed();
        }

        anim.enabled = true;
        isFrost = false;
        unit.SetAttacking(false);
    }

    public void UnBoilState()
    {
        agent.speed = unit.GetStats().GetSpeed();
        if (unit.GetType() == Mob.RadiactiveType2)
        {
            bodyMesh.materials[0].mainTexture = texture;
            bodyMesh.materials[0].color = new Color32(255, 0, 0, 255);
            headMesh.materials[0].mainTexture = headTexture;
            headMesh.materials[0].color = new Color32(255, 0, 0, 255);
            agent.speed = unit.GetStats().GetSpeed();
        }

        else if (unit.GetType() == Mob.AlianType2)
        {
            bodyMesh.materials[0].mainTexture = texture;
            bodyMesh.materials[0].color = new Color32(114, 255, 0, 255);
            headMesh.materials[0].mainTexture = headTexture;
            headMesh.materials[0].color = new Color32(114, 255, 0, 255);
            agent.speed = unit.GetStats().GetSpeed();
        }

        else if (unit.GetType() == Mob.PolzunType2)
        {
            bodyMesh.materials[0].color = new Color32(41, 49, 212, 255);
            agent.speed = unit.GetStats().GetSpeed();
        }
        else if (unit.GetType() == Mob.SamuraiType2)
        {
            bodyMesh.materials[0].mainTexture = texture;
            bodyMesh.materials[0].color = new Color32(0, 109, 140, 255);
            headMesh.materials[0].mainTexture = headTexture;
            headMesh.materials[0].color = new Color32(0, 109, 140, 255);
            agent.speed = unit.GetStats().GetSpeed();
        }else
        {
            bodyMesh.materials[0].color = Color.white;
            headMesh.materials[0].color = Color.white;
        }
    }

    public void FrozeState(float time)
    {
        unit.SetAttacking(false);
        agent.speed = 0;
        anim.enabled = false;
        headMesh.materials[0].mainTexture = null;
        bodyMesh.materials[0].mainTexture = null;
        bodyMesh.materials[0].color = new Color32(36, 175, 250, 255);
        headMesh.materials[0].color = new Color32(36, 175, 250, 255);
        isFrost = true;
        Invoke(nameof(UnFroze), time);
    }

    public void BoilState(int speed)
    {
        agent.speed -= speed;
        bodyMesh.materials[0].color = new Color32(120,80,125,255);
        headMesh.materials[0].color = new Color32(120, 80, 125, 255);

    }

    public void ForceState()
    {

        isForce = true;
    }

}
