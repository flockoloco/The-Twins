using System.Collections;
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
    public static void BuySomething(GameObject player,string type,int cost)
    {
        if (type == "gold")
        {
            if (player.GetComponent<PlayerStats>().gold > cost)
            {
                player.GetComponent<PlayerStats>().gold -= cost;
                //add item
            }
        }else if (type == "bars")
        {
            if (player.GetComponent<PlayerStats>().bars > cost)
            {
                player.GetComponent<PlayerStats>().bars -= cost;
                //add item
            }else if (player.GetComponent<PlayerStats>().nuggets > (cost * 5))
            {
                player.GetComponent<PlayerStats>().nuggets -= (cost * 5);
                //add item
            }
        }
    }
    public static void SpawnDrops(int tier)
    {

        if (tier == 1)
        {
        //    GameObject drops = Instantiate(BulletPrefab, new Vector3(transform.position.x + (direction.x * 2), transform.position.y + (direction.y * 2), 0), transform.rotation);

        }

    }
}
