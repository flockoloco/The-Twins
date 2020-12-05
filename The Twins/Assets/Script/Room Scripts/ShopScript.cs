using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public GameObject shopCanvas;
    public bool playerInside = false;
    public bool oneTime = true;

    void Awake()
    {
        shopCanvas = GameObject.FindWithTag("ShopCanvas");
    }
    public void Interact()
    {
        shopCanvas.SetActive(true);
        shopCanvas.GetComponent<ShopMenuScript>().Activate();
        Debug.Log("setting active");
    }
    public void Deinteract()
    {
        shopCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInside == true && oneTime == true)
        {
            oneTime = false;
            Interact();


        } else if (playerInside == false && oneTime == false)
        {
            Deinteract();
            oneTime = true;
        }
    }
}
