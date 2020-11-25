using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private float health;
    private float maxHealth;
    private float swordAtkSpeed;
    private float bowAtkSpeed;
    private int armor;


    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            //Death();
        }
    }
    

}
