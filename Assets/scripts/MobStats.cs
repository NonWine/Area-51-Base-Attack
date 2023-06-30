using UnityEngine;

[CreateAssetMenu(fileName = "MobStats", menuName = "ScriptableObject/Mob", order = 1)]
public class MobStats : ScriptableObject
{
    [SerializeField] private int _speed;
    [SerializeField] private int _Damage;
    [SerializeField] private float _CoolDown;
    [SerializeField] private int health;
    private int level;
    public void SetDefaltPlayer()
    {
      
        _Damage = PlayerPrefs.GetInt("PlayerDamage",21); //21
        _CoolDown = PlayerPrefs.GetFloat("PlayerCD", 0.6f);
        health = PlayerPrefs.GetInt("PlayerHealth", 300); //200
    }


    public void SetDefaltRunner()
    {
        _speed = PlayerPrefs.GetInt("RuunerSpeed", 7);
        _Damage = PlayerPrefs.GetInt("RuunerDamage", 13); //3
        _CoolDown = PlayerPrefs.GetFloat("RuunerCD", 0.4f);
        health = PlayerPrefs.GetInt("RuunerHealth", 600);
    }

    public void SetDefaultZombie()
    {
        _speed = PlayerPrefs.GetInt("ZombieSpeed", 7); //7
        _Damage = PlayerPrefs.GetInt("ZombieDamage", 5); //5
        _CoolDown = PlayerPrefs.GetFloat("ZombieCD", 0.7f);
        health = PlayerPrefs.GetInt("ZombieHP", 120);//100
    }


    public void SetDefaultArcher()
    {
        _speed = PlayerPrefs.GetInt("ArcherSpeed", 12);
        _Damage = PlayerPrefs.GetInt("ArcherDamage", 80); // 15
        _CoolDown = PlayerPrefs.GetFloat("ArcherCD", 0.6f);
        health = PlayerPrefs.GetInt("ArcherHP", 200);
        level = PlayerPrefs.GetInt("ArcherLevel", 1);
    }


    public void SetDefaultAlien()
    {
        _speed = PlayerPrefs.GetInt("AlienSpeed", 7);
        _Damage = PlayerPrefs.GetInt("AkienDamage", 12); //3
        _CoolDown = PlayerPrefs.GetFloat("ALienCD", 0.4f);
        health = PlayerPrefs.GetInt("AlienHealth", 390);
    }

    public void SetDefaultRadiactiveType2()
    {
        _speed = PlayerPrefs.GetInt("RadiactiveType2Speed", 7);
        _Damage = PlayerPrefs.GetInt("RadiactiveType2Damage", 17); //3
        _CoolDown = PlayerPrefs.GetFloat("RadiactiveType2CD", 0.4f);
        health = PlayerPrefs.GetInt("RadiactiveType2Health", 1100);
    }

    public void SetDefaultAlianType2()
    {
        _speed = PlayerPrefs.GetInt("AlianType2Speed", 7);
        _Damage = PlayerPrefs.GetInt("AlianType2Damage", 20); //3
        _CoolDown = PlayerPrefs.GetFloat("AlianType2CD", 0.4f);
        health = PlayerPrefs.GetInt("AlianType2Health", 1400);
    }

    public void SetDefaultPolzunType2()
    {
        _speed = PlayerPrefs.GetInt("PolzunType2Speed", 7);
        _Damage = PlayerPrefs.GetInt("PolzunType2Damage", 22); //3
        _CoolDown = PlayerPrefs.GetFloat("PolzunType2CD", 0.4f);
        health = PlayerPrefs.GetInt("PolzunType2Health", 2100);
    }
    public void SetDefaultSamurai()
    {
        _speed = PlayerPrefs.GetInt("SamuraiSpeed", 7);
        _Damage = PlayerPrefs.GetInt("SamuraiDamage", 15); //3
        _CoolDown = PlayerPrefs.GetFloat("SamuraiCD", 0.4f);
        health = PlayerPrefs.GetInt("SamuraiHealth", 750);
    }

    public void SetDefaultSamuraiType2()
    {
        _speed = PlayerPrefs.GetInt("SamuraiType2Speed", 7);
        _Damage = PlayerPrefs.GetInt("SamuraiType2Damage", 25); //3
        _CoolDown = PlayerPrefs.GetFloat("SamuraiType2CD", 0.4f);
        health = PlayerPrefs.GetInt("Samuraitype2Health", 2500);
    }

    public void SetDefaultBigRadioActive()
    {
        _speed = PlayerPrefs.GetInt("SetDefaultBigAlianSpeed", 7);
        _Damage = PlayerPrefs.GetInt("SetDefaultBigAlianDamage", 20); //3
        _CoolDown = PlayerPrefs.GetFloat("SetDefaultBigAlianCD", 0.4f);
        health = PlayerPrefs.GetInt("SetDefaultBigAlianHealth", 6400);
    }

