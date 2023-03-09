using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 10f;
    float powerupStrength = 30f;
    Vector3 positionOffset;
    Rigidbody playerRb;
    GameObject focalPoint;
    public GameObject powerUpIndicator;
    public bool hasPowerUp = false;
    // Start is called before the first frame update
    void Start()
    {
        powerUpIndicator.SetActive(false);
        playerRb = GetComponent<Rigidbody>();

        focalPoint = GameObject.Find("FocalPoint");
        
    }

    // Update is called once per frame
    void Update()
    {
        positionOffset = new Vector3(0, -0.5f, 0);
        powerUpIndicator.transform.position = transform.position + positionOffset;
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(focalPoint.transform.forward * speed * verticalInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Power Up"))
        {
            powerUpIndicator.SetActive(true);
            hasPowerUp = true;
            Destroy(other.gameObject);
            
            StartCoroutine(PowerUpCountDownRoutine());
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            Debug.Log("player collied with the enemy");
            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            
        }
    }

    IEnumerator PowerUpCountDownRoutine()
    {
        yield return new WaitForSeconds(7);
        powerUpIndicator.SetActive(false);
        hasPowerUp = false;
    }
}
