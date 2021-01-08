using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameKIckStarter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindWithTag("GameManager").GetComponent<StartGameScript>().StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
