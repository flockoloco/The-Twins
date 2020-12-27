using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellScript : MonoBehaviour
{
   public bool playerInside;
    private bool used = false;
    private GameObject player;
    private PlayerMovement playerMovement;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (playerInside && Input.GetKey(KeyCode.E))
        {
            Interact();
        }
    }

    public void Interact()
    {
        if (used == false)
        {
            used = true;

            
            GameObject.FindWithTag("Player").GetComponent<PlayerStats>().shopOpen = false;



            //go to next level (generate a new one maybe in a new scene?)
        }
    }
}