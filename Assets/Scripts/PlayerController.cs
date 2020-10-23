using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float jumpForce;
    public Rigidbody2D rb2d;
    public bool canJump;
    public ScoreController scoreController;
    public GameOverController gameOverController;
    public ParticleSystem particleSystem;

    private const float ctox = -0.10f, ctoy = 0.59f,  ctsx = 0.96f, ctsy = 1.30f, cfox = -0.01f, cfoy = 0.99f, cfsx = 0.45f, cfsy = 2.02f;


    public void KillPlayer()
    {
        particleSystem.Play();
        animator.SetBool("Death", true);
        gameOverController.PlayerDied();
        this.enabled = false;
    }


    public void PickUpKey()
    {
        scoreController.IncreaseScore(5);
    }

    private void MoveCharacter(float horizontal) {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
        //AudioManager.Instance.Play(Sounds.PlayerMove);
    }

    private void PlayMovementAnimation(float horizontal) {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

    void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.collider.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }



    void OnCollisionExit2D(Collision2D Other)
    {
        if (Other.collider.gameObject.tag == "Ground")
        {
            canJump = false;

        }
    }


private void FixedUpdate()
    {
        //walk animation
        float horizontal = Input.GetAxisRaw("Horizontal");
        MoveCharacter(horizontal);
        PlayMovementAnimation(horizontal);


        //crouch animation
        BoxCollider2D crouchCollider;
        crouchCollider = GetComponent<BoxCollider2D>();

        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
            crouchCollider.offset = new Vector3(ctox,ctoy);
            crouchCollider.size = new Vector3(ctsx,ctsy);
        }
        else
        {
            animator.SetBool("Crouch", false);
            crouchCollider.offset = new Vector3(cfox,cfoy);
            crouchCollider.size = new Vector3(cfsx,cfsy);
        }

        //jump 
        float jump = Input.GetAxisRaw("Vertical");

        if (jump > 0 && canJump)
        {
            animator.SetBool("Jump", true);
            rb2d.velocity = Vector2.up * jumpForce;
        }
        else
        {
            animator.SetBool("Jump", false);
        }
     }
}
