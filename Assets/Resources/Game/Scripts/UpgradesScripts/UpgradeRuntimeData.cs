using UnityEngine;

[System.Serializable]
public class UpgradeRuntimeData
{
    public UpgradeData Config;

    public string UpgradeName;

    public int CurrentLevel;
    public float CurrentValue;
    public float CurrentCost;
    public string ValueMeasurment;
    public string Description;

    public UpgradeRuntimeData(UpgradeData config)
    {
        Config = config;
        ValueMeasurment = config.ValueMeasurment;
        UpgradeName = config.Name;
        CurrentLevel = 0;
        CurrentValue = config.StartValue;
        CurrentCost = config.StartCost;
        Description = config.Description;
    }

    public bool CanUpgrade()
    {
        return CurrentLevel < Config.MaxLevel;
    }
    public bool isMaxLevelReached()
    {
        return Config.MaxLevel <= CurrentLevel ;
    }

    public float getNextUpgradeValue()
    {
        float nextUpgradeValue = CurrentValue + Config.IncreaseAmount;
        return nextUpgradeValue;
    }
 
    public void Upgrade()
    {
        
        if (!CanUpgrade()) { return; }
          
        
        CurrentLevel++;
        CurrentValue += Config.IncreaseAmount;
        CurrentCost *= Config.CostMultiplier;
        if (isMaxLevelReached()) { UpgradesEventBus.RaiseMaxLevelUpgradePurchased(Config); }
    }
}