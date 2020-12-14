using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GroupToggle : MonoBehaviour
{
    public Slider Music;
    public Slider sound;
    public ToggleGroup aa;
    public TMP_Dropdown bb;
    public Button bigButton;


    // Update is called once per frame
    void Update()
    {
         
        
    }
    public void BigButton()
    {
        Debug.Log(Music.value + "is the music value");
        Debug.Log(sound.value + "is the sound value");
        foreach (Toggle toggle in aa.ActiveToggles())
        {
            Debug.Log(toggle.name + "is the toggle active");
        }
        Debug.Log(bb.value + "is the dropdown value");

    }

}
