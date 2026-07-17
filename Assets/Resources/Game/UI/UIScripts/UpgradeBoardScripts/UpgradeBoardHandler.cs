using UnityEngine;

public class UpgradeBoardHandler : MonoBehaviour
{
    [SerializeField] private GameObject UpgradeBoard;

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
}
