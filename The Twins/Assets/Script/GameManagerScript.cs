using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TheTwins.Model;

public delegate void ReturningFunction(string content);
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

<<<<<<< Updated upstream
    public string BaseAPI = "http://127.0.0.1:3000";
=======
    public string BaseAPI = "http://127.0.0.1:3000/";
>>>>>>> Stashed changes
    public Canvas canvas;
    public PlayerInfo playerInfo;
    public bool logged;
    public PlayerStatsHolder statsToUse;
    
    public void myname(string bbbbb)
    {
        Debug.Log(bbbbb);
    }

<<<<<<< Updated upstream
    IEnumerator PostRequest(string uri, string jsondata,ReturningFunction aaaaaa)
=======
    IEnumerator PostRequest(string uri, string jsondata,myfunction aaaaaa)
>>>>>>> Stashed changes
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
            Debug.Log(webRequest.error);
        }
        else
        {
            // meter aquiiiii
            yield return webRequest.downloadHandler.text;
            aaaaaa(webRequest.downloadHandler.text);
            Debug.Log(webRequest.downloadHandler.text);
        }
    }
    public void LoginPlayer(string name, string pass)
    {
        gameObject.GetComponent<GameManagerScript>().playerInfo.Username = name;

        string jsondata = JsonUtility.ToJson(new PlayerInfo (name,pass));

        StartCoroutine(PostRequest(BaseAPI + "login", jsondata));
        //verificar se foi tudo correto.
        gameObject.GetComponent<GameManagerScript>().logged = true;
        gameObject.GetComponent<GameManagerScript>().playerInfo.id = 1; //use id recieved

        GameObject.Find("CanvasChanger").GetComponent<UIPopUpScript>().CanvasSwitcher(0);
    }

    public void RegisterNewPlayer(string name, string pass)
    {
        string jsondata = JsonUtility.ToJson(new PlayerInfo(name,pass));
        Debug.Log(jsondata);
        StartCoroutine(PostRequest(BaseAPI + "register", jsondata,myname));
        LoginPlayer(name, pass); 
    }
    public void GetSavedPlayerStats(int playerid)
    {
        
        string jsondata = JsonUtility.ToJson(new PlayerInfo(playerid));
        Debug.Log(jsondata);
        StartCoroutine(PostRequest(BaseAPI + "register", jsondata));

        //receber do post um playerstatsholder com os stats do player 
        statsToUse = new PlayerStatsHolder(); //put real stats in here
    }
    public void SavePlayerInfo( PlayerStatsHolder playerStats)
    {
        
        
           /* GameObject Player = GameObject.FindWithTag("Player");
            int pSwordID = Player.GetComponent<PlayerStats>().equippedSword.id;
            int pArmorID = Player.GetComponent<PlayerStats>().equippedArmor.id;
            int pHealth = Player.GetComponent<PlayerStats>().health;
            int pOreArrowAmount = EquipmentClass.Quiver[1].amount;
            int pNormalArrowAmount = EquipmentClass.Quiver[0].amount;
            int pPotsAmount = Player.GetComponent<PlayerStats>().healthPotions;
            int currentLvl = Player.GetComponent<PlayerStats>().currentLevel;
            */

        string jsondata = JsonUtility.ToJson(playerStats);
        StartCoroutine(PostRequest(BaseAPI + "players/setscore", jsondata));
        //make the game close;
    }
    public void LoadPlayerInfo(PlayerStatsHolder playerStats)
    {
        string jsondata = JsonUtility.ToJson(playerStats);
        StartCoroutine(PostRequest(BaseAPI + "players/setscore", jsondata));
        //load LevelGen Scene e manter a data ate o player aparecer
    }
    public void UpdateEnchants()
    {

    }
}
