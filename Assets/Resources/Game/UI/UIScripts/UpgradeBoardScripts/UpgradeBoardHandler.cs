using UnityEngine;

public class UpgradeBoardHandler : MonoBehaviour
{
    [SerializeField] private GameObject UpgradeBoard;

    [SerializeField] private GameObject UpgradeDescription;

    private UpgradeData upgradeData;

    private bool isUpgradeBoardActive = false;

    public void OnUpgradeBoardButtonClicked()
    {
        SetUpgradeBoardActive(!isUpgradeBoardActive);
    }

    private void SetUpgradeBoardActive(bool isActive)
    {
        isUpgradeBoardActive = isActive;
      
        if (isActive)
            UIEventBus.RaiseUpgradeBoardOpened(UpgradeBoard);
        else
            UIEventBus.RaiseUpgradeBoardClosed(UpgradeBoard);
    }

    public void OnUpgradeDescriptionButtonClicked()
    {
        SetUpgradeDescriptionActive(!UpgradeDescription.activeSelf);
    }

    private void SetUpgradeDescriptionActive(bool isActive)
    {
        if (isActive)
            UIEventBus.RaiseUpgradeDescriptionOpened(UpgradeDescription, GetUpgradeData(upgradeData));
        else
            UIEventBus.RaiseUpgradeDescriptionClosed(UpgradeDescription);
    }

    public UpgradeData GetUpgradeData(UpgradeData upgradeData)
    {
        this.upgradeData = upgradeData;
        return this.upgradeData;
    }
}
