using UnityEngine;

public class InitialSpawner : MonoBehaviour
{
    public GameObject foxPrefab;
    public GameObject appPrefab;
    public GameObject watPrefab;
    public GameObject chiPrefab;
    public GameObject coinPrefab;
    public GameObject dinoPrefab;
    public GameObject outputOBJ;
    public int initialFood;
    public int initialCoins;
    public float foodRespawnDelayS;
    public float coinRespawnDelayS;

    private int countDown;

    public int initialCreatures;
    void Awake()
    {
        Vector3 sp = new Vector3(0, 0, 0);
        Instantiate(outputOBJ, sp, Quaternion.identity);

        for (int i = 0; i < initialFood; i++)
        { 
            if (i % 3 == 0)
            {
                Vector3 randomSpawnPosition = new Vector3(Random.Range(17, 55), Random.Range(-30, 30), 0);
                Instantiate(appPrefab, randomSpawnPosition, Quaternion.identity);
            } else if (i % 3 == 1)
            {
                Vector3 randomSpawnPosition = new Vector3(Random.Range(-55, -12), Random.Range(-30, 30), 0);
                Instantiate(watPrefab, randomSpawnPosition, Quaternion.identity);
            } else
            {
                Vector3 randomSpawnPosition = new Vector3(Random.Range(-55, 55), Random.Range(-10, 15), 0);
                Instantiate(chiPrefab, randomSpawnPosition, Quaternion.identity);
            }
        }

        for (int i = 0; i < initialCoins; i++)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-55, 55), Random.Range(-10, 15), 0);
            Instantiate(coinPrefab, randomSpawnPosition, Quaternion.identity);
        }

        for (int i = 0; i < initialCreatures-3; i++)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(25, 45), Random.Range(12, 25), 0);
            Instantiate(foxPrefab, randomSpawnPosition, Quaternion.identity);
        }
        for (int i = 0; i < 3; i++)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-25, -45), Random.Range(-10, 10), 0);
            Instantiate(foxPrefab, randomSpawnPosition, Quaternion.identity);
        }


        Vector3 dinoPos = new Vector3(0, 0, 0);
        Instantiate(dinoPrefab, dinoPos, Quaternion.identity);

        InvokeRepeating("spawnFood", 0f, foodRespawnDelayS);
        InvokeRepeating("spawnCoin", 0f, coinRespawnDelayS);
    }


    void spawnFood()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(17, 55), Random.Range(-30, 30), 0);
        Instantiate(appPrefab, randomSpawnPosition, Quaternion.identity);
            
        randomSpawnPosition = new Vector3(Random.Range(-55, -12), Random.Range(-30, 30), 0);
        Instantiate(watPrefab, randomSpawnPosition, Quaternion.identity);
            
        randomSpawnPosition = new Vector3(Random.Range(-55, 55), Random.Range(-10, 15), 0);
        Instantiate(chiPrefab, randomSpawnPosition, Quaternion.identity); 
    }

    void spawnCoin()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-55, 55), Random.Range(-10, 15), 0);
        Instantiate(coinPrefab, randomSpawnPosition, Quaternion.identity);
    }
}
