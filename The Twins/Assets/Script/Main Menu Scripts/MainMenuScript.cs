using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TheTwins.Model;

public class MainMenuScript : MonoBehaviour
{
    public GameObject gameManager;
    private PlayerStatsHolder playerStats;
    private bool disableContinue = true;
    public void Start()
    {
        if (gameManager.GetComponent<GameManagerScript>().logged == true)
        {
            disableContinue = false;
        }
        else
        {
            disableContinue = true;
        }
    }
    public void Continue()
    {
        if (disableContinue == true)
        {
            Debug.Log("ur not logged in rEEEEEEEEEEEEEEEEEEEeee");
        }else if (disableContinue == false)
        {
            Debug.Log("go into game");//switch scene.
        }
    }
    public void StartNewGame()
    {
        
        SceneManager.LoadScene("Level Generator");
        gameManager.GetComponent<GameManagerScript>().statsToUse = new PlayerStatsHolder();
    }
    public void Options()
    {
        Debug.Log("uhhga booga"); //canvas feito so ir buscar
    }
    public void Exit()
    {
        Application.Quit();
    }
}
