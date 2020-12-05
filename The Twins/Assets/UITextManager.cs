using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UITextManager : MonoBehaviour
{
    private PlayerStats playerStats;
    private TextMeshProUGUI hpText;
    private TextMeshProUGUI goldText;
    private TextMeshProUGUI nuggetsText;
    private TextMeshProUGUI barsText;
    private TextMeshProUGUI normalArrowsText;
    private TextMeshProUGUI oreArrowsText;

    void Start()
    {
        playerStats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();

        hpText = GameObject.FindWithTag("HPText").GetComponent<TextMeshProUGUI>();
        goldText = GameObject.FindWithTag("GoldText").GetComponent<TextMeshProUGUI>();
        nuggetsText = GameObject.FindWithTag("NuggetsText").GetComponent<TextMeshProUGUI>();
        barsText = GameObject.FindWithTag("BarsText").GetComponent<TextMeshProUGUI>();
        normalArrowsText = GameObject.FindWithTag("NormalArrowsText").GetComponent<TextMeshProUGUI>();
        oreArrowsText = GameObject.FindWithTag("OreArrowsText").GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {//eventualmente remover o UPDATE() todo, e apenas dar call a funcao quando e necessario.
        hpText.text = (playerStats.health.ToString() + "/" + playerStats.maxHealth.ToString());
        goldText.text = playerStats.gold.ToString();
        nuggetsText.text = playerStats.nuggets.ToString();
        barsText.text = playerStats.bars.ToString();
    }
    void UpdateText(string stat) //more efficient :D for the future C:
    {
        switch(stat) {
            case "HP":
                hpText.text = (playerStats.health.ToString() + "/" + playerStats.maxHealth.ToString());
                break;
            case "Gold":
                goldText.text = playerStats.gold.ToString();
                break;
            case "Nuggets":
                nuggetsText.text = playerStats.nuggets.ToString();
                break;
            case "Bars":
                barsText.text = playerStats.bars.ToString();
                break;
            case "NormalArrow":
                normalArrowsText.text = "0"; //playerStats.normalArrow.ToString();
                break;
            case "OreArrow":
                oreArrowsText.text = "0"; //playerStats.oreArrow.ToString();
                break;
        }
    }
}
