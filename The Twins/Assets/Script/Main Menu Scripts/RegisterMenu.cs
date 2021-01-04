using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RegisterMenu : MonoBehaviour
{
    public TextMeshProUGUI errorText;
    
    public TMP_InputField pass1Input;
    public TMP_InputField pass2Input;
    public TMP_InputField nameInput;
    public void Register()
    {
        Debug.Log("texto 1 " + pass1Input.text);
        Debug.Log("text 2 " + pass2Input.text);
        if (pass1Input.text == pass2Input.text)
        {
            Debug.Log("dentro");
            GameObject.FindWithTag("GameManager").GetComponent<GameManagerScript>().RegisterNewPlayer(nameInput.text,pass1Input.text);
        }
        else if (pass1Input.text != pass2Input.text)
        {
            errorText.text = ("Password inputs must match");
        }
    }
}
