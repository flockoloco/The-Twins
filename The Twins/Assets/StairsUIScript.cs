using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsUIScript : MonoBehaviour
{
    public GameObject player;
    public GameObject stairsMenu;
    private GameManagerScript gameManager;
    public GameObject popUpPrefab;

    private void Start()
    {
        Debug.Log("Inside of the start, " + stairsMenu);
        stairsMenu.SetActive(false);
        player = GameObject.FindWithTag("Player");
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManagerScript>();
    }

    public void Activate()
    {
        Debug.Log("inside the activate");
        stairsMenu.SetActive(true);
    }

    public void Continue()
    {
        gameManager.GetComponent<StartGameScript>().GenLevel(player.GetComponent<PlayerStats>().currentLevel + 1);
        player.GetComponent<PlayerStats>().currentLevel += 1;
        stairsMenu.SetActive(false);
    }
    public void SaveAndExit()
    {
        if (gameManager.GetComponent<GameManagerScript>().logged == true)
        {
            player.GetComponent<PlayerStats>().currentLevel += 1;

            gameManager.GetComponent<GameManagerScript>().SaveEnchants();
            gameManager.GetComponent<GameManagerScript>().SaveRunInfo();
            gameManager.GetComponent<GameManagerScript>().SaveBarsAndOres();

            Application.Quit();
        }
        else if (gameManager.GetComponent<GameManagerScript>().logged == false)
        {
            GameObject popUp = Instantiate(popUpPrefab, stairsMenu.transform);
            popUp.transform.position = new Vector3(popUp.transform.position.x, popUp.transform.position.y - 300, popUp.transform.position.z);
            popUp.GetComponent<DialogScript>().GiveText("Can't save offline");

        }
    }
}
