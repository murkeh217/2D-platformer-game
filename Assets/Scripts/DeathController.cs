using UnityEngine;


public class DeathController : MonoBehaviour
{
    public static int deathCounter;
    public Animator animator;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public static int health;
    public ParticleSystem particleSystem;
    
    private void Awake()
    {
        heart1 = GameObject.Find("Heart");
        heart2 = GameObject.Find("Heart (1)");
        heart3 = GameObject.Find("Heart (2)");
        GameObject[] hearts = GameObject.FindGameObjectsWithTag("Health");
        health = hearts.Length;
    }

 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        { 
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            deathCounter = 3;
            if (deathCounter >= 3)
            {
                GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Health");
                foreach (GameObject target in gameObjects)
                {
                    GameObject.Destroy(target);
                }
                particleSystem.Play();
                animator.SetBool("Death", true);
                playerController.Invoke("KillPlayer", 1f);
                
            }
        }
    }
}
