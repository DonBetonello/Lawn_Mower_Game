using Unity.VisualScripting;
using UnityEngine;

public class GrassRuntimeData : IUpgradable
{
    private float currentRegrowTime;
    public float CurrentRegrowTime => currentRegrowTime;

    private bool isGolden;
    public bool IsGolden => isGolden;

    public GrassRuntimeData(GrassData grassData)
    {
        currentRegrowTime = grassData.StartRegrowTime;
        isGolden = grassData.IsGold;
    }

    public void Upgrade(StatType type, float NewValue)
    {
        if (type == StatType.GrassGrowthSpeed) {
            currentRegrowTime = NewValue;
        }
    }

    public void manageBeingGolden(bool IsGolden)
    {
        isGolden = IsGolden;
    }
}
