using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    private GameOverController gameOverController;

    public static LevelManager Instance
    {
        get 
        {
            return instance;
        } 
    }

    public string[] Levels;

    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start() 
    {
        if (GetLevelStatus(Levels[0]) == LevelStatus.Locked) 
        {
            SetLevelStatus(Levels[0], LevelStatus.Unlocked);
        }
    }
  

    public void MarkCurrentLevelComplete()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        
        SetLevelStatus(currentScene.name, LevelStatus.Completed);
       
        int currentSceneIndex = Array.FindIndex(Levels, level => level == currentScene.name);
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex < Levels.Length) 
        {
            SetLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
        }

        switch (currentScene.buildIndex)
        {
            case 1:
                AudioManager.Instance.Play(Sounds.LevelSound);
                SceneManager.LoadScene(2);
                break;
            case 2:
                AudioManager.Instance.Play(Sounds.LevelSound);
                SceneManager.LoadScene(3);
                break;
            case 3:
                AudioManager.Instance.Play(Sounds.LevelSound);
                SceneManager.LoadScene(4);
                break;
            case 4:
                AudioManager.Instance.Play(Sounds.LevelSound);
                SceneManager.LoadScene(5);
                break;
            case 5:
                AudioManager.Instance.Play(Sounds.LevelSound);
                gameOverController.PlayerDied();
                break;
        }

    }

    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }
    public void SetLevelStatus(string level, LevelStatus levelStatus) 
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
        Debug.Log("Setting level: "+level+"Level Status: "+levelStatus);
    }
}