using UnityEngine;


public class DeathController : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            animator.SetBool("Death",true);
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.killPlayer();
        }
    }
}
