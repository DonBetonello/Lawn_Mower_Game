using System;
using UnityEngine;

public class OpenDescriptionButton : MonoBehaviour
{
    [SerializeField] private UpgradeData upgradeData;
    [SerializeField] private GameObject upgradeDescriptionObject;
    [SerializeField] private GameObject OnMaxUpgradeBackgroundChangeObject;
    private DescriptionPositioner positioner;

    private void Awake()
    {
        positioner = upgradeDescriptionObject.GetComponent<DescriptionPositioner>();
    }

    private void OnEnable()
    {
        UpgradesEventBus.OnMaxLelevUpgradePurchased += OnMaxUpgradeReached;
    }
    private void OnDisable()
    {
        UpgradesEventBus.OnMaxLelevUpgradePurchased -= OnMaxUpgradeReached;
    }


    public void OnClick()
    {
        var  myRect =  GetComponent<RectTransform>();

        
        if (DescriptionState.currentTarget == myRect)
        {
            if (DescriptionState.isOpen)
            {
                UIEventBus.RaiseUpgradeDescriptionClosed(DescriptionState.currentTooltip);
                DescriptionState.isOpen = false;
            }
            else
            {
                Open();
            }

            return;
        }

        if (DescriptionState.currentTooltip != null)
        {
            UIEventBus.RaiseUpgradeDescriptionClosed(DescriptionState.currentTooltip);
        }

        Open();
    }

    private void Open()
    {
        var myRect = GetComponent<RectTransform>();

        positioner.Show(myRect);
        UIEventBus.RaiseUpgradeDescriptionOpened(upgradeDescriptionObject, upgradeData);

        DescriptionState.currentTarget = myRect;
        DescriptionState.currentTooltip = upgradeDescriptionObject;
        DescriptionState.isOpen = true;
    }

    private void OnMaxUpgradeReached(UpgradeData upgradeData)
    {

        if (upgradeData == this.upgradeData)
        {
            OnMaxUpgradeBackgroundChangeObject.SetActive(true);
        }
    }
    public static class DescriptionState
    {
        public static RectTransform currentTarget;
        public static GameObject currentTooltip;
        public static bool isOpen = false;
    }
}