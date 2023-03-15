using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody enemyRb;
    GameObject player;
    private float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        
    }
    
    // Update is called once per frame
    void Update()
    {
        LookDirectionAndMovement();
        DestroyOutOBounds();
    }

    public void LookDirectionAndMovement()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
    }

    public void DestroyOutOBounds()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }


}
