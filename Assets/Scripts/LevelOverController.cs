using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Scene scene = SceneManager.GetActiveScene();

        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {

            if (scene.buildIndex == 1) 
            {
                SceneManager.LoadScene(2);
            }
            else 
            { 
                SceneManager.LoadScene(3); 
            }

            if (scene.buildIndex == 3) 
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
