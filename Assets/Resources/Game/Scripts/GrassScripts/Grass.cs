using System.Collections;
using UnityEngine;

public class Grass : MonoBehaviour
{


    [SerializeField] private GrassData grassData;
   
    private GrassRuntimeData runtimeData;
    public GrassRuntimeData RuntimeData => runtimeData;
    private Stat statManager;

    private float regrowTime;
    public float RegrowTime  => regrowTime;

    private int GridX;
    private int GridZ;

    [SerializeField] private GrassTurningGoldenAnimation grassTurningGoldenAnimation;


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
        regrowTime = statManager.GetStat(StatType.GrassGrowthSpeed);
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
        regrowTime = statManager.GetStat(StatType.GrassGrowthSpeed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("UFO"))
        {
            ManageGrassGolden(true);
            StartCoroutine(TurnGrassBackToNormal());
        }
    }
    private IEnumerator TurnGrassBackToNormal()
    {
        yield return new WaitForSeconds(7);
        ManageGrassGolden(false);
    }

    public bool IsGrassGolden()
    {
        return runtimeData.IsGolden;
    }
    public void ManageGrassGolden(bool IsGolden)
    {
        runtimeData.manageBeingGolden(IsGolden);

        if(!IsGolden) { grassTurningGoldenAnimation.ForceBecomeNormal(); }
    }
}
