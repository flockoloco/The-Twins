using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenuScript : MonoBehaviour
{
    public GameObject shopMenu;
    // Start is called before the first frame update
    private void Awake()
    {
        shopMenu.SetActive(false);
    }
    void Start()
    {
        
    }
    public void Activate()
    {
        shopMenu.SetActive(true);
    }
    public void DeActivate()
    {
        shopMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
