using UnityEngine;


public class UpgradeRuntimeData
{
    public UpgradeData Config;

    public string UpgradeName;

    public int CurrentLevel;
    public float CurrentValue;
    public float CurrentCost;
    public string ValueMeasurment;
    public string Description;

    public StatType StatType;

    public bool IsUnlocked;

    public UpgradeRuntimeData(UpgradeData config)
    {
        Config = config;
        ValueMeasurment = config.ValueMeasurment;
        UpgradeName = config.Name;
        CurrentLevel = 0;
        CurrentValue = config.StartValue;
        CurrentCost = config.StartCost;
        Description = config.Description;
        StatType = config.statType;
        IsUnlocked = false;
    }

    public bool CanUpgrade()
    {
        return CurrentLevel < Config.MaxLevel;
    }
    public bool isMaxLevelReached()
    {
        return Config.MaxLevel <= CurrentLevel ;
    }

    public float getNextUpgradeValue(Stat statManager)
    {
        float nextUpgradeValue = statManager.GetStat(StatType) + Config.IncreaseAmount;
        return nextUpgradeValue;
    }
 
    public void Upgrade(Stat statManager)
    {
        
        if (!CanUpgrade()) { return; }
          
        IsUnlocked = true;
        CurrentLevel++;
        CurrentValue = statManager.GetStat(StatType);
        CurrentValue += Config.IncreaseAmount;
        CurrentCost *= Config.CostMultiplier;
        if (isMaxLevelReached()) { UpgradesEventBus.RaiseMaxLevelUpgradePurchased(Config); }
    }
}