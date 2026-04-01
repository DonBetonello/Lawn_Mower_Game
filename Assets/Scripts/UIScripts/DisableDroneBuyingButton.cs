using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisableDroneBuyingButton : MonoBehaviour
{
    [SerializeField] private Upgrades upgrades;
    [SerializeField] private GameObject droneSpeedUpgradeButton;
    [SerializeField] private TextMeshProUGUI buttonText;
    private void OnEnable()
    {
        upgrades.OnDroneUpgradePurchased += DisableButton;
    }
    private void OnDisable()
    {
        upgrades.OnDroneUpgradePurchased -= DisableButton;
    }
    private void DisableButton()
    {
        gameObject.GetComponent<Button>().interactable = false;
        buttonText.text = "Purchased";
        droneSpeedUpgradeButton.GetComponent<UpdateUpgradeButtonUi>().enabled = true;
        droneSpeedUpgradeButton.GetComponent<Button>().interactable = true;
    }

}