    public void SetDefaultBigPolzun()
    {
        _speed = PlayerPrefs.GetInt("SetDefaultBigAlianType2Speed", 7);
        _Damage = PlayerPrefs.GetInt("SetDefaultBigAlianType2Damage", 35); //3
        _CoolDown = PlayerPrefs.GetFloat("SetDefaultBigAlianType2CD", 0.4f);
        health = PlayerPrefs.GetInt("SetDefaultBigAlianType2Health", 20000);
    }

    public void SetDefaultBigAlian()
    {
        _speed = PlayerPrefs.GetInt("BigSamuraiSpeed", 7);
        _Damage = PlayerPrefs.GetInt("BigSamuraiDamage", 30); //3
        _CoolDown = PlayerPrefs.GetFloat("BigSamuraiCD", 0.4f);
        health = PlayerPrefs.GetInt("BigSamuraiHealth", 10000);
    }

    public void SetDefaultBigSamurai2()
    {
        _speed = PlayerPrefs.GetInt("BigSamuraiType2Speed", 7);
        _Damage = PlayerPrefs.GetInt("BigSamuraiType2Damage", 45); //3
        _CoolDown = PlayerPrefs.GetFloat("BigSamuraiType2CD", 0.4f);
        health = PlayerPrefs.GetInt("BigSamuraitype2Health", 34000);
    }

    public void SetDefaultFinalSamurai()
    {
        _speed = PlayerPrefs.GetInt("SetDefaultFinalSamuraiSpeed", 7);
        _Damage = PlayerPrefs.GetInt("SetDefaultFinalSamuraiDamage", 55); //3
        _CoolDown = PlayerPrefs.GetFloat("SetDefaultFinalSamuraiCD", 0.4f);
        health = PlayerPrefs.GetInt("SetDefaultFinalSamuraiHealth", 80000);
    }

    public void SetDefaultBigRadiActiveType2()
    {
        _speed = PlayerPrefs.GetInt("SetDefaultFinalSamuraiSpeed", 7);
        _Damage = PlayerPrefs.GetInt("SetDefaultFinalSamuraiDamage", 55); //3
        _CoolDown = PlayerPrefs.GetFloat("SetDefaultFinalSamuraiCD", 0.4f);
        health = PlayerPrefs.GetInt("SetDefaultFinalSamuraiHealth", 40000);
    }


    public void SetDefaultBigAlianType2()
    {
        _speed = PlayerPrefs.GetInt("SetDefaultFinalSamuraiSpeed", 7);
        _Damage = PlayerPrefs.GetInt("SetDefaultFinalSamuraiDamage", 55); //3
        _CoolDown = PlayerPrefs.GetFloat("SetDefaultFinalSamuraiCD", 0.4f);
        health = PlayerPrefs.GetInt("SetDefaultFinalSamuraiHealth", 50000);
    }

    public void SetDefaultBigPolzunType2()
    {
        _speed = PlayerPrefs.GetInt("SetDefaultBigPolzun2Speed", 7);
        _Damage = PlayerPrefs.GetInt("SetDefaultBigPolzun2Damage", 55); //3
        _CoolDown = PlayerPrefs.GetFloat("SetDefaultBigPolzun2CD", 0.4f);
        health = PlayerPrefs.GetInt("SetDefaultBigPolzun2Health", 60000);
    }

    public void SetDefaultBigSamuraiType2()
    {
        _speed = PlayerPrefs.GetInt("SetDefaultBigPolzun2Speed", 7);
        _Damage = PlayerPrefs.GetInt("SetDefaultBigPolzun2Damage", 55); //3
        _CoolDown = PlayerPrefs.GetFloat("SetDefaultBigPolzun2CD", 0.4f);
        health = PlayerPrefs.GetInt("SetDefaultBigPolzun2Health", 70000);
    }


    public void levelUp()
    {
        level++;
    }
     

    public void ReduceSpeed(int value) { _speed -= value; }
    public int GetLevel() { return level; }

    public int GetSpeed() { return _speed; }
    public int GetDamage() { return _Damage; }
    public float GetCD() { return _CoolDown; }

    public void ReduceCD(float value) { _CoolDown -= value; }

    public void AddDamage(int value)
    {
        _Damage += value;

    }

    public void SetDamage(int value) => _Damage = value;
    public void AddSpeed(int value) => _speed += value;

    public void ResetStats()
    {
        _Damage = 35;
        _CoolDown = 0.4f;
    }

    public void AddHealth(int value) => health += value;

    public void ReduceHealth(int value) => health -= value;

    public int GetHealth() { return health; }

    public void SetHealth(int value) { health = value; }
}
