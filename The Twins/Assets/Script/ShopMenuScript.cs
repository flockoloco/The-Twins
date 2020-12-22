﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TheTwins.Model;

public class ShopMenuScript : MonoBehaviour
{
    public GameObject player;
    public GameObject shopMenu;

    public Button sButton0;
    public Button sButton1;
    public Button sButton2;
    public Button sButton3;
    public Button sButton4;
    public Button sButton5;
    public Button sButton6;
    public Button sButton7;
    public Button sButton8;
    private PlayerStats playerstats;

    public bool teste = false;
    private void Awake()
    {
        shopMenu.SetActive(false);
        player = GameObject.FindWithTag("Player");
        playerstats = player.GetComponent<PlayerStats>();

        sButton0.onClick.AddListener(delegate { BuyEquipment(0, 1); });//first field is the number of the item inside the second fields list 0 = pots/arrows 1 = equipments
        sButton1.onClick.AddListener(delegate { BuyEquipment(1, 1); });

        sButton2.onClick.AddListener(delegate { BuyEquipment(2, 1); });
        sButton3.onClick.AddListener(delegate { BuyEquipment(3, 1); });
        sButton4.onClick.AddListener(delegate { BuyEquipment(4, 1); });
        sButton5.onClick.AddListener(delegate { BuyEquipment(5, 1); });

        sButton6.onClick.AddListener(delegate { BuyEquipment(0, 0); });
        sButton7.onClick.AddListener(delegate { BuyEquipment(1, 0); });
        sButton8.onClick.AddListener(delegate { BuyEquipment(2, 0); });
    }
    void Update()
    {
        if (teste == true)
        {
            teste = false;
            BuyEquipment(2, 1);
        }
    }
    public void Activate()
    {
        shopMenu.SetActive(true);
        Debug.Log("activating");
    }
    public void StartNoMoneyPopUp()
    {
        Debug.Log("no money");
    }
    public void BuyEquipment(int number,int type)
    {
        if (type == 1)
        {
            if (UsefulllFs.BuySomething(player, "gold", EquipmentClass.SwordandArmor[number].price) == true)
            {
                Debug.Log("inside if number "+number);
                playerstats.RemoveEquipedItem(EquipmentClass.SwordandArmor[number].type);
                playerstats.EquipItem(EquipmentClass.SwordandArmor[number].type, number);
            }
            else
            {
                StartNoMoneyPopUp();
            }
        }
        else if (type == 0)
        {
            if(number == 0)
            {
                if (UsefulllFs.BuySomething(player, "gold", 20) == true)
                {
                    playerstats.healthPotions += 1;
                }
                else
                {
                    StartNoMoneyPopUp();//send info
                }
            }
            else if(number == 1)
            {
                if (UsefulllFs.BuySomething(player, "gold", 5) == true)
                {
                    EquipmentClass.Quiver[0].amount += 1;
                }
                else
                {
                    StartNoMoneyPopUp();
                }
            }
            else if (number == 2)
            {
                if (UsefulllFs.BuySomething(player, "bars", 1) == true)
                {
                    EquipmentClass.Quiver[1].amount += 1;
                }
                else
                {
                    StartNoMoneyPopUp();
                }
            }
        }
    }
}
