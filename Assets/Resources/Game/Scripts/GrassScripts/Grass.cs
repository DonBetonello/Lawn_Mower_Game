using UnityEngine;

public class Grass : MonoBehaviour
{
    [SerializeField] private GrassData grassData;
   
    private GrassRuntimeData runtimeData;
    public GrassRuntimeData GetRuntimeData() { return runtimeData; }

    private Stat statManager;


    private int GridX;
    private int GridZ;

    public void SetGridPosition(int x, int z)
    {
        GridX = x;
        GridZ = z;
    }

    private void Awake()
    {
        runtimeData = new GrassRuntimeData(grassData);
    }
    public void Init(Stat stat)
    {     
        statManager = stat;
      
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
        if (runtimeData == null)
            return;

        runtimeData.Upgrade(upgradeData.statType, statManager.GetStat(upgradeData.statType));
    }
   
}
