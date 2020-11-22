using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerPos;
    private Rigidbody2D rigidbody;
    public GameObject BulletPrefab;

    private readonly float agroDist = 4;

    private float atkCooldown;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        playerPos = player.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    { 
        //cds


        if (PlayerToEnemyDist(playerPos,transform.position) < agroDist)
        {
            Debug.Log("hey");
            rigidbody.velocity = new Vector2 (PlayerToEnemyDir(playerPos,transform.position).x * -4, PlayerToEnemyDir(playerPos, transform.position).y * -4);
        }
        else
        {
            Vector2 direction = PlayerToEnemyDir(playerPos, transform.position);
            float bulletSpeed = 15;
            GameObject bullet = Instantiate(BulletPrefab, new Vector3(transform.position.x + (direction.x * 2 ), transform.position.y + (direction.y * 2), 0), transform.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
        }
    }
   
    private float PlayerToEnemyDist(Vector3 pPos,Vector3 ePos)
    {
        return Mathf.Sqrt((ePos.x - pPos.x)* (ePos.x - pPos.x) + (ePos.y - pPos.y) * (ePos.y - pPos.y));
    }
    private Vector2 PlayerToEnemyDir(Vector3 pPos, Vector3 ePos)
    {
        return new Vector2(ePos.x - pPos.x,ePos.y - pPos.y).normalized;
    }   
}
