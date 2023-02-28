using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    float spawnRange = 9;
    
    // Start is called before the first frame update
    void Start()
    {

        Instantiate(powerupPrefab,new Vector3(0,0,6), powerupPrefab.transform.rotation);
        InvokeRepeating("SpawnEnemy", 1.5f, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange); 
        float spawnPosY = Random.Range(-spawnRange, spawnRange);

        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosY);
        return spawnPos;
    }
}
