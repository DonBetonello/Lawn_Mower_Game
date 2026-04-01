using UnityEngine;

[System.Serializable]
public class UpgradeData 
{
    public enum UpgradeType
    {
        SpeedUpgrade,
        GrowthUpgrade,
        EarningUpgrade,
        DroneSpeedUpgrade

    }
    public UpgradeType Type;
    public float Value;
    public float IncreaseAmount;

    public float StartCost;
    public float CurrentCost;
    public float CostMultiplier;

    public float MaxValue;

    public bool IsMaxUpgradeReached()
    {
        return Value >= MaxValue;
    }
    public void IncreaseValue()
    {
        Value += IncreaseAmount;
    }

    public void IncreaseCost()
    {
        CostMultiplier += 0.2f;
        CurrentCost = StartCost * CostMultiplier;
    }

}
