﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float health = 5;
    public float maxHealth;
    public float swordAtkSpeed;
    public float bowAtkSpeed;
    public int armor = 8;
    public float swordDamage = 2;
    public int bowDamage;
    public bool hit;
    public bool invunerable;
    public int gold;
    public int bars;
    public int nuggets;
    private float vunerableTimer;

    private PauseMenu pauseMenu;

    private void Awake()
    {
        //pauseMenu = GameObject.FindWithTag("PauseUI").GetComponent<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            pauseMenu.ResetGame();
        }

        if (hit == true)
        {
            invunerable = true;
            if (vunerableTimer == 0)
            {
                gameObject.GetComponent<PlayerMovement>().state = PlayerMovement.State.hit;
            }
            vunerableTimer += Time.deltaTime;
            if (vunerableTimer > 2 && vunerableTimer < 4)
            {
                if (gameObject.GetComponent<PlayerMovement>().state == PlayerMovement.State.hit)
                {
                    gameObject.GetComponent<PlayerMovement>().state = PlayerMovement.State.walking;
                }
            }
            if (vunerableTimer > 4)
            {
                invunerable = false;
                hit = false;

                vunerableTimer = 0;
            }
        }
    }
}