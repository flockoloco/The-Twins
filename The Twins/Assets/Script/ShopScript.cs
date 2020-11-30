using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public GameObject shopCanvas;

    
    // Start is called before the first frame update
    public void Interact()
    {
        shopCanvas.SetActive(true);
        Debug.Log("setting active");
    }
    public void Deinteract()
    {
        shopCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
