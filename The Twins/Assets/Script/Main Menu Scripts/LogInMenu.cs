using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogInMenu : MonoBehaviour
{
    

    public void PlayerOffline()
    {

    }
    public void GoToRegister()
    {

    }
    public void Login()
    {
        GameObject.FindWithTag("GameManager").GetComponent<GameManagerScript>().LoginPlayer("aaa", "a");
    }
}
