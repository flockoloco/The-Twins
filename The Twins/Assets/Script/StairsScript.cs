using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsScript : MonoBehaviour
{
    public bool playerInside;
    private bool used = false;
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
            //go to next level (generate a new one maybe in a new scene?)
        }
    }
}
