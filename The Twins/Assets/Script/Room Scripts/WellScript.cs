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