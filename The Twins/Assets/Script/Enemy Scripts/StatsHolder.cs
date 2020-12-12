using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsHolder : MonoBehaviour
{
    public float health;
    public int armor;
    public int damage;
    public float moveSpeed;
    public float atkspeed;
    public float bulletSpd;
    public bool invunerable;
    private float vunerableTimer;
    public bool hit;
    public int lootTier;
    public int aaaaaa;
    public int agroRange;
    public GameObject goldPrefab;
    public GameObject nuggetsPrefab;

    void Update()
    {
        if (health < 0)
        {
            SpawnDrops(lootTier, gameObject.transform);
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
    void SpawnDrops(int tier, Transform enemyTransform)
    {
        int randomNumberGold = Random.Range(1 * tier, 6 * tier);
        if (randomNumberGold > 0)
        {
            GameObject goldDrop = Instantiate(goldPrefab,enemyTransform.position,enemyTransform.rotation);
            goldDrop.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f)), ForceMode2D.Impulse);
            goldDrop.GetComponent<DropableScript>().Value(randomNumberGold);
        }
        int randomNumberNuggets = Random.Range(1 * tier, 3 * tier);
        Debug.Log(randomNumberNuggets);
        if (randomNumberNuggets > 0)
        {
            Debug.Log("hello :aaaa");
            GameObject nuggetsDrop = Instantiate(nuggetsPrefab, enemyTransform.position, enemyTransform.rotation);
            nuggetsDrop.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f)), ForceMode2D.Impulse);
            nuggetsDrop.GetComponent<DropableScript>().Value(randomNumberNuggets);
        }
    }
    
    public void EnemyFire(GameObject BulletPrefab,Transform firepoint,float angleDiff)
    {
        Quaternion finalrotation = firepoint.rotation;

        finalrotation = Quaternion.Euler(0,0,firepoint.rotation.eulerAngles.z + angleDiff );
        GameObject bullet = Instantiate(BulletPrefab, firepoint.position,finalrotation);
        
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        bullet.GetComponent<BulletScript>().EnemyDamage(damage);
        rb.velocity = bullet.transform.right * bulletSpd;
    }
}
