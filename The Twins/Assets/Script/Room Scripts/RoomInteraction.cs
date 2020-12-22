﻿using System.Collections;
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
        player = GameObject.FindWithTag("Player");
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && ableToInteract == true)
        {
            GameObject.FindWithTag("MainCamera").GetComponent<cameramovement>().shopOpen = true;
            ableToInteract = false;
            spriteRenderer.sprite = glowSprite;
            if (gameObject.tag == "Shop")
            {
                gameObject.GetComponent<ShopScript>().playerInside = true;
            }
            else if (gameObject.tag == "Fountain")
            {
                gameObject.GetComponent<FountainScript>().playerInside = true;
            }
            else if (gameObject.tag == "Stairs")
            {
                gameObject.GetComponent<StairsScript>().playerInside = true;
            }
            else if (gameObject.tag == "Enchantment")
            {
                gameObject.GetComponent<EnchantsScript>().playerInside = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        { 
            GameObject.FindWithTag("MainCamera").GetComponent<cameramovement>().shopOpen = false;
            ableToInteract = true;
            spriteRenderer.sprite = normalSprite;
            if (gameObject.tag == "Shop")
            {
                gameObject.GetComponent<ShopScript>().playerInside = false;
            }
            else if (gameObject.tag == "Fountain")
            {
                gameObject.GetComponent<FountainScript>().playerInside = false;
            }
            else if (gameObject.tag == "Stairs")
            {
                gameObject.GetComponent<StairsScript>().playerInside = false;
            }
            else if (gameObject.tag == "Enchantment")
            {
               gameObject.GetComponent<EnchantsScript>().playerInside = false;
            }
        }
    }
}