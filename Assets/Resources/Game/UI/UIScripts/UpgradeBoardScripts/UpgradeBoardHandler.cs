using UnityEngine;

public class UpgradeBoardHandler : MonoBehaviour
{
    [SerializeField] private GameObject upgradeBoard;

    [SerializeField] private GameObject joyStick;

    private bool isUpgradeBoardActive = false;

    public void OnUpgradeBoardButtonClicked()
    {
        SetUpgradeBoardActive(!isUpgradeBoardActive);
    }

    private void SetUpgradeBoardActive(bool isActive)
    {
        isUpgradeBoardActive = isActive;
        joyStick.SetActive(!isActive);
        if (isActive)
         UIEventBus.RaiseUpgradeBoardOpened(upgradeBoard);  
        else
         UIEventBus.RaiseUpgradeBoardClosed(upgradeBoard); 
    }
}
