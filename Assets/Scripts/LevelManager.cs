using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Image lifeBar;
    [SerializeField]
    private Image manaBar;
    [SerializeField]
    private Transform[] doorPoints;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
        GameObject.FindGameObjectWithTag("Player").transform.position = 
            doorPoints[GameManager.instance.doorToGo].position;
        GameObject.FindGameObjectWithTag("Player").transform.rotation =
            doorPoints[GameManager.instance.doorToGo].rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void UpdateLife()
    {
        lifeBar.fillAmount = GameManager.instance.GetGameData.PlayerLife / GameManager.instance.GetGameData.PlayerMaxLife;


    }

    public void UpdateMana()
    {

        manaBar.fillAmount = GameManager.instance.GetGameData.PlayerMana / GameManager.instance.GetGameData.PlayerMaxMana;
    
    }





}
