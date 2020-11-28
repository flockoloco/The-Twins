using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    private int arrowDamage;
    public void ArrowDamage(int damage)
    {
        arrowDamage = damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && collision.gameObject.GetComponent<StatsHolder>().invunerable == false)
        {
            UsefulllFs.TakeDamage(collision.gameObject, arrowDamage);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * 0; //reseting velocity right before doing the knockback

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(gameObject.GetComponent<Rigidbody2D>().velocity.normalized * 5, ForceMode2D.Impulse); //knocking the target towards the projectiles velocity
            Destroy(gameObject);
        }
        if (collision.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
