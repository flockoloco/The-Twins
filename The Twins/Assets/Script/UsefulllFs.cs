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
    public static void TakeDamage(GameObject target, GameObject dealer)
    {
        // if (tag == player)
        //{
        //    target.GetComponent<PlayerStats>() blaaaaaa
        //}else if tag == EnemyAI{
        //    target.GetComponent<StatsHolder>()
        //}

        //stats.aaaaaaaaaaaaaaa = 3;
        //if (target.health && target.health)
        //{
        //    target.health = target.health - (damage - target.armor / 2);
        //}
    }
}
