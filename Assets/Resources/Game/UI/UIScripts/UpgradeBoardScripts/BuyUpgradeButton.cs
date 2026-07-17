using Unity.VisualScripting;
using UnityEngine;

public class BuyUpgradeButton : MonoBehaviour
{
    private UpgradeData upgradeData;

    private void OnEnable()
    {
        UIEventBus.OnUpgradeDescriptionOpened += GetCurrentUpgradeData;
    }
    private void OnDisable()
    {
        UIEventBus.OnUpgradeDescriptionOpened += GetCurrentUpgradeData;
 
    }
   private void GetCurrentUpgradeData(GameObject go, UpgradeData currentUpgradeData) //This method is solely used to get current upgradeRuntimeData
    { upgradeData = currentUpgradeData; }


    private void OnUpgradePurchased(UpgradeData upgradeData) {
        UpgradesEventBus.RaiseUpgradePurchased(upgradeData);
        UIEventBus.RaiseUpgradeDataRefresh(upgradeData);
    
    }


    public void OnClick()
    {
        OnUpgradePurchased(upgradeData);    
    }
}
