using UnityEngine;

public class Drone : MonoBehaviour, ISpawnable
{
    [SerializeField] private DroneData droneData;
    private DroneRuntimeData droneRuntimeData;
    public DroneRuntimeData GetDroneRuntimeData() { return droneRuntimeData; }

    private Stat stats;

    public void Initialize(Stat stats) {
        this.stats = stats;
        droneRuntimeData = new DroneRuntimeData(droneData);
        droneRuntimeData.SetCurrentMovingSpeed(stats.GetStat(StatType.DroneSpeed));
        droneRuntimeData.SetCurrentSize(stats.GetStat(StatType.DroneSize));
    }

    private void OnEnable()
    {
        UpgradesEventBus.OnUpgradePurchased += UpgradeDrone;
    }
    private void OnDisable()
    {
        UpgradesEventBus.OnUpgradePurchased += UpgradeDrone;
    }

    private void UpgradeDrone(UpgradeData upgradeData)
    {
        droneRuntimeData.ApllyUpgrade(upgradeData.statType, stats.GetStat(upgradeData.statType));
    }
}
