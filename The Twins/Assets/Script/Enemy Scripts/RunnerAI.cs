using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerAI : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerPos;
    private Rigidbody2D rigidbody;
    public GameObject BulletPrefab;
    public StatsHolder stats;
    private readonly float agroDist = 4;
    private float bulletTimer;
    public Transform FirePoint;
    public bool triggered;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        if (triggered)
        {
            bulletTimer += Time.deltaTime;
            playerPos = player.GetComponent<Transform>().position;


            Vector2 playerDir = UsefulllFs.Dir(playerPos, transform.position, true);


            if (PlayerToEnemyDist(playerPos, transform.position) < agroDist) //when running away, he faces away from the player and moves away
            {
                Vector2 direction = playerDir;
                rigidbody.velocity = new Vector2(playerDir.x, playerDir.y) * stats.moveSpeed;
                rigidbody.rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            }
            else //attacking cuz hes far away enough
            {

                rigidbody.velocity = new Vector2(0, 0);

                Vector2 direction = -playerDir;
                rigidbody.rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                if (bulletTimer > stats.atkspeed)
                {
                    bulletTimer = 0;
                    stats.EnemyFire(BulletPrefab, FirePoint, 0);
                }
            }
        }
    }

    private float PlayerToEnemyDist(Vector3 pPos, Vector3 ePos)
    {
        return Mathf.Sqrt((ePos.x - pPos.x) * (ePos.x - pPos.x) + (ePos.y - pPos.y) * (ePos.y - pPos.y));
    }
}
