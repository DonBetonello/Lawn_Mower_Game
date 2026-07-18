using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeData", menuName = "Scriptable Objects/Upgrade Data")]
public class UpgradeData : ScriptableObject
{
    [Tooltip("Enum to describe the stat that upgrade is increasing. Can be 'None'")]
    public StatType statType;

    [Tooltip("Enum to trigger special upgrade events, in example as buying a drone or a flower. Can be 'None'")]
    public SpecialUpgradeType specialUpgradeType;

    [Tooltip("Name of the upgrade")]
    public string Name;

    [Tooltip("The amount by which the value will increase after purchasing the upgrade")]
    public float IncreaseAmount;

    [Tooltip("Measurment that will stand near a value, in example as `%` or `m/s`")]
    public string ValueMeasurment;

    [Tooltip("Upgrades starting value")]
    public float StartValue;

    [Tooltip("Upgrades starting lelev")]
    public int StartLevel;

    [Tooltip("Upgrades maximum level")]
    public int MaxLevel;

    [Tooltip("Upgrades starting cost")]
    public float StartCost;

    [Tooltip("The multiplyer by which next upgrade cost will increase")]
    public float CostMultiplier;

    [Tooltip("Description of what upgrade is supposed to do")]
    public string Description;
}
