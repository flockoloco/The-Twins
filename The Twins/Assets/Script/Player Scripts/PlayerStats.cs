using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheTwins.Model;

public class PlayerStats : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float swordAtkSpeed;
    public float swordRange;
    public float bowAtkSpeed;
    public int armor;
    public float swordDamage;
    public int selectedArrow = 0;
    public bool hit;
    public bool invunerable;
    public int gold;
    public int bars;
    public int nuggets;
    public int healthPotions;
    ////////////public int normalArrows;
    ////////////public int oreArrows;
    private float vunerableTimer;
    public SwordAndArmor equippedSword;
    public SwordAndArmor equippedArmor;
    

    private PauseMenu pauseMenu;

    private void Awake()
    {
        pauseMenu = GameObject.FindWithTag("PauseUI").GetComponent<PauseMenu>();
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
    public void EquipItem(string type,int number)
    {

        if (type == "Sword")
        {
            equippedSword = EquipmentClass.SwordandArmor[number];
            swordDamage += equippedSword.damage;
            swordRange += equippedSword.range;
            swordAtkSpeed += equippedSword.atkSpeed;

        }
        else if (type == "Armor")
        {
            equippedArmor = EquipmentClass.SwordandArmor[number];
            maxHealth += equippedArmor.maxHP;
            armor += equippedArmor.armor;
        }
    }
    public void RemoveEquipedItem(string type)
    {
        if (type == "Sword")
        {
            swordDamage -= equippedSword.damage;
            swordRange -= equippedSword.range;
            swordAtkSpeed -= equippedSword.atkSpeed;
            equippedSword.type = "None";

        }

        else if (type == "Armor")
        {
            maxHealth -= equippedArmor.maxHP;
            armor -= equippedArmor.armor;
            equippedArmor.type = "None";
        }
    }
}