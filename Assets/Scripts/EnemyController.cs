using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public int direction;
    public Rigidbody2D rb2d;
    public float jumpForce;
    public bool canJump;

    private GameObject heart1;
    private GameObject heart2;
    private GameObject heart3;

    private int deathCounter = 0;

    private void Awake()
    {
        heart1 = GameObject.Find("Heart");
        heart2 = GameObject.Find("Heart (1)");
        heart3 = GameObject.Find("Heart (2)");
    }

    private void FixedUpdate()
    {
        Vector3 targetVelocity = new Vector3(speed * direction * Time.deltaTime, 0, 0);
        animator.SetFloat("Walk", speed);

        if (IsGrounded2D(1, "Ground"))
        {
            targetVelocity.y = jumpForce;
        }
        rb2d.velocity = targetVelocity;


    }
    private void EnemyMovementAnimation()
    {
        Vector3 scale = transform.localScale;
        scale.x = direction * Mathf.Abs(scale.x);
        transform.localScale = scale;

    }

    private bool IsGrounded2D(float rayDistance, string groundLayer)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, rayDistance);

        if (hit.collider && hit.collider.tag == "Ground")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
        

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Edge"))
        {
            EnemyMovementAnimation();
            direction = direction * -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            deathCounter++;

            switch (deathCounter)
            {
                case 1:
                    animator.SetBool("Hurt", true);
                    Destroy(heart3);
                    break;
                case 2:
                    animator.SetBool("Hurt", true);
                    Destroy(heart2);
                    break;
                case 3:
                    GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Health");
                    foreach (GameObject target in gameObjects)
                    {
                        GameObject.Destroy(target);
                    }
                    animator.SetBool("Death", true);
                    playerController.Invoke("KillPlayer", 1f);
                    break;
                default:
                    break;
            }


            
        }

    }
}
    
    

