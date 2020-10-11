using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public int direction;
    public Rigidbody2D rb2d;
    public float jumpForce;
    public bool canJump;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    private int deathCounter = 0;

    private void Awake()
    {
        heart1 = GameObject.Find("Heart");
        heart2 = GameObject.Find("Heart (1)");
        heart3 = GameObject.Find("Heart (2)");
    }

    private void MoveEnemy()
    {
        Vector3 position = transform.position;
        position.x -= speed * direction * Time.deltaTime;
        transform.position = position;
        animator.SetFloat("Walk", position.x);
    }

    private void FixedUpdate()
    {
        MoveEnemy();
        if (IsGrounded2D(1,"Ground"))
        {
            rb2d.velocity = Vector2.up * jumpForce;
        }
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
        private void EnemyMovementAnimation()
    {
        Vector3 scale = transform.localScale;
        scale.x = -direction * Mathf.Abs(scale.x);
        transform.localScale = scale;

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

            if (deathCounter == 1)
            {
                Destroy(heart3);
            }
            if (deathCounter == 2)
            {
                Destroy(heart2);
            }
            if (deathCounter == 3)
            {
                Destroy(heart1);
            }

            if (deathCounter >= 3)
            {
                animator.SetBool("Death", true);
                playerController.killPlayer();
            }
            //Destroy(playerController);

        }

    }
}
    
    

