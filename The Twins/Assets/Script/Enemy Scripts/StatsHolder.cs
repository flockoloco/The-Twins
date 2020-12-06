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
    public int lootTier;
    public GameObject goldPrefab;
    public GameObject nuggetsPrefab;

    void Update()
    {
        if (health < 0)
        {
            Destroy(gameObject);
            SpawnDrops(lootTier, gameObject.transform);
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
    void SpawnDrops(int tier, Transform ya)
    {
            int randomNumberGold = Random.Range(1 * tier, 6 * tier);
            if (randomNumberGold > 0)
            {
                GameObject goldDrop = Instantiate(goldPrefab, ya);
                int randomAngle = Random.Range(0, 361);
                goldDrop.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)), ForceMode2D.Impulse);
                goldDrop.GetComponent<DropableScript>().Value(randomNumberGold);
            }
            int randomNumberNuggets = Random.Range(1 * tier, 3 * tier);
            if (randomNumberNuggets > 0)
            {
                GameObject nuggetsDrop = Instantiate(nuggetsPrefab, ya);
                int randomAngle = Random.Range(0, 361);
                nuggetsDrop.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)), ForceMode2D.Impulse);
                nuggetsDrop.GetComponent<DropableScript>().Value(randomNumberNuggets);
        }
    }
}
