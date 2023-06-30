using UnityEngine;
public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance { get; private set; }
    [SerializeField] private Transform knightPoint;
    [SerializeField] private Transform archerPoint;
    [SerializeField] private GameObject[] units;
    [SerializeField] private Transform[] BombPoints;
    [SerializeField] private Transform[] WatchPoints;
    [SerializeField] private Transform[] magnetPoints;
    [SerializeField] private Transform[] AptekaPoints;
    [SerializeField] private Transform[] chestPoints;
    private Transform spawnPos;
    private Vector3 offset;
    public bool haveMagnet,haveWatch,haveApteka,haveBomb,haveChest;
    private int indexWave, indexBobmWwave;
    private void Awake()
    {
        Instance = this;
        indexWave = PlayerPrefs.GetInt("indexWave", indexWave);
         indexBobmWwave = PlayerPrefs.GetInt("indexBobmWwave", indexBobmWwave);
    }

    private void Start()
    {
        Invoke(nameof(SpawnItems), 60f);
    }

    private void SpawnItems()
    {
        //SpawnItem(ItemType.Bomb);
      //  SpawnItem(ItemType.Watch);
   //     SpawnItem(ItemType.Magnet);
     //   SpawnItem(ItemType.Apteka);
    }

    public void SpawnItem(ItemType itemType)
    {
        if(itemType == ItemType.Bomb )
        {
            indexBobmWwave++;
            PlayerPrefs.SetInt("indexBobmWwave", indexBobmWwave);
            if(indexBobmWwave >=3 && !haveBomb)
            {
                Instantiate(units[2], BombPoints[Random.Range(0, BombPoints.Length)].position, Quaternion.Euler(-129f, -149f, 119f));
                haveBomb = true;
                indexBobmWwave = 0;
                PlayerPrefs.SetInt("indexBobmWwave", indexBobmWwave);
            }
          
        }
        
        else if(itemType == ItemType.Watch && !haveWatch)
        {
            Instantiate(units[3], WatchPoints[Random.Range(0, WatchPoints.Length)].position, Quaternion.Euler(-28f, -192f, 6f));
            haveWatch = true;
        }
        
        else if(itemType == ItemType.Magnet && !haveMagnet)
        {
            Instantiate(units[4], magnetPoints[Random.Range(0, magnetPoints.Length)].position, Quaternion.Euler(-322f, -133f, -139f));
            haveMagnet = true;
                    
        } 
        else if (itemType == ItemType.Apteka && !haveApteka)
        {
            Instantiate(units[5], AptekaPoints[Random.Range(0, AptekaPoints.Length)].position, Quaternion.Euler(-150f, 180f, 0f));
            haveApteka = true;
        }
        else if(itemType ==  ItemType.Chest)
        {
            indexWave++;
            PlayerPrefs.SetInt("indexWave", indexWave);
            if (indexWave >= 3 && !haveChest)
            {
                Instantiate(units[6], chestPoints[Random.Range(0, chestPoints.Length)].position, Quaternion.Euler(0f, 0f, 0f));
                haveChest = true;
                indexWave = 0;
                PlayerPrefs.SetInt("indexWave", indexWave);
            }
          
        }
          
    }    
  
    public void SpawnSpider()
    {
        offset = new Vector3(Random.Range(-2f, 2f), Player.Instance.transform.position.y, Random.Range(-2f, 2f));
        Instantiate(units[0], Player.Instance.transform.position + offset, knightPoint.rotation);
        
    }

    public void RespawnSlowerMan()
    {
        offset = new Vector3(Random.Range(-2f, 2f), Player.Instance.transform.position.y, Random.Range(-2f, 2f));
        Instantiate(units[0], Player.Instance.transform.position + offset, knightPoint.rotation);
    }


    public SLowerMan GetSpider() { return units[0].GetComponent<SLowerMan>(); } 


}
