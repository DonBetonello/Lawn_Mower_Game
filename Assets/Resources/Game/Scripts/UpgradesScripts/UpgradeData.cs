using UnityEngine;

[System.Serializable]
public class UpgradeData 
{
    public enum UpgradeType
    {
        PlayerSpeed,
        Growth,
        Earning,
        DroneSpeed

    }
    public UpgradeType Type;
    public float Value;
    public float IncreaseAmount;

    public int CurrentLevel;

    public int MaxLevel;

    public float StartCost;
    public float CurrentCost;
    public float CostMultiplier;

    public float MaxValue;

    public bool IsMaxUpgradeReached()
    {
        return CurrentLevel >= MaxLevel;
    }
    public void IncreaseValue()
    {
        Value += IncreaseAmount;
        IncreaseLevel();
    }

    private void IncreaseLevel()
    {
        CurrentLevel++;
    }

    public void IncreaseCost()
    {
        CostMultiplier += 0.2f;
        CurrentCost = StartCost * CostMultiplier;
    }

}
