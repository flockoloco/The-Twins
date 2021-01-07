using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TheTwins.Model;

public delegate void ReturningFunction(string content, int error);
public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public string BaseAPI = "http://127.0.0.1:3000";

    public Canvas canvas;
    public PlayerInfo playerInfo;
    public bool logged;
    public PlayerStatsHolder statsToUse;
    public GameObject popUpPrefab;
    public GameObject loginCanvas;
    public GameObject registerCanvas;
    public GameObject WellDeliveryCanvas;
    public CurrencyHolder playerCurrency;
    public EnchantTierHolder enchantTierHolder;

    public void RegisterReturn(string data, int error)  
    {
        
        if (error == 1) // no connection error
        {
            PlayerInfo dataReceived = JsonUtility.FromJson<PlayerInfo>(data);
            Debug.Log("inside of the return "+data);
            if (dataReceived.Status == 1) //user name already in use
            {
                Debug.Log("inside of the equals");
                GameObject popUp = Instantiate(popUpPrefab, registerCanvas.transform);
                popUp.transform.position = new Vector3(popUp.transform.position.x, popUp.transform.position.y - 300, popUp.transform.position.z);
                popUp.GetComponent<DialogScript>().GiveText("Name already in use.");
            }
            else if (dataReceived.Status == 0)  // acc created
            {
                GameObject.Find("CanvasChanger").GetComponent<UIPopUpScript>().CanvasSwitcher(1);
                GameObject popUp = Instantiate(popUpPrefab, loginCanvas.transform);
                popUp.transform.position = new Vector3(popUp.transform.position.x, popUp.transform.position.y - 300, popUp.transform.position.z);
                popUp.GetComponent<DialogScript>().GiveText("Register finished.");
            }
        }
        else if (error == 2) // connection error
        {
            GameObject popUp = Instantiate(popUpPrefab, registerCanvas.transform);
            popUp.transform.position = new Vector3(popUp.transform.position.x, popUp.transform.position.y - 300, popUp.transform.position.z);
            popUp.GetComponent<DialogScript>().GiveText("Connection error");
        }
    }
    public void LoginReturn(string data, int error)
    {
        if (error == 1) // no connection error
        {
            PlayerInfo dataReceived = JsonUtility.FromJson<PlayerInfo>(data);
            if (dataReceived.Status == 0)
            {
                playerInfo.Username = dataReceived.Username;
                playerInfo.UserID = dataReceived.UserID;
                logged = true;
                GameObject.Find("CanvasChanger").GetComponent<UIPopUpScript>().CanvasSwitcher(0);
            }
            else if (dataReceived.Status == 1)
            {
                GameObject popUp = Instantiate(popUpPrefab, loginCanvas.transform);
                popUp.transform.position = new Vector3(popUp.transform.position.x, popUp.transform.position.y - 300, popUp.transform.position.z);
                popUp.GetComponent<DialogScript>().GiveText("Wrong password, try again");
            }
            else if (dataReceived.Status == 2)
            {
                GameObject popUp = Instantiate(popUpPrefab, loginCanvas.transform);
                popUp.transform.position = new Vector3(popUp.transform.position.x, popUp.transform.position.y - 300, popUp.transform.position.z);
                popUp.GetComponent<DialogScript>().GiveText("No user with that username");
            }
           
        }
        else if (error == 2) // connection error
        {
            GameObject popUp = Instantiate(popUpPrefab, loginCanvas.transform);
            popUp.transform.position = new Vector3(popUp.transform.position.x, popUp.transform.position.y - 300, popUp.transform.position.z);
            popUp.GetComponent<DialogScript>().GiveText("Connection error");
        }
    }
    IEnumerator PostRequest(string uri, string jsondata, ReturningFunction ReturningFunctionName)
    {
        UnityWebRequest webRequest = new UnityWebRequest(uri, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsondata);
        webRequest.uploadHandler = (UploadHandler)new
        UploadHandlerRaw(jsonToSend);
        webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError)
        {
            Debug.Log("inside error");
            ReturningFunctionName(webRequest.downloadHandler.text, 2);
        }
        else
        {
            yield return webRequest.downloadHandler.text;
            ReturningFunctionName(webRequest.downloadHandler.text, 1);
            Debug.Log(webRequest.downloadHandler.text);
        }
    }
    public void LoginPlayer(string name, string pass)
    {
        string jsondata = JsonUtility.ToJson(new PlayerInfo(name, pass));
        StartCoroutine(PostRequest(BaseAPI + "login", jsondata, LoginReturn));
    }
    public void RegisterNewPlayer(string name, string pass)
    {
        string jsondata = JsonUtility.ToJson(new PlayerInfo(name, pass));
        StartCoroutine(PostRequest(BaseAPI + "register", jsondata, RegisterReturn));
    }
    public void GetBarsAndOres()
    {
        int playerid = playerInfo.UserID;
        string jsondata = JsonUtility.ToJson(new PlayerInfo(playerid));
        StartCoroutine(PostRequest(BaseAPI + "getGameCurrency", jsondata, GetBarsAndOresReturn));
    }
    public void GetBarsAndOresReturn(string data, int error)
    {
        CurrencyHolder dataReceived = JsonUtility.FromJson<CurrencyHolder>(data);
        playerCurrency = dataReceived;
    }
    public void SaveBarsAndOres()
    {
        playerCurrency.UserID = playerInfo.UserID;
        string jsondata = JsonUtility.ToJson(playerCurrency);
        StartCoroutine(PostRequest(BaseAPI + "saveCurrency", jsondata, SaveBarsAndOresReturn));
    }
    public void SaveBarsAndOresReturn(string data, int error)
    {
        //not much to do maybe do a check for errors
    }
    public void LoadRun()
    {
        string jsondata = JsonUtility.ToJson(playerInfo);
        Debug.Log(jsondata);
        StartCoroutine(PostRequest(BaseAPI + "loadRun", jsondata, LoadRunReturn));
    }
    public void LoadRunReturn(string data, int error)
    {
        PlayerStatsHolder dataReceived = JsonUtility.FromJson<PlayerStatsHolder>(data);
            statsToUse = dataReceived;
    }
    public void SaveRunInfo()
    {
        GameObject Player = GameObject.FindWithTag("Player"); //getting all data to save
        int pSwordID = Player.GetComponent<PlayerStats>().equippedSword.id;
        int pArmorID = Player.GetComponent<PlayerStats>().equippedArmor.id;
        int pHealth = Player.GetComponent<PlayerStats>().health;
        int pOreArrowAmount = EquipmentClass.Quiver[1].amount;
        int pNormalArrowAmount = EquipmentClass.Quiver[0].amount;
        int pPotsAmount = Player.GetComponent<PlayerStats>().healthPotions;
        int currentLvl = Player.GetComponent<PlayerStats>().currentLevel;
        int currentgold = Player.GetComponent<PlayerStats>().gold;

        string jsonToSend = JsonUtility.ToJson(new PlayerStatsHolder(pSwordID, pArmorID, currentLvl, pHealth, pOreArrowAmount, pNormalArrowAmount, pPotsAmount,currentgold));

        StartCoroutine(PostRequest(BaseAPI + "saveRun", jsonToSend,SaveRunInfoReturn));
    }
    public void SaveRunInfoReturn(string data, int error)
    {
        //make the game close; / load main menu
    }
    public void GetEnchants()
    {
        string jsondata = JsonUtility.ToJson(new PlayerInfo(playerInfo.UserID));
        StartCoroutine(PostRequest(BaseAPI + "loadEnchants", jsondata, GetEnchantsReturn));
    }
    public void GetEnchantsReturn(string data, int error)
    {
        EnchantTierHolder dataReceived = JsonUtility.FromJson<EnchantTierHolder>(data);
        enchantTierHolder = dataReceived;
    }
    public void SaveEnchants()
    {
        enchantTierHolder.UserID = playerInfo.UserID;
        string jsondata = JsonUtility.ToJson(enchantTierHolder);
        StartCoroutine(PostRequest(BaseAPI + "saveEnchants", jsondata, SaveEnchantsReturn));
    }
    public void SaveEnchantsReturn(string data, int error)
    {
        //idk
    }
    public void SendDelivery(int selectedbars, int selectedores)
    {
        string jsondata = JsonUtility.ToJson(new DeliveryHolder(selectedores,selectedbars,playerInfo.UserID));
        StartCoroutine(PostRequest(BaseAPI + "senddelivery", jsondata, SendDeliveryReturn));
    }
    public void SendDeliveryReturn(string data, int error)
    {
        //idk
    }
    public void CheckDelivery(int whattodo)
    {
        string jsondata = JsonUtility.ToJson(new DeliveryHolder(playerInfo.UserID));
        if (whattodo == 0)
        {
            StartCoroutine(PostRequest(BaseAPI + "checkdelivery", jsondata, CheckDeliveryReturn));
        }
        else if (whattodo == 1)
        {
            StartCoroutine(PostRequest(BaseAPI + "acceptdelivery", jsondata, AcceptDeliveryReturn));
        }
        
    }
    public void CheckDeliveryReturn(string data, int error)
    {
        DeliveryHolder receivedData = JsonUtility.FromJson<DeliveryHolder>(data);
        if (receivedData.Status == 1)
        {
            //tell player nothing to get
        }else if (receivedData.Status == 0)
        {
            //make button glow and clicable
            //in new ui show values (this ui has a button that runs the accept delivery as well as a button that closes the ui)
            //deliveryUI.bars = receivedData.bars....
        }
    }
    public void AcceptDeliveryReturn(string data, int error)
    {
        DeliveryHolder receivedData = JsonUtility.FromJson<DeliveryHolder>(data);
        if (receivedData.Status == 0)
        {
            //playerstats = playerstats + deliverystats
            //saveplayercurrency() POST


            GameObject popUp = Instantiate(popUpPrefab, WellDeliveryCanvas.transform);
            popUp.transform.position = new Vector3(popUp.transform.position.x, popUp.transform.position.y - 300, popUp.transform.position.z);
            popUp.GetComponent<DialogScript>().GiveText("Values accepted!");
        }
        else if (receivedData.Status == 1)
        {
            GameObject popUp = Instantiate(popUpPrefab, WellDeliveryCanvas.transform);
            popUp.transform.position = new Vector3(popUp.transform.position.x, popUp.transform.position.y - 300, popUp.transform.position.z);
            popUp.GetComponent<DialogScript>().GiveText("You somehow crashed it");
        }
    }
}
