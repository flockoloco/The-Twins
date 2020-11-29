using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
   
    // Start is called before the first frame update
    public void Continue()
    {
        
    }
    public void StartNewGame()
    {
        SceneManager.LoadScene("Main Game");
    }
    public void Login()
    {
        Debug.Log("LMAOs");
    }
    public void Options()
    {
        Debug.Log("uhhga booga"); //fazer novo canvas
    }
    public void Exit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
