using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsHolder : MonoBehaviour
{
    public float health;
    public int armor;
    public float damage;
    public float atkspeed;
    public bool invunerable;
    private float vunerableTimer;
    public bool hit;
    void Update()
    {
        if (health < 0)
        {
            Destroy(gameObject);
        }
        if (hit == true)
        {
            invunerable = true;
            vunerableTimer += Time.deltaTime;
            if (vunerableTimer > 1)
            {
                hit = false;
                invunerable = false;
                vunerableTimer = 0;
            }
        }
    }
}
