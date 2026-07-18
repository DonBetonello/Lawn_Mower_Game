using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

public class Upgrades : MonoBehaviour
{


    [Tooltip("List of all upgrades scriptable objects. Be sure to add a scriptable object here before trying to add new upgrade button")]
    [SerializeField] private List<UpgradeData> upgrades;

    private Dictionary<UpgradeData, UpgradeRuntimeData> runtimeData = new Dictionary<UpgradeData, UpgradeRuntimeData>();

    private MoneyHandler moneyHandler;

    private GameManager gameManager;
    private SpawnFactory spawnFactory;

    private void Awake()
    {
        moneyHandler = FindFirstObjectByType<MoneyHandler>();
        gameManager = FindAnyObjectByType<GameManager>();
        spawnFactory = FindAnyObjectByType<SpawnFactory>();
        foreach (var upgrade in upgrades)
        {
            runtimeData[upgrade] = new UpgradeRuntimeData(upgrade);
        }
        foreach (var upgrade in upgrades) {
            gameManager.Stats.AddStat(upgrade.statType, upgrade.StartValue);
           
        }
        
    }
    public UpgradeRuntimeData GetRuntimeData(UpgradeData upgrade)
    {

        return runtimeData[upgrade];
    }

    private void OnEnable()
    {
        UpgradesEventBus.OnUpgradePurchased += PurchaseUpgrade;
    }
    private void OnDisable()
    {
        UpgradesEventBus.OnUpgradePurchased -= PurchaseUpgrade;
    }

    public void PurchaseUpgrade(UpgradeData upgrade)
    {
        if (runtimeData[upgrade] == null) { Debug.LogError("Upgrade data is not provided"); return; }
        if (moneyHandler.GetMoney <= runtimeData[upgrade].CurrentCost)
        {
            return;
        }
        
        moneyHandler.RemoveMoney(runtimeData[upgrade].CurrentCost);

        runtimeData[upgrade].Upgrade();
        gameManager.Stats.AddStat(upgrade.statType, runtimeData[upgrade].CurrentValue);
        if (upgrade.specialUpgradeType != SpecialUpgradeType.None) { spawnFactory.Create(upgrade.specialUpgradeType, gameManager.Stats); }
    }

}
