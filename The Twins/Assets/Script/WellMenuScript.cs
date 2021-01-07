using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WellMenuScript : MonoBehaviour
{
    public GameObject player;
    public GameObject wellMenu;
    private GameManagerScript gameManager;

    [SerializeField]
    private int[] selectedCurrency;

    [SerializeField]
    private int[] availableCurrency;

    public Button goldButton0;
    public Button goldButton1;
    public Button goldButton2;
    public Button goldButton3;

    public Button oreButton0;
    public Button oreButton1;
    public Button oreButton2;
    public Button oreButton3;

    public Button barsButton0;
    public Button barsButton1;
    public Button barsButton2;
    public Button barsButton3;

    public TextMeshProUGUI goldText;
    public TextMeshProUGUI oreText;
    public TextMeshProUGUI barsText;

    public Button submitButton;

    private PlayerStats playerstats;

    private void Awake()
    {
        wellMenu.SetActive(false);
        player = GameObject.FindWithTag("Player");
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManagerScript>();
        goldButton0.onClick.AddListener(delegate { ChangeValue(-10, 0); }); // first digit is how much the selectedcurrency[second digit] will change.
        goldButton1.onClick.AddListener(delegate { ChangeValue(-1, 0); }); // second digit, the reference to the type of currency.
        goldButton2.onClick.AddListener(delegate { ChangeValue(1, 0); });
        goldButton3.onClick.AddListener(delegate { ChangeValue(10, 0); });

        oreButton0.onClick.AddListener(delegate { ChangeValue(-10, 2); });
        oreButton1.onClick.AddListener(delegate { ChangeValue(-1, 2); });
        oreButton2.onClick.AddListener(delegate { ChangeValue(1, 2); });
        oreButton3.onClick.AddListener(delegate { ChangeValue(10, 2); });

        barsButton0.onClick.AddListener(delegate { ChangeValue(-10, 1); });
        barsButton1.onClick.AddListener(delegate { ChangeValue(-1, 1); });
        barsButton2.onClick.AddListener(delegate { ChangeValue(1, 1); });
        barsButton3.onClick.AddListener(delegate { ChangeValue(10, 1); });

        submitButton.onClick.AddListener(delegate { Submit(); });

        selectedCurrency = new int[3];
        availableCurrency = new int[3];
    }

    public void Activate()
    {
        wellMenu.SetActive(true);
        UpdateAvailableCurrency();
        selectedCurrency[0] = 0;
        selectedCurrency[1] = 0;
        selectedCurrency[2] = 0;
        UpdateText();
    }

    public void ChangeValue(int number, int type)
    {
        int testingResult = selectedCurrency[type] + number;

        if (testingResult < 0)
        {
            testingResult = 0;
        }
        else if (testingResult > availableCurrency[type])
        {
            testingResult = availableCurrency[type];
        }
        selectedCurrency[type] = testingResult;
        testingResult = 0;

        UpdateText();
    }

    private void Submit()
    {
        if ((selectedCurrency[0] > 0) || (selectedCurrency[1] > 0) || (selectedCurrency[2] > 0))
        {
            //POST mandar selectedCurrency como um arrayy :D
            gameManager.SendDelivery(selectedCurrency[1],selectedCurrency[2],gameManager.playerInfo.UserID);


            player.GetComponent<PlayerStats>().gold -= selectedCurrency[0];
            player.GetComponent<PlayerStats>().bars -= selectedCurrency[1];
            player.GetComponent<PlayerStats>().nuggets -= selectedCurrency[2];

            gameManager.playerCurrency.bars -= selectedCurrency[1];
            gameManager.playerCurrency.ores -= selectedCurrency[2];


            UpdateAvailableCurrency();

            selectedCurrency[0] = 0;
            selectedCurrency[1] = 0;
            selectedCurrency[2] = 0;

            UpdateText();
        }
        else
        {
            //ask to put something in the inputs
        }
    }

    private void UpdateAvailableCurrency()
    {
        playerstats = player.GetComponent<PlayerStats>();
        availableCurrency[0] = playerstats.gold;
        availableCurrency[1] = playerstats.bars;
        availableCurrency[2] = playerstats.nuggets;
    }

    private void UpdateText()
    {
        goldText.text = "Selected Gold: " + selectedCurrency[0];
        barsText.text = "Selected Bars: " + selectedCurrency[1];
        oreText.text = "Selected Ores: " + selectedCurrency[2];
    }
}