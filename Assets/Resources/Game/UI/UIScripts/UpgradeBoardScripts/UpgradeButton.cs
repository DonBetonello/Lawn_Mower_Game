using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private UpgradeData upgradeData;
    [SerializeField] private GameObject upgradeDescriptionObject;
    private void OnClick()
    {
        if (upgradeData != null)
        {
            UIEventBus.RaiseUpgradePurchased(upgradeData);
            UIEventBus.RaiseUpgradeDescriptionOpened(upgradeDescriptionObject, upgradeData);
        }
    }
    
}