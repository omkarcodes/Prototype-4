﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 10f;
    Rigidbody playerRb;
    GameObject focalPoint;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(focalPoint.transform.forward * speed * verticalInput);
    }
}
