using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class Upgrades : MonoBehaviour
{
    [SerializeField] private List<UpgradeData> upgrades;

   private Dictionary<UpgradeData, UpgradeRuntimeData> runtimeData = new Dictionary<UpgradeData, UpgradeRuntimeData> ();

    private MoneyHandler moneyHandler;
 
    [SerializeField] private TextMeshProUGUI MoneyCount;
   
    [SerializeField] private GameObject droneObject;

    [SerializeField] private int droneUpgradeCost = 1500;

    [SerializeField] private GameObject Multiplyer_Flower_Object;
    [SerializeField] private Button Buy_Multiplyer_Flower_BUTTTON;

 
    public event System.Action OnMultiplyerFlowerPurchased;


    private void Awake()
    {
        foreach (var upgrade in upgrades)
        {
            runtimeData[upgrade] = new UpgradeRuntimeData(upgrade);
        }
    }
    public UpgradeRuntimeData GetRuntimeData(UpgradeData upgrade)
        { return runtimeData[upgrade]; }


    void Start()
    {           
        moneyHandler = FindFirstObjectByType<MoneyHandler>();
    }

    private void OnEnable()
    {
        UpgradesEventBus.OnUpgradePurchased += PurchaseUpgrade;
    }
    private void OnDisable()
    {
        UpgradesEventBus.OnUpgradePurchased -= PurchaseUpgrade;
        
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
   //    PurchaseUpgrade(droneSpeedUpgradeData);     
    }
    
    public void PurchaseUpgrade(UpgradeData upgrade)
    {

        if (moneyHandler.GetMoney <= runtimeData[upgrade].CurrentCost)
        {
       
            return;
        }
        
        moneyHandler.RemoveMoney(runtimeData[upgrade].CurrentCost);

        runtimeData[upgrade].Upgrade();
 
    }
 
}
