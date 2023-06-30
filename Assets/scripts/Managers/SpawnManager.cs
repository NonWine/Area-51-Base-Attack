using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Pool;
public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }
    [SerializeField] private Wave[] waves;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private LineProgress lineProgress;
    [SerializeField] private float timeDelay;
    [SerializeField] private float reduceDelay;
    [SerializeField] private float timeLimitDelay;
    [SerializeField] private int setTestWave;
    [SerializeField] private EndlessWaves endlessWaves;
    [SerializeField] private GameObject boss;
    private List<Transform> tempPointSpawn;
    private int waveId;
    private int generalCounts;
    public int IndexSkipUpgrade;
    public PointerManager pointerManager;
    public GameObject arrow;
    private void Awake()
    {
        Instance = this;
        timeDelay = PlayerPrefs.GetFloat("timeDelay", timeDelay);
         waveId = PlayerPrefs.GetInt("waveId", 0); // start LEVEL\Get Current LEVEL
     
        tempPointSpawn = new List<Transform>();
    }

    private void Start()
    {
       
    }


    public void Spawn()
    {
        StartCoroutine(SpawnCor());
        Debug.Log(timeDelay);
    }

    private IEnumerator SpawnCor()
    {
        IndexSkipUpgrade++;
        if(IndexSkipUpgrade >= 3)
        {
            pointerManager.enabled = true;
            arrow.SetActive(true);
        }

        int j = 0;
        Debug.Log("spawn");
        for (int i = 0; i <= waves[waveId].Count[j]; i++)
        {

            if (i == waves[waveId].Count[j])
            {
                i = 0;
                j++;
                if (j == waves[waveId].Count.Length)
                    break;
            }
            generalCounts++;
        }
        lineProgress.SetMobs(generalCounts);
        UnitManager.Instance.SpawnItem(ItemType.Magnet);
        UnitManager.Instance.SpawnItem(ItemType.Apteka);
        UnitManager.Instance.SpawnItem(ItemType.Bomb);
        UnitManager.Instance.SpawnItem(ItemType.Watch);
        UnitManager.Instance.SpawnItem(ItemType.Chest);
        
        Debug.Log(generalCounts + "mobs");
        j = 0;
        int k = 0;
      //  SortPoints();
        for (int i = 0; i <= waves[waveId].Count[j]; i++)
        {
   
            if (i == waves[waveId].Count[j])
            {
                i = 0;
                
            
                j++;
                if (j == waves[waveId].Count.Length)
                    break;
                yield return new WaitForSeconds(timeDelay);
        //        SortPoints();
            }
            Transform point;

            while (true)
            {
                Transform spawnp = spawnPoints[Random.Range(0, spawnPoints.Length)];
                if (Vector3.Distance(spawnp.position, Player.Instance.transform.position) > 47f)
                {
                    point = spawnp;
                    break;
                }
                    
            }

            Unit unit = waves[waveId].Mob[j].GetComponent<Unit>();
            if (unit.GetType() == Mob.Alien)
            {
                var mob = ObjectPoolManager.Instance.SpawnAlian();
                mob.transform.position = point.position;
                //   mob.transform.position = spawnPoints[k].position;
                mob.transform.rotation = Quaternion.identity;
                mob.GetComponent<Unit>().ResetNavMesh();

              //  Instantiate(waves[waveId].Mob[j], spawnPoints[k].position, Quaternion.identity);
            }
            else if(unit.GetType() == Mob.Zombie)
            {
                var mob = ObjectPoolManager.Instance.SpawnRadioActive();
                mob.transform.position = point.position;

                // mob.transform.position = tempPointSpawn[k].position;
                mob.transform.rotation = Quaternion.identity;
                mob.GetComponent<Unit>().ResetNavMesh();

            }
            else if(unit.GetType() == Mob.Runner)
            {
                var mob = ObjectPoolManager.Instance.SpawnPolzun();
                mob.transform.position = point.position;
                mob.transform.rotation = Quaternion.identity;
                mob.GetComponent<Unit>().ResetNavMesh();

            }
            else if(unit.GetType() == Mob.RadiactiveType2)
            {
                var mob = ObjectPoolManager.Instance.SpawnRadioActiveType2();
                mob.transform.position = point.position;
                mob.transform.rotation = Quaternion.identity;
                mob.GetComponent<Unit>().ResetNavMesh();
            }
            else if(unit.GetType() == Mob.AlianType2)
            {
                var mob = ObjectPoolManager.Instance.SpawnAlian2();
                mob.transform.position = point.position;
                mob.transform.rotation = Quaternion.identity;
                mob.GetComponent<Unit>().ResetNavMesh();

            }
            else if(unit.GetType() == Mob.PolzunType2)
            {
                var mob = ObjectPoolManager.Instance.SpawnPolzunType2();
                mob.transform.position = point.position;
                mob.transform.rotation = Quaternion.identity;
                mob.GetComponent<Unit>().ResetNavMesh();

            }
            else if (unit.GetType() == Mob.Samurai)
            {
                var mob = ObjectPoolManager.Instance.SpawnSamurai();
                mob.transform.position = point.position;
                mob.transform.rotation = Quaternion.identity;
                mob.GetComponent<Unit>().ResetNavMesh();

            }
            else if (unit.GetType() == Mob.SamuraiType2)
            {
                var mob = ObjectPoolManager.Instance.SpawnSamuraiType2();
                mob.transform.position = point.position;
                mob.transform.rotation = Quaternion.identity;
                mob.GetComponent<Unit>().ResetNavMesh();

            }
            else 
            Instantiate(waves[waveId].Mob[j],point.position, Quaternion.identity);
            k++;
            if (k >= tempPointSpawn.Count)
                k = 0;
        }
        Debug.Log(generalCounts);
      
    }

    public void AddDeathEnemy()
    {
        generalCounts--;
        
        Debug.Log(generalCounts + "mobs");
        if (generalCounts == 0)
        {
         
            GameManager.Instance.GameWin();
        }
        else lineProgress.UpdateLineProgress();

    }

    public void AddlevelWave()
    {
        //saveLEVEL
        waveId++;
        if (waveId == 8)
            ObjectPoolManager.Instance.ClearRadiActive();
        if (waveId == 10)
            ObjectPoolManager.Instance.ClearAlian();
        if (waveId == 15)
            ObjectPoolManager.Instance.ClearPoolPolzun();
        if (waveId == 17)
            ObjectPoolManager.Instance.ClearSamurai();
        if (waveId == 20)
            ObjectPoolManager.Instance.ClearRadioActiveType2();
        if (waveId == 25)
            ObjectPoolManager.Instance.ClearAlian2();
        if (waveId == 29)
            ObjectPoolManager.Instance.ClearPolzun2();

        PlayerPrefs.SetInt("waveId", waveId);
  
        timeDelay -= reduceDelay;
        if (timeDelay < timeLimitDelay)
            timeDelay = timeLimitDelay;
        PlayerPrefs.SetFloat("timeDelay", timeDelay);
    }
    
    [ContextMenu("SetTestWave")]
    public void SetTestLevel()
    {
        PlayerPrefs.SetInt("waveId", setTestWave);
    }

    private void SortPoints()
    {
        tempPointSpawn.Clear();
        tempPointSpawn = new List<Transform>();
        Debug.Log(tempPointSpawn.Count);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (Vector3.Distance(spawnPoints[i].position, Player.Instance.transform.position) > 47f)
            {
                Debug.Log(Vector3.Distance(spawnPoints[i].position, Player.Instance.transform.position));
                Debug.Log(spawnPoints[i].name);
                tempPointSpawn.Add(spawnPoints[i]);
            }
               
        }
    }

    public void OffTutors()
    {
        IndexSkipUpgrade = 0;
        arrow.SetActive(false);
        pointerManager.OffManager();
    }

}

public class BaseWave
{

}

[System.Serializable]
public class Wave : BaseWave
{
    public GameObject[] Mob;
    public int[] Count;
}
[System.Serializable]
public class EndlessWaves : BaseWave
{
    public GameObject[] Mob;
    public int[] Count;
    
    public void SpawnMobs()
    {
       
    }
   
}