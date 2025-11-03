using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{


    [SerializeField]
    private GameObject panelSlots;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        panelSlots.SetActive(true);    
    }

    public void SlotButton(int _slot)
    {
        if (PlayerPrefs.HasKey("data" + _slot.ToString()))
        {
            GameManager.instance.slot = _slot;
            GameManager.instance.LoadGame();
            SceneManager.LoadScene(GameManager.instance.GetGameData.SceneSave);
        }
        else
        {
            GameManager.instance.GetGameData=new GameData();
            GameManager.instance.slot = _slot;
            GameManager.instance.GetGameData.PlayerLife = 100;
            GameManager.instance.GetGameData.PlayerMaxLife = 100;
            GameManager.instance.GetGameData.PlayerMana = 50;
            GameManager.instance.GetGameData.PlayerMaxMana = 50;
            GameManager.instance.GetGameData.PlayerDamage = 10;
            GameManager.instance.GetGameData.FireBallDamage = 5;
            GameManager.instance.GetGameData.BigAttackDamage = 15;

            SceneManager.LoadScene(1);
        }


    }
}
