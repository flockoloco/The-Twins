using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    int bulletDamage;

    public void EnemyDamage(int damage)
    {
        bulletDamage = damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.gameObject.GetComponent<PlayerStats>().invunerable == false)
        {
            UsefulllFs.TakeDamage(collision.gameObject, bulletDamage);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right *0; //reseting velocity right before doing the knockback
            
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(gameObject.GetComponent<Rigidbody2D>().velocity.normalized * 5 , ForceMode2D.Impulse); //knocking the target towards the projectiles velocity
            Destroy(gameObject);
        }
        if (collision.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
