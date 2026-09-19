using UnityEngine;
using UnityEngine.UI;

public class UpgradeBoardHandler : MonoBehaviour
{
    [SerializeField] private GameObject upgradeBoard;

    [SerializeField] private Image joyStick;
    [SerializeField] private Image joyStickHandle; 

    private bool isUpgradeBoardActive = false;

    public bool IsUpgradeBoardActive => isUpgradeBoardActive;

    public void OnUpgradeBoardButtonClicked()
    {
        SetUpgradeBoardActive(!isUpgradeBoardActive);
        SoundEventBus.RaiseButtonClicked();
    }

    private void SetUpgradeBoardActive(bool isActive)
    {
        isUpgradeBoardActive = isActive;
        joyStick.raycastTarget = !isActive;
        joyStickHandle.raycastTarget = !isActive;
        if (isActive)
         UIEventBus.RaiseUpgradeBoardOpened(upgradeBoard);  
        else
         UIEventBus.RaiseUpgradeBoardClosed(upgradeBoard); 
    }


    private void ForceDisableUpgradeBoard()
    {
        SetUpgradeBoardActive(false);
        isUpgradeBoardActive = false;
    }

    private void OnEnable()
    {
        GameplayEventBus.OnLawnIncreaseCutsceneStarted += ForceDisableUpgradeBoard;
    }
    private void OnDisable()
    {
        GameplayEventBus.OnLawnIncreaseCutsceneStarted -= ForceDisableUpgradeBoard;
    }
}
