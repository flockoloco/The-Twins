using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TheTwins.Model;

public class WellMenuScript : MonoBehaviour
{
    public GameObject player;
    public GameObject wellMenu;

    public Button wButton0;
    public Button wButton1;
    public Button wButton2;
    public Button wButton3;
    public Button wButton4;
    public Button wButton5;
    public Button wButton6;

    public int selectedGold = 0;
    public int selectedBars = 0;
    public int selectedOre = 0;

    private PlayerStats playerstats;

    public bool teste = false;
    private void Awake()
    {
        wellMenu.SetActive(false);
        player = GameObject.FindWithTag("Player");
        playerstats = player.GetComponent<PlayerStats>();

        wButton0.onClick.AddListener(delegate { ChangeValue(0, 1); }); // first digit, 0 is minus 1 is plus type 2 is submit
        wButton1.onClick.AddListener(delegate { ChangeValue(0, 2); }); // second digit, the reference
        wButton2.onClick.AddListener(delegate { ChangeValue(0, 3); });

        wButton3.onClick.AddListener(delegate { ChangeValue(1, 1); });
        wButton4.onClick.AddListener(delegate { ChangeValue(1, 2); });
        wButton5.onClick.AddListener(delegate { ChangeValue(1, 3); });

        wButton6.onClick.AddListener(delegate { Submit(); });

    }
    public void Activate()
    {
        wellMenu.SetActive(true);
    }
    public void StartNoMoneyPopUp()
    {
        Debug.Log("no money");
    }
    public void ChangeValue(int number, int type)
    {
        if (type == 1)
        {
            if (UsefulllFs.BuySomething(player, "gold", EquipmentClass.SwordandArmor[number].price) == true)
            {
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
            if (number == 0)
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
            else if (number == 1)
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
    void Submit()
    {

    }
}
