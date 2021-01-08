using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextWellReceiveUpdater : MonoBehaviour
{
    private TextMeshProUGUI oresText;
    private TextMeshProUGUI barsText;

    public void UpdateText(int ores,int bars)
    {
        oresText.text = ("Ores: " + ores);
        barsText.text = ("Bars: " + bars);
    }

}
