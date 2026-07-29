using UnityEngine;

public class Grass : MonoBehaviour
{
    [SerializeField] private GrassData grassData;
   
    private GrassRuntimeData runtimeData;
    public GrassRuntimeData GetRuntimeData() { return runtimeData; }

    private Stat statManager;

    private void Awake()
    {  
        statManager = FindFirstObjectByType<Stat>();
        runtimeData = new GrassRuntimeData(grassData);
       
    }

    private void OnEnable()
    {
        UpgradesEventBus.OnUpgradeProcessed += UpgradeGrass;
    }
    private void OnDisable()
    {
        UpgradesEventBus.OnUpgradeProcessed -= UpgradeGrass;
    }

    private void UpgradeGrass(UpgradeData upgradeData) {
        runtimeData.Upgrade(upgradeData.statType, statManager.GetStat(upgradeData.statType));
    }
    
}
