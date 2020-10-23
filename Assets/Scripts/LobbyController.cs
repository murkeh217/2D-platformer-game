using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    public GameObject LevelSelection;
    public static int currentSceneIndex;

    private void Awake()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void Update() 
    {
    }
    public void BackToMenu()
    {
        SaveData();
        SceneManager.LoadScene(0);
    }
    public void StartGame()
    {
        AudioManager.Instance.Play(Sounds.ButtonClick);
        LevelData data = SaveSystem.LoadData();
        LoadData(data);
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void SelectLevel()     
    {
        LevelSelection.SetActive(true);
    }


    public void SaveData()
    {
        SaveSystem.SaveData(this);
    }
    public void LoadData(LevelData data)
    {
        currentSceneIndex = data.level;
    }

}
