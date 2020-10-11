using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
    public Button b1, b2, b3;
    public void LoadSceneOnClick(int sceneNo)
    {
        SceneManager.LoadScene(sceneNo);
    }
}
