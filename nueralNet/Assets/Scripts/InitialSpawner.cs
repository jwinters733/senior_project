using UnityEngine;

public class InitialSpawner : MonoBehaviour
{
    public GameObject foxPrefab;
    public int initialCreatures;
    void Awake()
    {
        for(int i = 0; i < initialCreatures; i++)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(20, 50), Random.Range(0, 25), 0);
            Instantiate(foxPrefab, randomSpawnPosition, Quaternion.identity);
        }
    }
}
