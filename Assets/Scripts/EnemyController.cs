using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public int direction;
    public Rigidbody2D rb2d;
    public float jumpForce;
    public bool canJump;

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
            playerController.killPlayer();
            //Destroy(playerController);

        }

    }
}
    
    

