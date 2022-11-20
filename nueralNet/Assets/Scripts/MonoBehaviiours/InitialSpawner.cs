using UnityEngine;

public class InitialSpawner : MonoBehaviour
{
    public GameObject foxPrefab;
    public GameObject appPrefab;
    public GameObject watPrefab;
    public GameObject chiPrefab;
    public GameObject coinPrefab;
    public int initialFood;
    public int initialCoins;
    public int spawnDelay;

    private int countDown;

    public int initialCreatures;
    void Awake()
    {
        countDown = spawnDelay;

        for (int i = 0; i < initialCreatures; i++)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(20, 50), Random.Range(0, 25), 0);
            Instantiate(foxPrefab, randomSpawnPosition, Quaternion.identity);
        }

        for (int i = 0; i < initialFood; i++)
        { 
            if (i % 3 == 0)
            {
                Vector3 randomSpawnPosition = new Vector3(Random.Range(-55, -12), Random.Range(-30, 30), 0);
                Instantiate(appPrefab, randomSpawnPosition, Quaternion.identity);
            } else if (i % 3 == 1)
            {
                Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 50), Random.Range(-7, 13), 0);
                Instantiate(watPrefab, randomSpawnPosition, Quaternion.identity);
            } else
            {
                Vector3 randomSpawnPosition = new Vector3(Random.Range(-30, 50), Random.Range(-7, 13), 0);
                Instantiate(chiPrefab, randomSpawnPosition, Quaternion.identity);
            }
        }

        for (int i = 0; i < initialCoins; i++)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-55, -12), Random.Range(-30, 30), 0);
            Instantiate(coinPrefab, randomSpawnPosition, Quaternion.identity);
        }

    }

    void FixedUpdate()
    {
        countDown--;
        if(countDown == 0)
        {
            int i = Random.Range(0, 3);
            if (i % 3 == 0)
            {
                Vector3 randomSpawnPosition = new Vector3(Random.Range(-55, -12), Random.Range(-30, 30), 0);
                Instantiate(appPrefab, randomSpawnPosition, Quaternion.identity);
            }
            else if (i % 3 == 1)
            {
                Vector3 randomSpawnPosition = new Vector3(Random.Range(-55, -12), Random.Range(-30, 30), 0);
                Instantiate(watPrefab, randomSpawnPosition, Quaternion.identity);
            }
            else
            {
                Vector3 randomSpawnPosition = new Vector3(Random.Range(-30, 50), Random.Range(-7, 13), 0);
                Instantiate(chiPrefab, randomSpawnPosition, Quaternion.identity);
            }
            countDown = spawnDelay;
            Vector3 spawnPos = new Vector3(Random.Range(-55, -12), Random.Range(-30, 30), 0);
            Instantiate(coinPrefab, spawnPos, Quaternion.identity);
        }
    }
}
