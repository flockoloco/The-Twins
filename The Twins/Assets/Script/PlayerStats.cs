using System.Collections;
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
    public float bowDamage;
    public bool hit;
    public bool invunerable;
    private float vunerableTimer;


    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            //Death();
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