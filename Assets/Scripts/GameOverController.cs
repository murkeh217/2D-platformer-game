using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;

    public void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadLevel);
    }
    public void PlayerDied() 
    {
        gameObject.SetActive(true);
        
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
