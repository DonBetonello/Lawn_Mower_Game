using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Upgrades : MonoBehaviour
{
    public float Money { get => money; }
    [SerializeField] private TextMeshProUGUI SpeedUpgradeText;
    [SerializeField] private TextMeshProUGUI GrowUpgradeText;
    [SerializeField] private TextMeshProUGUI MoneyUpgradeText;
    [SerializeField] private TextMeshProUGUI MoneyCount;
    public float MoneyUpgrade;
    [SerializeField] private TextMeshProUGUI MoneyPriceText;
    [SerializeField] private TextMeshProUGUI GrowthPriceText;
    [SerializeField] private TextMeshProUGUI SpeedPriceText;
    [SerializeField] private float money = 0;
    public JoystickControl speed;
    public float GrowthUpgrade = 0;
    [SerializeField] private Button GrowUpgradeButton;
    [SerializeField] private Button SpeedUpgradeButton;
    [SerializeField] private Button MoneyUpgradeButton;
    [SerializeField] private Button DroneBuyButton;
    [Range(0.0f, 4.0f, order = 0)]
    [SerializeField] private float MaxSpeed = 4;
    [SerializeField] private float MaxGrow = 3.6f;
    [SerializeField] private float MaxMoneyUpgrade = 3;
    private float StartMoneyUpgradePrice = 200;
    private float MoneyInflationPrice = 1.2f;
    private float StartGrowthUpgradePrice = 150;
    private float GrowthInflationPrice = 1.2f;
    private float StartSpeedUpgradePrice = 150;
    private float SpeedInflationPrice = 1.2f;
    private float MoneyInflationCountTEXT;
    private float GrowthInflationText;
    private float SpeedInflationText;
    [SerializeField] private GameObject DisableSpeedText;
    [SerializeField] private GameObject DisableGrowthText;
    [SerializeField] private GameObject DisableMoneyText;
    public DroneUpgrade DroneSpeedUpgradeBought;
    public DroneUpgrade DroneBought;
    [SerializeField] AudioSource UpgradeButtonSound;
    [SerializeField] AudioSource MaxUpgradeButtonSound;
    [SerializeField] private GameObject Multiplyer_Flower_Object;
    [SerializeField] private Button Buy_Multiplyer_Flower_BUTTTON;
    [SerializeField] private Sound_Change_Button_Script Is_Sound_On;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>();
        SpeedText();
        GrowthText();
        MoneyPriceTextVoid();
    }
    void SpeedText()
    {
        SpeedInflationText = StartSpeedUpgradePrice * SpeedInflationPrice;
        SpeedPriceText.text = SpeedInflationText.ToString();
        SpeedPriceText.text = Mathf.Round(SpeedInflationText).ToString();
    }
    void GrowthText()
    {
        GrowthInflationText = StartGrowthUpgradePrice * GrowthInflationPrice;
        GrowthPriceText.text = GrowthInflationText.ToString();
        GrowthPriceText.text = Mathf.Round(GrowthInflationText).ToString();
    }
    void MoneyPriceTextVoid()
    {
        MoneyInflationCountTEXT = StartMoneyUpgradePrice * MoneyInflationPrice;
        MoneyPriceText.text = MoneyInflationCountTEXT.ToString();
        MoneyPriceText.text = Mathf.Round(MoneyInflationCountTEXT).ToString();
    }
    void MoneyText()
    {
        MoneyCount.text = money.ToString();
        MoneyCount.text = Mathf.Round(money).ToString();
    }
    // Update is called once per 
    void Update()
    {
        MoneyCount.text = money.ToString();
        MoneyCount.text = Mathf.Round(money).ToString();
        if (DroneSpeedUpgradeBought.DroneSpeedUpgradeBought == true)
        {
            money -= 500;
            DroneSpeedUpgradeBought.DroneSpeedUpgradeBought = false;
        }
    }
    public void SpeedUpButton()
    {
        if (speed._moveSpeed <= MaxSpeed)
        {
            for (int i = 0; i < 1; i++)
            {

                if (money >= StartSpeedUpgradePrice * SpeedInflationPrice)
                {
                    if (Is_Sound_On.is_Sound_On == true)
                    {
                        UpgradeButtonSound.Play();
                    }
                    speed._moveSpeed += 0.5f;

                    money -= StartSpeedUpgradePrice * SpeedInflationPrice;
                    MoneyText();
                    SpeedInflationPrice += 0.2f;
                    SpeedText();
                    // UpgradeButtonSound.Play();
                }
            }
        }
        if (speed._moveSpeed >= MaxSpeed)
        {
            SpeedUpgradeText.text = ("Max Upgrade");
            SpeedUpgradeButton.interactable = (false);
            DisableSpeedText.SetActive(false);
            SpeedUpgradeText.transform.Translate(new Vector3(20, 1, transform.position.z), 0);
            if (Is_Sound_On.is_Sound_On == true)
            {
                MaxUpgradeButtonSound.Play();
            }
        }
    }
    public void GrowUpButton()
    {
        if (GrowthUpgrade <= MaxGrow)
        {


            for (int i = 0; i < 1; i++)
            {
                if (money >= StartGrowthUpgradePrice * GrowthInflationPrice)
                {
                    if (Is_Sound_On.is_Sound_On == true)
                    {
                        UpgradeButtonSound.Play();
                    }
                    GrowthUpgrade += 0.2f;
                    money -= StartGrowthUpgradePrice * GrowthInflationPrice;
                    MoneyText();
                    GrowthText();
                    GrowthInflationPrice += 0.2f;
                    // UpgradeButtonSound.Play();
                }
            }
        }
        if (GrowthUpgrade >= MaxGrow)
        {
            GrowUpgradeText.text = ("Max Upgrade");
            GrowUpgradeButton.interactable = (false);
            DisableGrowthText.SetActive(false);
            GrowUpgradeText.transform.Translate(new Vector3(20, 1, transform.position.z), 0);
            if (Is_Sound_On.is_Sound_On == true)
            {
                MaxUpgradeButtonSound.Play();
            }
        }
    }
    public void MoneyUpButton()
    {
        if (MoneyUpgrade <= MaxMoneyUpgrade)
        {
            for (int i = 0; i < 1; i++)
            {
                if (money >= StartMoneyUpgradePrice * MoneyInflationPrice)
                {
                    if (Is_Sound_On.is_Sound_On == true)
                    {
                        UpgradeButtonSound.Play();
                    }
                    MoneyUpgrade += 0.2f;
                    money -= StartMoneyUpgradePrice * MoneyInflationPrice;
                    MoneyText();
                    MoneyPriceTextVoid();
                    MoneyInflationPrice += 0.2f;
                    //UpgradeButtonSound.Play();
                }
            }
        }
        if (MoneyUpgrade >= MaxMoneyUpgrade)
        {
            MoneyUpgradeText.text = ("Max Upgrade");
            MoneyUpgradeButton.interactable = false;
            DisableMoneyText.SetActive(false);
            MoneyUpgradeText.transform.Translate(new Vector3(20, 1, transform.position.z), 0);
            if (Is_Sound_On.is_Sound_On == true)
            {
                MaxUpgradeButtonSound.Play();
            }
        }
    }
    public void Buy_Multiplyer_Flower()
    {
        Multiplyer_Flower_Object.gameObject.SetActive(true);
        Buy_Multiplyer_Flower_BUTTTON.interactable = false;
        money -= 300; //300=how much to buy flower costs
    }
    public void AddMoney(float value)
    {
        money += value;
    }
    public void DroneBoughtVoid()
    {
        while (DroneBought.DroneWasteMoney == true)
        {
            if (Is_Sound_On.is_Sound_On == true)
            {
                MaxUpgradeButtonSound.Play();
            }
            money -= 1500;
            DroneBought.DroneWasteMoney = false;
            DroneBuyButton.interactable = false;
        }
    }
}
