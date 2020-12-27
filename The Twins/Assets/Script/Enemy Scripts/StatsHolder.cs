using UnityEngine;

public class StatsHolder : MonoBehaviour
{
    public float health;
    public int armor;
    public int damage;
    public float moveSpeed;
    public float bulletSpd;
    public bool invunerable;
    private float vunerableTimer;
    public bool hit;
    public int lootTier;
    public int agroRange;
    public GameObject goldPrefab;
    public GameObject nuggetsPrefab;
    private bool triggered;
    public bool ableToAttack = true;

    private void Update()
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

    private void SpawnDrops(int tier, Transform enemyTransform)
    {
        int randomNumberGold = Random.Range(10 * tier, 20 * tier);
        if (randomNumberGold > 0)
        {
            GameObject goldDrop = Instantiate(goldPrefab, enemyTransform.position, Quaternion.identity);
            goldDrop.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f)), ForceMode2D.Impulse);
            goldDrop.GetComponent<DropableScript>().Value(randomNumberGold);
        }
        int randomNumberNuggets = Random.Range(10 * tier, 20 * tier);
        if (randomNumberNuggets > 0)
        {
            Debug.Log("hello :aaaa");
            GameObject nuggetsDrop = Instantiate(nuggetsPrefab, enemyTransform.position, Quaternion.identity);
            nuggetsDrop.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f)), ForceMode2D.Impulse);
            nuggetsDrop.GetComponent<DropableScript>().Value(randomNumberNuggets);
        }
    }
}