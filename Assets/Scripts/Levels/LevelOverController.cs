using UnityEngine;

public class LevelOverController : MonoBehaviour
{
    public ToNextLevel toNextLevel;
    public void Awake()
    {
        toNextLevel = GameObject.Find("gameObject").GetComponent<ToNextLevel>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            toNextLevel.Transition(); 
        }
    }
}
