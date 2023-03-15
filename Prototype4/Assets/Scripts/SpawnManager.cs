using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject[] powerUp;

    Vector3 spawnPos;

    float xRange = 8f;
    float zRange = 9f;

    int enemyCount;
    int waveNumber;
    public int index;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWaves(waveNumber);
            int index = Random.Range(0, powerUp.Length);
            Instantiate(powerUp[index], GenerateSpawnPosition(), powerUp[index].transform.rotation);
        }
    }
    
    Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-xRange, xRange);
        float spawnPosY = Random.Range(-zRange, zRange);
        spawnPos = new Vector3(spawnPosX, 0, spawnPosY);
        return spawnPos;
    }

    public void SpawnEnemyWaves(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            index = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[index], GenerateSpawnPosition(), enemyPrefab[index].transform.rotation);
        }
    }
}
