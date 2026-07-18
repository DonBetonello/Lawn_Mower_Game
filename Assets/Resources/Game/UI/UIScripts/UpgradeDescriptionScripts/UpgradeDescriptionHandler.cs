using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UpgradeDescriptionHandler : MonoBehaviour
{
    [SerializeField] private GameObject UpgradeDescriptionObject;
    private TextMeshProUGUI UpgradeName;
    private TextMeshProUGUI UpgradeValueChange;
    private TextMeshProUGUI UpgradeLevel;
    private TextMeshProUGUI UpgradePrice;

    private TextMeshProUGUI UpgradeDescription;

    private Upgrades upgrades;

    [SerializeField] Button BuyUpgradeButton;
    [SerializeField] TextMeshProUGUI BuyUpgradeButtonText;

    [SerializeField] BuyUpgradeButton buyUpgradeButtonScript;

    private void Awake()
    {
        upgrades = FindFirstObjectByType<Upgrades>();
        UpgradeDescription = UpgradeDescriptionObject.transform.Find("Description").GetComponent<TextMeshProUGUI>();
        UpgradeName = UpgradeDescriptionObject.transform.Find("Name").GetComponent<TextMeshProUGUI>();
        UpgradeValueChange = UpgradeDescriptionObject.transform.Find("ValueChange").GetComponent<TextMeshProUGUI>();
        UpgradeLevel = UpgradeDescriptionObject.transform.Find("Level").GetComponent<TextMeshProUGUI>();
        UpgradePrice = UpgradeDescriptionObject.transform.Find("Price").GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        UIEventBus.OnUpgradeDescriptionOpened += OnUpgradeDescriptionOpened;
        UIEventBus.OnUpgradeDataRefresh += RefreshDescriptionData;
    }
    private void OnDisable()
    {
        UIEventBus.OnUpgradeDescriptionOpened -= OnUpgradeDescriptionOpened;
        UIEventBus.OnUpgradeDataRefresh -= RefreshDescriptionData;
    }

    private void OnUpgradeDescriptionOpened(GameObject upgradeDescription, UpgradeData upgradeData)
    {
        RefreshDescriptionData(upgradeData);
        buyUpgradeButtonScript.GetCurrentUpgradeData(upgradeData);
    }


    private void RefreshDescriptionData(UpgradeData upgradeData)
    {
        var upgradeRuntimeData = upgrades.GetRuntimeData(upgradeData);
        ManageButtonInteractable(upgradeRuntimeData.isMaxLevelReached());
        if (upgradeRuntimeData.isMaxLevelReached()) { OnMaxUpgradeReached(upgradeRuntimeData); return; }
        if (upgradeRuntimeData != null)
        {

            float currentValue = upgradeRuntimeData.CurrentValue;
            float futureValue = upgradeRuntimeData.getNextUpgradeValue();

            


            UpgradeDescription.text = upgradeRuntimeData.Description;
            UpgradeName.text = upgradeRuntimeData.UpgradeName;
            UpgradeValueChange.text = currentValue.ToString() + upgradeRuntimeData.ValueMeasurment + " → " + futureValue.ToString() + upgradeRuntimeData.ValueMeasurment;
            UpgradeLevel.text = "Lvl: " + upgradeRuntimeData.CurrentLevel.ToString();
            UpgradePrice.text = Mathf.Round(upgradeRuntimeData.CurrentCost).ToString();
        }


    }
    private void OnMaxUpgradeReached(UpgradeRuntimeData upgradeRuntimeData)
    {

        float currentValue = upgradeRuntimeData.CurrentValue;
        UpgradeDescription.text = upgradeRuntimeData.Description;
        UpgradeName.text = upgradeRuntimeData.UpgradeName;
        UpgradeValueChange.text = currentValue.ToString() + upgradeRuntimeData.ValueMeasurment;
        UpgradeLevel.text = "Lvl: " + upgradeRuntimeData.CurrentLevel.ToString();
        UpgradePrice.text = "";

    }
    private void ManageButtonInteractable(bool isInteractable)
    {
        if (isInteractable)
        {
            BuyUpgradeButton.interactable = false;
            BuyUpgradeButtonText.text = "Max";
            BuyUpgradeButtonText.outlineColor = Color.black;
        }
        else
        {
            BuyUpgradeButton.interactable = true;
            BuyUpgradeButtonText.text = "Buy";
            BuyUpgradeButtonText.outlineColor = Color.white;
        }
    }
}
