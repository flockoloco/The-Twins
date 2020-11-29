using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInteraction : MonoBehaviour
{
    public GameObject player;
    public Sprite normalSprite;
    public Sprite glowSprite;
    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            spriteRenderer.sprite = glowSprite;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        { 
            if (gameObject.name == "Shop")
            {
                gameObject.GetComponent<ShopScript>().Interact();
            }
            else if (gameObject.name == "Fountain")
            {
                gameObject.GetComponent<FountainScript>().Interact();
            }
            else if (gameObject.name == "Enchantments")
            {

            }
            else if (gameObject.name == "Well")
            {

            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            spriteRenderer.sprite = normalSprite;
        }
    }
}