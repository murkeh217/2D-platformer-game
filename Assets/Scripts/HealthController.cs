using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    /* public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    public GameObject gameOver;
    public int deathCounter;

    private void Awake()
    {
        heart1 = GameObject.Find("Heart");
        heart2 = GameObject.Find("Heart(1)");
        heart3 = GameObject.Find("Heart(2)");

        gameOver = GameObject.Find("GameOver");
    }
    /* private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 respawner = new Vector3(0, 0, 0);

        if (collision.collider.gameObject.CompareTag("Respawn Trigger")) 
        {
            deathCounter += 1;
            transform.position = respawner;

            if (deathCounter == 1) 
            {
                Destroy(heart1);
            }
            if (deathCounter == 2) 
            { 
                Destroy(heart2); 
            }
            if (deathCounter == 3) 
            {
                Destroy(heart3); 
            }
            if (deathCounter == 3) 
            {
                Destroy(gameObject); 
                Instantiate(gameOver, respawner, Quaternion.identity); 
            }
        }
    }*/
}
