using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellScript : MonoBehaviour
{
    public bool playerInside;
    private GameObject player;
    private bool oneTime = true;
    public GameObject WellCanvas;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        
    }
    void Awake()
    {
        WellCanvas = GameObject.FindWithTag("WellCanvas");
    }
    public void Interact()
    {
        WellCanvas.SetActive(true);
        WellCanvas.GetComponent<WellMenuScript>().Activate();
        Debug.Log("setting active");
        GameManagerScript manager = GameObject.FindWithTag("GameManager").GetComponent<GameManagerScript>();
        manager.SaveBarsAndOres();
        // mandar para o server saveCurrency()
        // no script do canvas mandar o send para o email currency
        // subtrair o email currency ao currency


    }

    void Update()
    {
        if (playerInside == true && oneTime == true)
        {
            oneTime = false;
            Interact();


        }
        else if (playerInside == false && oneTime == false)
        {
            Deinteract();
            oneTime = true;
        }
    }

   
    public void Deinteract()
    {
        WellCanvas.SetActive(false);
    }

}