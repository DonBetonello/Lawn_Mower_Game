using System.Collections;
using UnityEngine;

public class FlowerSpawn : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private SpawnFactory spawnFactory;
    [SerializeField] private Stat statsManager;


    private IEnumerator SpawnLoop(float respawnTime)
    {
        yield return new WaitForSeconds(respawnTime);
        SpawnFlower();
    }

    private void SpawnFlower()
    {
    
        var respawnTime = statsManager.GetStat(StatType.FlowerMultiplierRespawnTime);
        StopCoroutine(SpawnLoop(respawnTime));
        spawnFactory.Create(
            SpecialUpgradeType.FlowerBuying,
            statsManager       
        );
    }
    private void OnEnable()
    {
        GameplayEventBus.OnMultiplyerFlowerPickedUp += StartRespawn;
    }
    private void OnDisable()
    {
        GameplayEventBus.OnMultiplyerFlowerPickedUp -= StartRespawn;
    }
    private void StartRespawn(float multiplierLenght, float multiplier, float respawnTime)
    {
        StartCoroutine(SpawnLoop(respawnTime));
    }

}
