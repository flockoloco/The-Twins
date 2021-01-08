using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProceduralLevelGenerator.Unity.Generators.DungeonGenerator;

public class StartGameScript : MonoBehaviour
{
    GameManagerScript managerScript;
    GameObject player;
    PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        managerScript = gameObject.GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        player = GameObject.FindWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();

        playerStats.nuggets = managerScript.playerCurrency.ores; //getting both permanent currencies
        playerStats.bars = managerScript.playerCurrency.bars;

        //arrow amounts are loaded directly 
        //enchantment tiers are loaded directly

        GameObject.FindWithTag("PlayerSword").GetComponent<Animator>().SetInteger("Tier", 0); //correct sword animation

        playerStats.RemoveEquipedItem("Sword"); //saved sword and armor equipping
        playerStats.RemoveEquipedItem("Armor");
        playerStats.EquipItem("Sword", managerScript.statsToUse.eSwordID);
        playerStats.EquipItem("Armor", managerScript.statsToUse.eArmorID);

        playerStats.health = managerScript.statsToUse.currentHP; //loading saved hp
        playerStats.healthPotions = managerScript.statsToUse.potsAmount; //loading saved pots
        playerStats.gold = managerScript.statsToUse.gold; //loading saved gold

        playerStats.currentLevel = managerScript.statsToUse.currentLvl;
    }

    public void GenLevel(int levelnumber)
    {
        if (managerScript.statsToUse.currentLvl == 0) //selecting lvl to gen
        {
            var lvl0gen = GameObject.Find("Level0Generator").GetComponent<DungeonGenerator>();
            lvl0gen.Generate();
        }
        else if (managerScript.statsToUse.currentLvl == 1)
        {
            var lvl1gen = GameObject.Find("Level1Generator").GetComponent<DungeonGenerator>();
            lvl1gen.Generate();

        }//add 1 more in the future
    }
}
