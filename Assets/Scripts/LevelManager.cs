using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public GameObject player;
    
    public GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void LoadScene(string name)
    {
        SceneManager.sceneLoaded += OnSceneLoad;
        
        if (name == "Grass_LVL")
        {
            gameManager.gameState = GameManager.GameState.Gameplay;
        }
        else if (name == "Grass_LVL2")
        {
            gameManager.gameState = GameManager.GameState.Gameplay;
        }
        else if (name == "MainMenu")
        {
            gameManager.gameState= GameManager.GameState.MainMenu;
        }
        else if (name == "WinningScene")
        {
            gameManager.gameState = GameManager.GameState.GameWin;
        }
        SceneManager.LoadScene(name);
    }
    
    public void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (player && player.activeSelf)
        {
        player.transform.position = GameObject.FindWithTag("PlayerSpawn").transform.position;
        SceneManager.sceneLoaded -= OnSceneLoad;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
