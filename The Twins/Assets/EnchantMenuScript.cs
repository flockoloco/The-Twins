using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TheTwins.Model;

public class EnchantMenuScript : MonoBehaviour
{
    public GameObject player;
    public GameObject enchantMenu;

    public Button eButton0;
    public Button eButton1;
    public Button eButton2;
    public Button eButton3;
    public Button eButton4;
    public Button eButton5;
    private PlayerStats playerstats;

    private void Awake()
    {
        enchantMenu.SetActive(false);
        player = GameObject.FindWithTag("Player");
        playerstats = player.GetComponent<PlayerStats>();
       
        eButton0.onClick.AddListener(delegate { BuyEnchant(1, 1); });//armors
        eButton1.onClick.AddListener(delegate { BuyEnchant(2, 1); });
        eButton2.onClick.AddListener(delegate { BuyEnchant(3, 1); });

        eButton3.onClick.AddListener(delegate { BuyEnchant(1, 0); });//swords
        eButton4.onClick.AddListener(delegate { BuyEnchant(2, 0); });
        eButton5.onClick.AddListener(delegate { BuyEnchant(3, 0); });
        
    }
    public void Activate()
    {
        enchantMenu.SetActive(true);
        if (gameObject.tag == "EnchantCanvas")
        {
            //dar enable ou disable aos botoes dependendo dos enchants atuais.
        }
    }

    public void BuyEnchant(int number, int type)
    {
        if (UsefulllFs.BuySomething(player, "bars", EquipmentClass.Enchant[number].price) == true)
        {
            if (type == 1)
            {
                playerstats.equippedArmor.enchantTier = number;
                int idToEquip = playerstats.equippedArmor.id;
                playerstats.RemoveEquipedItem("Armor");
                playerstats.EquipItem("Armor", idToEquip);
            }
            else if (type == 0)
            {
                playerstats.equippedSword.enchantTier = number;
                int idToEquip = playerstats.equippedSword.id;
                playerstats.RemoveEquipedItem("Sword");
                playerstats.EquipItem("Sword", idToEquip);
            }
        }
    }
}
