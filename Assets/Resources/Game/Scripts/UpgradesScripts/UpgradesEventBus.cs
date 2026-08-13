using System;
using UnityEngine;

public static class UpgradesEventBus
{
    public static event Action<UpgradeData> OnUpgradePurchased;

    public static void RaiseUpgradePurchased(UpgradeData upgradeData)
    {
        OnUpgradePurchased?.Invoke(upgradeData);
    }

    public static event Action<UpgradeData> OnUpgradeProcessed;
    public static void RaiseUpgradeProcessed(UpgradeData upgradeData)
    {
        OnUpgradeProcessed?.Invoke(upgradeData);
    }

    public static event Action<UpgradeData> OnMaxLelevUpgradePurchased;
    public static void RaiseMaxLevelUpgradePurchased(UpgradeData upgradeData)
    {
        OnMaxLelevUpgradePurchased?.Invoke(upgradeData);
    }


    public static event Action OnDroneUpgradePurchased;
    public static void RaiseDroneUpgradePurchased() {
    OnDroneUpgradePurchased?.Invoke();
    }

    public static event Action<UpgradeData> OnSpecialUpgradePurchased;
    public static void RaiseSpecialUpgradePurchased(UpgradeData upgradeData) {
        OnSpecialUpgradePurchased?.Invoke(upgradeData);
    }
}
