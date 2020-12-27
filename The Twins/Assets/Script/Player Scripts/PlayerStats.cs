using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheTwins.Model;

public class PlayerStats : MonoBehaviour
{
    public int health;
    public int maxHealth;
    private int baseHPAmount = 100;
    private int baseArmorAmount = 1;
    public float swordAtkSpeed;
    public float bowAtkSpeed;
    public int armor;
    public int swordDamage;
    public int selectedArrow = 0;
    public bool hit;
    public bool invunerable;
    public int gold;
    public int bars;
    public int nuggets;
    public int healthPotions;
    private float vunerableTimer;
    public SwordAndArmor equippedSword = new SwordAndArmor();
    public SwordAndArmor equippedArmor = new SwordAndArmor();
    private PauseMenu pauseMenu;
    public bool shopOpen = false;
    public int currentLevel;
    private void Awake()
    {
        currentLevel = 0; //ir buscar a base de dados;
        pauseMenu = GameObject.FindWithTag("PauseUI").GetComponent<PauseMenu>();
    }
    private void Start()
    {
        RemoveEquipedItem("Sword");
        RemoveEquipedItem("Armor");
        GameObject.FindWithTag("PlayerSword").GetComponent<Animator>().SetInteger("Tier", 0);
    }

    void Update()
    {
        if (health <= 0)
        {
            pauseMenu.ResetGame();
        }
        if (hit == true)
        {
            invunerable = true;
            if (vunerableTimer == 0)
            {
                gameObject.GetComponent<PlayerMovement>().state = PlayerMovement.State.hit;
            }
            vunerableTimer += Time.deltaTime;
            if (vunerableTimer > 0.25 && vunerableTimer < 0.5)
            {
                if (gameObject.GetComponent<PlayerMovement>().state == PlayerMovement.State.hit)
                {
                    gameObject.GetComponent<PlayerMovement>().state = PlayerMovement.State.walking;
                }
            }
            if (vunerableTimer > 0.5)
            {
                invunerable = false;
                hit = false;
                vunerableTimer = 0;
            }
        }
    }

    public void EquipItem(string type, int number)
    {
        if (type == "Sword")
        {
            equippedSword = EquipmentClass.SwordandArmor[number];
            swordDamage = equippedSword.damage + EquipmentClass.Enchant[equippedSword.enchantTier].BonusDamage;
            swordAtkSpeed = equippedSword.atkSpeed;
            GameObject.FindWithTag("PlayerSword").GetComponent<Animator>().SetInteger("Tier",number);
        }
        else if (type == "Armor")
        {
            equippedArmor = EquipmentClass.SwordandArmor[number];
            maxHealth = baseHPAmount + equippedArmor.maxHP + EquipmentClass.Enchant[equippedArmor.enchantTier].bonusHp;
            armor = baseArmorAmount + equippedArmor.armor;
        }
    }
    public void RemoveEquipedItem(string type)
    {
        if (type == "Sword")
        {
            equippedSword = EquipmentClass.SwordandArmor[0];
            swordDamage = equippedSword.damage + EquipmentClass.Enchant[equippedSword.enchantTier].BonusDamage;
            swordAtkSpeed = equippedSword.atkSpeed;
            GameObject.FindWithTag("PlayerSword").GetComponent<Animator>().SetInteger("Tier", 0);
        }
        else if (type == "Armor")
        {
            equippedArmor = EquipmentClass.SwordandArmor[4];
            maxHealth = baseHPAmount;
            armor = baseArmorAmount;
        }
    }
    public void UseHealthPotion()
    {
        healthPotions -= 1;
        health += maxHealth / 2;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}