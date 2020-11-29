using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainScript : MonoBehaviour
{
    private bool used = false;
    public void Interact()
    {
        if (used == false)
        {
            used = true;
            GameObject.FindWithTag("Player").GetComponent<PlayerStats>().health = GameObject.FindWithTag("Player").GetComponent<PlayerStats>().maxHealth;
        }
    }
}
