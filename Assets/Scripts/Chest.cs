using UnityEngine;

public class Chest : MonoBehaviour
{

    private bool inTrigger;
    [SerializeField]
    private GameObject iconUI;
    private Animator animator;
    [SerializeField]
    private string gemaName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        switch (gemaName)
        {

            case "DobleSalto":
                if (GameManager.instance.GetGameData.MaxJumps > 1)
                { 
                GetComponent<Collider2D>().enabled = false;
                }

                break;
            case "TripleSalto":

                break;
            case "Dash":

                break;
            case "ExtraDamage":

                break;
            default:

                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(inTrigger == true)
        {
            iconUI.SetActive(true);   
            if (Input.GetButtonDown("Action"))
            {
               
                animator.SetTrigger("Abrir");
                iconUI.SetActive(false);
                Time.timeScale = 0;
            }

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inTrigger = true;
        
        }
    }


    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }

    public void ObtenerGema()
    {

        switch (gemaName)
        {

            case "DobleSalto":
                GameManager.instance.GetGameData.MaxJumps = 2;
                break;
            case "TripleSalto":
                
                break ;
            case "Dash":
                
                break ;
            case "ExtraDamage":
                
                break ;
            default:
                
                break;
        }

        Time.timeScale = 1;
        transform.GetChild(0).gameObject.SetActive(false);
        GetComponent<Collider2D>().enabled = false;
    }

}
