using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopUpScript : MonoBehaviour
{
    public GameObject LogInCanvas;
    public GameObject RegisterCanvas;
    public GameObject MainMenuCanvas;
    public void Start()
    {
        CanvasSwitcher(1);
    }
    public void CanvasSwitcher(int CanvasNumber) //0 MainMenu 1 Login 2 Register
    {
        if (CanvasNumber == 0) 
        {
            LogInCanvas.SetActive(false);
            RegisterCanvas.SetActive(false);
            MainMenuCanvas.SetActive(true);
        }
        else if (CanvasNumber == 1)
        {
            RegisterCanvas.SetActive(false);
            LogInCanvas.SetActive(true);
            MainMenuCanvas.SetActive(false);
        }
        else if (CanvasNumber == 2) 
        {
            RegisterCanvas.SetActive(true);
            LogInCanvas.SetActive(false);
            MainMenuCanvas.SetActive(false);
        }
    }
}
