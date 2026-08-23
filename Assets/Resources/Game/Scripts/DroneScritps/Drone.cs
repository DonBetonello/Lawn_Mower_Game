using UnityEngine;

public class Drone : MonoBehaviour, ISpawnable
{
    [SerializeField] private DroneData droneData;
    private DroneRuntimeData droneRuntimeData;
    public DroneRuntimeData GetDroneRuntimeData() { return droneRuntimeData; }

    private Stat statManager;

     
    public void Initialize(Stat stats) {
        this.statManager = stats;
        
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
        droneRuntimeData.GetDrone(this.gameObject);
        droneRuntimeData.Upgrade(upgradeData.statType, statManager.GetStat(upgradeData.statType));
    }
}
