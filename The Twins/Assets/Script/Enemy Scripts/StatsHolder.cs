using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsHolder : MonoBehaviour
{
    public float health;
    public int armor;
    public int damage;
    public float atkspeed;
    public bool invunerable;
    private float vunerableTimer;
    public bool hit;
    public int lootTier;
    public int aaaaaa;
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
    void SpawnDrops(int tier, Transform ya)
    {
        Debug.Log("dentro da funcao");
            int randomNumberGold = Random.Range(1 * tier, 6 * tier);
        Debug.Log("numero random: " + randomNumberGold);
            if (randomNumberGold > 0)
            {
            Debug.Log("should be spawning something");
                GameObject goldDrop = Instantiate(goldPrefab, ya);
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
