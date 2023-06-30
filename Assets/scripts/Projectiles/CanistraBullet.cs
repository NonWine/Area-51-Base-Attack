using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanistraBullet : MonoBehaviour
{
    [SerializeField] private Field field;
    private int dmg;
    private float perSec;
    private float timeToLive;
    private float _radius;
    private float timer;
    private void Update()
    {

            timer += Time.deltaTime;
            transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.zero, 24f * timer); //24 красиво
            if (transform.localScale == Vector3.zero)
            {
                ParticlePool.Instance.PlayCanistraFx(new Vector3(transform.position.x, 1f, transform.position.z));
                Field obj = Instantiate(field, new Vector3(transform.position.x, 1f, transform.position.z), Quaternion.identity);
                obj.SetDamage(dmg);
                obj.SetPerSec(perSec);
                obj.SetTimeToLive(timeToLive);
                obj.SetRadius(_radius);
                Destroy(gameObject);
            }
        
    }

    public void SetRadius(float value) => _radius = value;

    public void SetDamage(int value) => dmg = value;

    public void SetPerSec(float time) => perSec = time;

    public void SetTimeToLive(float time) => timeToLive = time;
}
