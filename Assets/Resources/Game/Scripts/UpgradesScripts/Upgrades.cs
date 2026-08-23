using UnityEngine;
using System.Collections.Generic;

public class Upgrades : MonoBehaviour
{


    [Tooltip("List of all upgrades scriptable objects. Be sure to add a scriptable object here before trying to add new upgrade button")]
    [SerializeField] private List<UpgradeData> upgrades;

    private Dictionary<UpgradeData, UpgradeRuntimeData> runtimeData = new Dictionary<UpgradeData, UpgradeRuntimeData>();


    [Header("References")]
    [SerializeField] private MoneyHandler moneyHandler;
    [SerializeField] private Stat statManager;
    [SerializeField] private SpawnFactory spawnFactory;
    [SerializeField] private UpgradeUnlock upgradeUnlockHandler;

    private void Start()
    {
        foreach (var upgrade in upgrades)
        {
            runtimeData[upgrade] = new UpgradeRuntimeData(upgrade);
            statManager.AddStat(upgrade.statType, upgrade.StartValue);
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
        if (moneyHandler.GetMoney < runtimeData[upgrade].CurrentCost)
        {
            return;
        }

        moneyHandler.RemoveMoney(runtimeData[upgrade].CurrentCost);
        upgradeUnlockHandler.Unlock(upgrade);
        runtimeData[upgrade].Upgrade(statManager);
        statManager.AddStat(upgrade.statType, runtimeData[upgrade].CurrentValue);
        if (upgrade.specialUpgradeType != SpecialUpgradeType.None) { UpgradesEventBus.RaiseSpecialUpgradePurchased(upgrade); }
        UpgradesEventBus.RaiseUpgradeProcessed(upgrade);
    }
}
