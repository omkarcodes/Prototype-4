using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    Vector3 spawnPos;
    float xRange = 8f;
    float zRange = 9f;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-xRange, xRange);
        float spawnPosY = Random.Range(-zRange, zRange);
        spawnPos = new Vector3(spawnPosX, 0, spawnPosY);
        return spawnPos;
    }
}
