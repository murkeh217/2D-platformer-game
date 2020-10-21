using System.Collections;
using UnityEngine;

public class ToNextLevel : MonoBehaviour
{[SerializeField]
    public void Transition() 
    {
        gameObject.SetActive(true);
        StartCoroutine(TransitionDelay());

    }
    IEnumerator TransitionDelay()
    {
        yield return new WaitForSeconds(3f);
        LevelManager.Instance.MarkCurrentLevelComplete();
    }
}
