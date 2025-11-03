using UnityEngine;
using UnityEngine.SceneManagement;
public class EsPedras : MonoBehaviour
{
    [SerializeField]
    private GameObject saveIcon;
    private bool onTrigger;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        { 
            saveIcon.SetActive(true);
            onTrigger = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            saveIcon.SetActive(false);
            onTrigger = false;
        }

    }

    private void Update()
    {
        if (onTrigger == true)
        {
            if (Input.GetAxis("Vertical") > 0.5f)
            {
                GameManager.instance.GetGameData.SceneSave = SceneManager.GetActiveScene().buildIndex;
                GameManager.instance.SaveGame();
                onTrigger = false;
            }
        }
    }

}
