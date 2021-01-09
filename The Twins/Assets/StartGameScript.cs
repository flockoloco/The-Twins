using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProceduralLevelGenerator.Unity.Generators.DungeonGenerator;

public class StartGameScript : MonoBehaviour
{
    GameManagerScript managerScript;
    GameObject player;
    PlayerStats playerStats;
    public GameObject mainMenuCanvasSwitcher;

    void Start()
    {
        managerScript = gameObject.GetComponent<GameManagerScript>();
        mainMenuCanvasSwitcher.GetComponent<UIPopUpScript>().CanvasSwitcher(1);
    }

    public void StartGame()
    {
        player = GameObject.FindWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();

        playerStats.nuggets = managerScript.playerCurrency.Ores; //getting both permanent currencies
        playerStats.bars = managerScript.playerCurrency.Bars;

        //arrow amounts are loaded directly 
        //enchantment tiers are loaded directly

        GameObject.FindWithTag("PlayerSword").GetComponent<Animator>().SetInteger("Tier", managerScript.statsToUse.eSwordID); //correct sword animation

        playerStats.RemoveEquipedItem("Sword"); //saved sword and armor equipping
        playerStats.RemoveEquipedItem("Armor");
        playerStats.EquipItem("Sword", managerScript.statsToUse.eSwordID);
        playerStats.EquipItem("Armor", managerScript.statsToUse.eArmorID);

        playerStats.health = managerScript.statsToUse.currentHP; //loading saved hp
        playerStats.healthPotions = managerScript.statsToUse.potsAmount; //loading saved pots
        playerStats.gold = managerScript.statsToUse.gold; //loading saved gold

        playerStats.currentLevel = managerScript.statsToUse.currentLvl;
        Debug.Log(playerStats.currentLevel);

        GenLevel(playerStats.currentLevel);
    }

    public void GenLevel(int levelnumber)
    {
        player.transform.position = new Vector3(10000, 0, 0); //making sure the player isnt inside a room when generating

        if (levelnumber == 0) //selecting lvl to gen
        {
            Debug.Log("trying to gen a lvl 0");
            var lvl0gen = GameObject.Find("Level0Generator").GetComponent<DungeonGenerator>();
            lvl0gen.Generate();
        }
        else if (levelnumber == 1)
        {
            Debug.Log("trying to gen a lvl 1");
            var lvl1gen = GameObject.Find("Level1Generator").GetComponent<DungeonGenerator>();
            lvl1gen.Generate();

        }//add 1 more in the future

        playerStats.shopOpen = false; //making sure camera doesnt get stuck on stairs
        player.GetComponent<PlayerMovement>().Invoke("PlayerTeleport", 1f);//teleporting to spawn
    }
}
