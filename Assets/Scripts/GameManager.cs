using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GameData gameData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameData GetGameData
    {
        set { return gameData; }
        set { gameData = value; }
    }
}
