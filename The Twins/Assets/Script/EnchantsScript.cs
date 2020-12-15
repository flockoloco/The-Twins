using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnchantsScript : MonoBehaviour
{
    public GameObject enchantCanvas;
    public bool playerInside = false;
    public bool oneTime = true;

    void Awake()
    {
        enchantCanvas = GameObject.FindWithTag("EnchantCanvas");
    }
    public void Interact()
    {
        Debug.Log("setting active");
        enchantCanvas.SetActive(true);
        enchantCanvas.GetComponent<EnchantMenuScript>().Activate();

    }
    public void Deinteract()
    {
        enchantCanvas.SetActive(false);
    }

    // Update is called once per frame
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
}
