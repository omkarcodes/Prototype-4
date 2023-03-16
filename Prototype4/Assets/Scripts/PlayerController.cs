using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //floats 
    public float verticalInput;
    private float speed = 5f;
    private float powerupStrength = 30f;
    

    //Vectors
    private Vector3 positionOffset;

    //Rigidbodys
    private Rigidbody playerRb;
    

    //GameObjects
    private GameObject focalPoint;
    public GameObject powerUpIndicator;
    
    
    
    //Booleans
    public bool hasPowerUp = false;

    //Scripts
    

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
        powerUpIndicator.transform.position = transform.position + positionOffset; // Setting the position of the power indicator
        verticalInput = Input.GetAxis("Vertical"); 

        playerRb.AddForce(focalPoint.transform.forward * speed * verticalInput); // Getting the input to move the player

        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Power Up"))
        {
            powerUpIndicator.SetActive(true); //On collision with the powerup set the powerup indicator active
            hasPowerUp = true; // setting the has power up to true
            Destroy(other.gameObject); //destroying the powerup as soon as the player collects it

            

            StartCoroutine(PowerUpCountDownRoutine());  // keeping the time of the powerup till 7 seconds
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
