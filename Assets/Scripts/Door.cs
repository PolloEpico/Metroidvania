using UnityEngine;
using UnityEngine.SceneManagement;

public class d : MonoBehaviour
{
    [SerializeField]
    private int sceneToGo;
    [SerializeField]
    private int doorPoint;
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.doorToGo = doorPoint;
            SceneManager.LoadScene(+1);
        }
    }
}
