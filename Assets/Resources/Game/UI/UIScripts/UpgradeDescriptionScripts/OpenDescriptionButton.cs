using System;
using UnityEngine;
using DG.Tweening;

public class OpenDescriptionButton : MonoBehaviour
{
    [SerializeField] private UpgradeData upgradeData;
    public UpgradeData UpgradeData => upgradeData;
    [SerializeField] private GameObject upgradeDescriptionObject;
    [SerializeField] private GameObject OnMaxUpgradeBackgroundChangeObject;
    private DescriptionPositioner positioner;
    [SerializeField] private UpgradeUnlock upgradeUnlockHandler;

    private void Awake()
    {
        positioner = upgradeDescriptionObject.GetComponent<DescriptionPositioner>();
        if (upgradeData.requiredUpgrades.Capacity > 0) { gameObject.transform.localScale = Vector3.zero; }
    }

    private void OnEnable()
    {
        UpgradesEventBus.OnUpgradeProcessed += OnUnlocked;
        UpgradesEventBus.OnMaxLelevUpgradePurchased += OnMaxUpgradeReached;
    }
    private void OnDisable()
    {
        UpgradesEventBus.OnUpgradeProcessed -= OnUnlocked;
        UpgradesEventBus.OnMaxLelevUpgradePurchased -= OnMaxUpgradeReached;
    }

    private void OnUnlocked(UpgradeData data)
    {
        if(upgradeUnlockHandler == null) { return; }

        if (upgradeUnlockHandler.CanUnlock(this.upgradeData))
        {
            gameObject.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);

        }
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