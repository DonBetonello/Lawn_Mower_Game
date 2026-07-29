using Unity.VisualScripting;
using UnityEngine;

public class GrassRuntimeData : IUpgradable
{
    private float currentRegrowTime;
    public float CurrentRegrowTime => currentRegrowTime;

    private bool isCurrentlyGold;

    public GrassRuntimeData (GrassData grassData)
    { 
        currentRegrowTime = grassData.StartRegrowTime;
        isCurrentlyGold = grassData.IsGold;
    }

    public void Upgrade(StatType type, float NewValue)
    {
        if (type == StatType.GrassGrowthSpeed) {
            currentRegrowTime = NewValue;
        }
    }
}
