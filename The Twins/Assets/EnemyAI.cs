using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerPos;
    private Rigidbody2D rigidbody;
    public GameObject BulletPrefab;
    public StatsHolder stats;
    private readonly float agroDist = 4;
    private float bulletTimer;
    

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        bulletTimer += Time.deltaTime;
        playerPos = player.GetComponent<Transform>().position;

        if (PlayerToEnemyDist(playerPos,transform.position) < agroDist)
        {
            rigidbody.velocity = new Vector2 (PlayerToEnemyDir(playerPos,transform.position).x * 4, PlayerToEnemyDir(playerPos, transform.position).y * 4);
        }
        else
        {

            rigidbody.velocity = new Vector2(0,0);
            
            Vector2 direction = -PlayerToEnemyDir(playerPos, transform.position);
            rigidbody.rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            float bulletSpeed = 7.5f;
            if (bulletTimer > stats.atkspeed)
            {
                bulletTimer = 0;
                GameObject bullet = Instantiate(BulletPrefab, new Vector3(transform.position.x + (direction.x * 2), transform.position.y + (direction.y * 2), 0), transform.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.velocity = direction * bulletSpeed;
            }
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
