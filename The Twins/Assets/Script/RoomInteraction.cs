using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInteraction : MonoBehaviour
{
    public GameObject player;
    public Sprite normalSprite;
    public Sprite glowSprite;
    public SpriteRenderer spriteRenderer;
    public bool ableToInteract = true;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            spriteRenderer.sprite = glowSprite;
            if (gameObject.tag == "Shop")
            {
                GameObject.FindWithTag("ShopCanvas").GetComponent<ShopMenuScript>().Activate();    
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && ableToInteract == true)
        {
            
            if (Input.GetKey(KeyCode.E))
            {
                ableToInteract = false;
                Debug.Log("pressing E");
                
                if (gameObject.tag == "Fountain")
                {
                    Debug.Log("trying to give helath");
                    gameObject.GetComponent<FountainScript>().Interact();
                }
                else if (gameObject.tag == "Enchantments")
                {

                }
                else if (gameObject.tag == "Well")
                {

                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ableToInteract = true;
        if (collision.tag == "Player")
        {
            spriteRenderer.sprite = normalSprite;
            if (gameObject.name == "Shop")
            {
                GameObject.FindWithTag("ShopCanvas").GetComponent<ShopMenuScript>().DeActivate();
            }

        }

    }
}