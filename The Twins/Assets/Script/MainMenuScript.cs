using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TheTwins.Model;
public class MainMenuScript : MonoBehaviour
{
   
    // Start is called before the first frame update
    public void Continue()
    {
        
    }
    public void StartNewGame()
    {
        SceneManager.LoadScene("Level Generator");
        Time.timeScale = 1;
    }
    public void Login()
    {
        Debug.Log("LMAOs");
    }
    public void Options()
    {
        Debug.Log("uhhga booga"); //canvas feito so ir buscar
    }
    public void Exit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LoginQuandoVolta()
    {
        //post login
        //volta com o id
        PlayerData.pID = 0; //data.pID;
    }
}
public static class PlayerData 
{
    public static int pID;
    public static int pSwordID;
    public static int pArmorID;
    public static int currentLvl; // 0 if dead, 1 or 2 depending on lvl
    public static int pHealth;
    public static int pOreArrowAmount;
    public static int pNormalArrowAmount;
    public static int pPotsAmount;

    static void Save()
    {
        GameObject Player = GameObject.FindWithTag("Player");
        pSwordID = Player.GetComponent<PlayerStats>().equippedSword.id;
        pArmorID = Player.GetComponent<PlayerStats>().equippedArmor.id;
        pHealth = Player.GetComponent<PlayerStats>().health;
        pOreArrowAmount = EquipmentClass.Quiver[1].amount;
        pNormalArrowAmount = EquipmentClass.Quiver[0].amount;
        pPotsAmount = Player.GetComponent<PlayerStats>().healthPotions;
        currentLvl = Player.GetComponent<PlayerStats>().currentLevel;


        //POST para o server;
    }
    static void TheBigGet() //nao sei o formato mas data
    {
        /* 
         data.pSwordID = pSwordID;
       data.pArmorID = pArmorID;
       .....
       pHealth;
       pOreArrowAmount;
       pNormalArrowAmount;
      pPotsAmount;
      currentLvl;

        */
    }


    static void Load() //correr quando se muda de scene;
    {

        GameObject Player = GameObject.FindWithTag("Player");

        Player.GetComponent<PlayerStats>().equippedSword.id = pSwordID;
        Player.GetComponent<PlayerStats>().equippedArmor.id = pArmorID;
        Player.GetComponent<PlayerStats>().health = pHealth;
        EquipmentClass.Quiver[1].amount = pOreArrowAmount;
        EquipmentClass.Quiver[0].amount = pNormalArrowAmount;
        Player.GetComponent<PlayerStats>().healthPotions = pPotsAmount;
        Player.GetComponent<PlayerStats>().currentLevel = currentLvl;

        //talvez correr aqui um generate 
    }
}
