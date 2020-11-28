﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsefulllFs
{
    public static Vector2 Dir (Vector2 pos1, Vector2 pos2, bool normalize)
    {
       Vector2 response = new Vector2(pos2.x - pos1.x, pos2.y - pos1.y);
        if (normalize == true)
        {
            response = response.normalized;
        }
        return response;
    }
    public static float Dist(Vector2 pos1, Vector2 pos2)
    {
        return Mathf.Sqrt(((pos2.x - pos1.x) * (pos2.x - pos1.x)) + ((pos2.y - pos1.y) * (pos2.y - pos1.y)));
    }
    public static void TakeDamage(GameObject target, float dealerDamage)
    {
        if (target.tag == "Player")
        {

            target.GetComponent<PlayerStats>().health -= (dealerDamage - (target.GetComponent<PlayerStats>().armor/2));
            target.GetComponent<PlayerStats>().hit = true;
        }
        else if (target.tag == "Enemy") 
        {
            target.GetComponent<StatsHolder>().health -= (dealerDamage - (target.GetComponent<StatsHolder>().armor / 2));
            target.GetComponent<StatsHolder>().hit = true;
        }
    }
}