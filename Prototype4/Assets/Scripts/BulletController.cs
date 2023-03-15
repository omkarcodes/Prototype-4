using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody bulletRb;
    private float bulletSpeed = 100f;

    public GameObject enemy;

    public SpawnManager spawnManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 towardsEnemy = (enemy.transform.position - transform.position).normalized;
        bulletRb.AddForce(towardsEnemy * bulletSpeed);
    }
}
