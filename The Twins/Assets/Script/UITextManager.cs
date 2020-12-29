using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TheTwins.Model;
public class UITextManager : MonoBehaviour
{
    private PlayerStats playerStats;
    private TextMeshProUGUI hpText;
    private TextMeshProUGUI goldText;
    private TextMeshProUGUI nuggetsText;
    private TextMeshProUGUI barsText;
    private TextMeshProUGUI normalArrowsText;
    private TextMeshProUGUI oreArrowsText;
    private TextMeshProUGUI potionText;
    public GameObject ArrowSelectedImage;

    void Start()
    {
        playerStats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();

        hpText = GameObject.FindWithTag("HPText").GetComponent<TextMeshProUGUI>();
        goldText = GameObject.FindWithTag("GoldText").GetComponent<TextMeshProUGUI>();
        nuggetsText = GameObject.FindWithTag("NuggetsText").GetComponent<TextMeshProUGUI>();
        barsText = GameObject.FindWithTag("BarsText").GetComponent<TextMeshProUGUI>();
        normalArrowsText = GameObject.FindWithTag("NormalArrowText").GetComponent<TextMeshProUGUI>();
        oreArrowsText = GameObject.FindWithTag("OreArrowText").GetComponent<TextMeshProUGUI>();
        potionText = GameObject.FindWithTag("PotionText").GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {//eventualmente remover o UPDATE() todo, e apenas dar call a funcao quando e necessario.
        hpText.text = (playerStats.health.ToString() + "/" + playerStats.maxHealth.ToString());
        goldText.text = playerStats.gold.ToString();
        nuggetsText.text = playerStats.nuggets.ToString();
        barsText.text = playerStats.bars.ToString();

        normalArrowsText.text = EquipmentClass.Quiver[0].amount.ToString();
        oreArrowsText.text = EquipmentClass.Quiver[1].amount.ToString();

        potionText.text = playerStats.healthPotions.ToString();
    }

    public void CheckArrow()
    {
        if (playerStats.selectedArrow == 1)
        {
            ArrowSelectedImage.transform.localPosition = new Vector2 (-22f, 72.1f);
        }
        else
        {
            ArrowSelectedImage.transform.localPosition = new Vector2(-22f, -7.3f);
        }
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
