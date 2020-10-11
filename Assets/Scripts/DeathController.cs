using UnityEngine;


public class DeathController : MonoBehaviour
{
    public int deathCounter = 0;
    public Animator animator;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    private void Awake()
    {
        heart1 = GameObject.Find("Heart");
        heart2 = GameObject.Find("Heart (1)");
        heart3 = GameObject.Find("Heart (2)");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        { 
            
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            deathCounter = 3;
            if (deathCounter >= 3)
            {
                animator.SetBool("Death", true);
                playerController.killPlayer();
            }
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Health");
            foreach (GameObject target in gameObjects)
            {
                GameObject.Destroy(target);
            }
            
        }
    }
}
