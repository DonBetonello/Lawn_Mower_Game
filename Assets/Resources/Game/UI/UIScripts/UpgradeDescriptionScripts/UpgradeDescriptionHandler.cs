using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UpgradeDescriptionHandler : MonoBehaviour
{
    private Upgrades upgrades;

    [Header("Upgrade description references")]
    [SerializeField] private TextMeshProUGUI UpgradeName;
    [SerializeField] private TextMeshProUGUI UpgradeValueChange;
    [SerializeField] private TextMeshProUGUI UpgradeLevel;
    [SerializeField] private TextMeshProUGUI UpgradePrice;
    [SerializeField] private TextMeshProUGUI UpgradeDescription;

    [Header("Buy button refrences")]
    [SerializeField] Button BuyUpgradeButton;
    [SerializeField] TextMeshProUGUI BuyUpgradeButtonText;

    [SerializeField] BuyUpgradeButton buyUpgradeButtonScript;

    [Header("Other references")]
    [SerializeField] private Stat statsManager;

    private void Awake()
    {
        upgrades = FindFirstObjectByType<Upgrades>();
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

            float currentValue = Mathf.Round(statsManager.GetStat(upgradeRuntimeData.StatType) * 10) * 0.1f;
            float futureValue = Mathf.Round(upgradeRuntimeData.getNextUpgradeValue(statsManager) * 10) * 0.1f;




            UpgradeDescription.text = upgradeRuntimeData.Description;
            UpgradeName.text = upgradeRuntimeData.UpgradeName;
            if (upgradeRuntimeData.StatType != StatType.None) { UpgradeValueChange.text = currentValue.ToString() + upgradeRuntimeData.ValueMeasurment + " → " + futureValue.ToString() + upgradeRuntimeData.ValueMeasurment; }
            else { UpgradeValueChange.text = ""; }
            UpgradeLevel.text = "Lvl: " + upgradeRuntimeData.CurrentLevel.ToString();
            UpgradePrice.text = Mathf.Round(upgradeRuntimeData.CurrentCost).ToString();
        }


    }
    private void OnMaxUpgradeReached(UpgradeRuntimeData upgradeRuntimeData)
    {
       
        float currentValue = Mathf.Round(statsManager.GetStat(upgradeRuntimeData.StatType) * 10) * 0.1f;
        UpgradeDescription.text = upgradeRuntimeData.Description;
        UpgradeName.text = upgradeRuntimeData.UpgradeName;

        if (upgradeRuntimeData.StatType != StatType.None) { UpgradeValueChange.text = currentValue.ToString() + upgradeRuntimeData.ValueMeasurment; }
        else { UpgradeValueChange.text = ""; }
       
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
