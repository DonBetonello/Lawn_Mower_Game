using System;
using UnityEngine;

public class UIEventBus : MonoBehaviour
{


    public static event Action<GameObject> OnUpgradeBoardOpened;
    public static event Action<GameObject> OnUpgradeBoardClosed;

    public static void RaiseUpgradeBoardOpened(GameObject upgradeBoard)
    {
        OnUpgradeBoardOpened?.Invoke(upgradeBoard);
    }

    public static void RaiseUpgradeBoardClosed(GameObject upgradeBoard)
    {
        OnUpgradeBoardClosed?.Invoke(upgradeBoard);
    }


    public static event Action<GameObject, UpgradeData> OnUpgradeDescriptionOpened;
    public static event Action<GameObject> OnUpgradeDescriptionClosed;

    public static void RaiseUpgradeDescriptionOpened(GameObject upgradeDescription, UpgradeData upgradeData)
    {
        OnUpgradeDescriptionOpened?.Invoke(upgradeDescription, upgradeData);
    }

    public static void RaiseUpgradeDescriptionClosed(GameObject upgradeDescription)
    {
        OnUpgradeDescriptionClosed?.Invoke(upgradeDescription);
    }



    public static event Action<UpgradeData> OnUpgradeDataRefresh;

    public static void RaiseUpgradeDataRefresh(UpgradeData upgradeData)
    {
        OnUpgradeDataRefresh?.Invoke(upgradeData);
    }

    public static event Action OnUpgradeUnlocked;
    public static void RaiseUpgradeUnlocked()
    {
        OnUpgradeUnlocked?.Invoke();
    }

    public static event Action OnPageChanged;
    public static void RaisePageChanged()
    {
        OnPageChanged?.Invoke();
    }

}
