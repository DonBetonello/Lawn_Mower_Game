using UnityEngine;

public class Drone : MonoBehaviour, ISpawnable
{
    [SerializeField] private DroneData droneData;
    private DroneRuntimeData droneRuntimeData;
    public DroneRuntimeData GetDroneRuntimeData() { return droneRuntimeData; }

    private Stat statManager;

    private GameObject drone;
    public void Initialize(Stat stats) {
        this.statManager = stats;
        drone = this.gameObject;
        droneRuntimeData = new DroneRuntimeData(droneData);
        droneRuntimeData.SetCurrentMovingSpeed(stats.GetStat(StatType.DroneSpeed));
        droneRuntimeData.SetCurrentSize(stats.GetStat(StatType.DroneSize));
    }

    private void OnEnable()
    {
        UpgradesEventBus.OnUpgradeProcessed += UpgradeDrone;
    }
    private void OnDisable()
    {
        UpgradesEventBus.OnUpgradeProcessed += UpgradeDrone;
    }

    private void UpgradeDrone(UpgradeData upgradeData)
    {
        droneRuntimeData.GetDrone(drone);
        droneRuntimeData.Upgrade(upgradeData.statType, statManager.GetStat(upgradeData.statType));
    }
}
