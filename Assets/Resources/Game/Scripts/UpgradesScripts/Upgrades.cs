using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Upgrades : MonoBehaviour
{
    [SerializeField] private UpgradeData speedUpgradeData;
    [SerializeField] private UpgradeData growthUpgradeData;
    [SerializeField] private UpgradeData earningUpgradeData;
    [SerializeField] private UpgradeData droneSpeedUpgradeData;

    private MoneyHandler moneyHandler;

    public UpgradeData SpeedUpgradeData { get => speedUpgradeData; }
    public UpgradeData GrowthUpgradeData { get => growthUpgradeData; }
    public UpgradeData EarningUpgradeData { get => earningUpgradeData; }

    public UpgradeData DroneSpeedUpgradeData { get => droneSpeedUpgradeData; }

 
    [SerializeField] private TextMeshProUGUI MoneyCount;
   

    [SerializeField] private GameObject droneObject;

    [SerializeField] private int droneUpgradeCost = 1500;

    [SerializeField] private GameObject Multiplyer_Flower_Object;
    [SerializeField] private Button Buy_Multiplyer_Flower_BUTTTON;

 

    public event System.Action OnRefreshUI;
    public event System.Action<UpgradeData> OnRefreshUpgradeUI;
    public event System.Action<UpgradeData.UpgradeType> OnReachMaxUpgrade;
  //  public event System.Action OnDroneUpgradePurchased;
    public event System.Action OnMultiplyerFlowerPurchased;


    void Start()
    {           
        moneyHandler = FindFirstObjectByType<MoneyHandler>();
       RefreshUpgradeUI(SpeedUpgradeData);
       RefreshUpgradeUI(GrowthUpgradeData);
       RefreshUpgradeUI(EarningUpgradeData);

    }

    public void MaxUpgradeReached(UpgradeData.UpgradeType upgradeType)
    {
        OnReachMaxUpgrade?.Invoke(upgradeType);
    }

    public void RefreshUI()
    {
       OnRefreshUI?.Invoke();     
    }
    public void RefreshUpgradeUI(UpgradeData upgrade)
    {
        OnRefreshUpgradeUI?.Invoke(upgrade);
    }
    void Update()
    {
        MoneyCount.text = Mathf.Round(moneyHandler.GetMoney).ToString();
       
    }
   

    public void SpeedIncreaseUpgradeButton()
    {    
        PurchaseUpgrade(speedUpgradeData);
    }
    public void GrowthIncreaseUpgradeButton()
    {
        PurchaseUpgrade(growthUpgradeData);       
    }
    public void EarningIncreaseUpgradeButton()
    {
        PurchaseUpgrade(earningUpgradeData);               
        
    }
    public void HanldeMultiplyerFlowerPurchaseMethod()
    {
        OnMultiplyerFlowerPurchased?.Invoke();
        Multiplyer_Flower_Object.gameObject.SetActive(true);
        Buy_Multiplyer_Flower_BUTTTON.interactable = false;
        moneyHandler.RemoveMoney(300); //300=how much to buy flower costs
    }
   
    public void BuyDroneUpgradeButton()
    {
        if (moneyHandler.GetMoney < droneUpgradeCost)
            return;
        moneyHandler.RemoveMoney(droneUpgradeCost);
        droneObject.SetActive(true);
    
        
    }
    public void BuyDroneSpeedUpgradeButton()
    {
       PurchaseUpgrade(droneSpeedUpgradeData);     
    }

    public void PurchaseUpgrade(UpgradeData upgrade)
    {
     
        if (moneyHandler.GetMoney < upgrade.CurrentCost)
            return;

        if (upgrade.IsMaxUpgradeReached()) { 
           MaxUpgradeReached(upgrade.Type);
        return;
        }

        moneyHandler.RemoveMoney(upgrade.CurrentCost);

        upgrade.IncreaseValue();
        upgrade.IncreaseCost();

      
        RefreshUpgradeUI(upgrade);
    }
 
}
