using Unity.VisualScripting;
using UnityEngine;

public class BuyUpgradeButton : MonoBehaviour
{
    private UpgradeData upgradeData;

   
   public void GetCurrentUpgradeData(UpgradeData currentUpgradeData) //This method is solely used to get current upgradeData
    { upgradeData = currentUpgradeData; }


    private void OnUpgradePurchased(UpgradeData upgradeData) {

        if (upgradeData == null) { Debug.LogError("UpgradeData was not provided"); return; }
        UpgradesEventBus.RaiseUpgradePurchased(upgradeData);
        UIEventBus.RaiseUpgradeDataRefresh(upgradeData);
        
    }


    public void OnClick()
    {
        
        OnUpgradePurchased(upgradeData);
        SoundEventBus.RaiseButtonClicked();
    }
}
