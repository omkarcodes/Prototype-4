using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 10;
    float powerupStrength = 10;
    Rigidbody playerRb;
    GameObject focalPoint;
    public GameObject powerupIndicator;

    public bool powerUsed;
    // Start is called before the first frame update
    void Start()
    {
        powerupIndicator.SetActive(false);
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * verticalInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            powerUsed = true;
            Destroy(other.gameObject);
            powerupIndicator.SetActive(true);

            StartCoroutine(PowerupCountdown());
        }        
    }

    IEnumerator PowerupCountdown()
    {
        yield return new WaitForSeconds(7);
        powerUsed = false;
        powerupIndicator.SetActive(false);
    }
        

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && powerUsed)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            Debug.Log("collided with: " + collision.gameObject.name + " with powerup set to " + powerUsed);    
        }

        
    }
}
