using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TheTwins.Model;

public class ShopMenuScript : MonoBehaviour
{
    public GameObject player;
    public GameObject shopMenu;

    public Button Button0;
    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button Button4;
    public Button Button5;
    public Button Button6;
    public Button Button7;
    public Button Button8;


    // Start is called before the first frame update
    private void Awake()
    {
        shopMenu.SetActive(false);
        player = GameObject.FindWithTag("Player");
    }
    void Start()
    {
       
        Button0.onClick.AddListener(delegate { BuyEquipment(0,1); });//first field is the number of the item inside the second fields list 0 = pots/arrows 1 = equipments
        Button1.onClick.AddListener(delegate { BuyEquipment(1,1); });
        Button2.onClick.AddListener(delegate { BuyEquipment(2, 1); });
        Button3.onClick.AddListener(delegate { BuyEquipment(3, 1); });
        Button4.onClick.AddListener(delegate { BuyEquipment(4, 1); });
        Button5.onClick.AddListener(delegate { BuyEquipment(5, 1); });

        Button6.onClick.AddListener(delegate { BuyEquipment(0, 0); });
        Button7.onClick.AddListener(delegate { BuyEquipment(1, 0); });
        Button8.onClick.AddListener(delegate { BuyEquipment(2, 0); });


    }
    public void Activate()
    {
        shopMenu.SetActive(true);
    }
    public void DeActivate()
    {
        shopMenu.SetActive(false);
    }

    void Update()
    {
        
    }
    public void BuyEquipment(int number,int type)
    {
        Debug.Log("dentro do buy equipment numero " + number + " type " + type);
        Debug.Log("length dos equipments" + EquipmentClass.SwordandArmor.Count);
        if (type == 1)
        {
            Debug.Log("buy check " + UsefulllFs.BuySomething(player, "gold", EquipmentClass.SwordandArmor[number].price));
            if (UsefulllFs.BuySomething(player, "gold", EquipmentClass.SwordandArmor[number].price) == true)
            {
                player.GetComponent<PlayerStats>().RemoveEquipedItem(EquipmentClass.SwordandArmor[number].type);

                player.GetComponent<PlayerStats>().EquipItem(EquipmentClass.SwordandArmor[number].type,number);
          
            }
            else
            {
                //display "not enough money"
         
            }
        }
        else if (type == 0)
        {
            if(number == 0)
            {
                if (UsefulllFs.BuySomething(player, "gold", 20) == true)
                {
                    player.GetComponent<PlayerStats>().healthPotions += 1;
                }
                else
                {
                    //display "not enough money"
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
                    //display "not enough money"
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
                    //display "not enough money"
                }
            }
        }
    }
}
