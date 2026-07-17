using System;
using UnityEngine;

public static class UpgradesEventBus
{
    public static event Action<UpgradeData> OnUpgradePurchased;

    public static void RaiseUpgradePurchased(UpgradeData upgradeData)
    {
        OnUpgradePurchased?.Invoke(upgradeData);
    }

    public static event Action<UpgradeData> OnMaxLelevUpgradePurchased;
    public static void RaiseMaxLevelUpgradePurchased(UpgradeData upgradeData)
    {
        OnMaxLelevUpgradePurchased?.Invoke(upgradeData);
    }
}
