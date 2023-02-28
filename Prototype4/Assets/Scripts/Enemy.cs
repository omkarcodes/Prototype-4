﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float speed = 3f;
    Rigidbody enemyRb;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 enemyMovement = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(enemyMovement * speed);
    }
}
