using UnityEngine;

public class Flower : MonoBehaviour, ISpawnable
{
    private Stat statManager;
    private FlowerRuntimeData flowerRuntimeData;

    
    public void Initialize(Stat stats)
    {
        
        statManager = stats;
        flowerRuntimeData = new FlowerRuntimeData(
            statManager.GetStat(StatType.FlowerMultiplier),
            statManager.GetStat(StatType.FlowerMultiplierLenght),
            statManager.GetStat(StatType.FlowerMultiplierRespawnTime)          
            );
    }

    private void OnEnable()
    {
        UpgradesEventBus.OnUpgradeProcessed += UpgradeFlower;
    }
    private void OnDisable()
    {
        UpgradesEventBus.OnUpgradeProcessed -= UpgradeFlower;
    }


    private void UpgradeFlower(UpgradeData upgradeData)
    {
        flowerRuntimeData.Upgrade(upgradeData.statType, statManager.GetStat(upgradeData.statType));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "LawnMover")
        {
            GameplayEventBus.RaiseMultiplyerFlowerPickedUp(flowerRuntimeData.MultiplierLenght, flowerRuntimeData.Multiplier, flowerRuntimeData.MultiplierFlowerRespawnTime);     
            Destroy(gameObject);
        }
     
    }
}
