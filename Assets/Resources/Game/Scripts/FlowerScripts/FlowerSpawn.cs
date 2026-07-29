using System.Collections;
using UnityEngine;

public class FlowerSpawn : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private SpawnFactory spawnFactory;
    [SerializeField] private Stat statsManager;
    private RandomSpawningPositionProvider randomPosProvider;


    private void Start()
    {
        randomPosProvider = FindFirstObjectByType<RandomSpawningPositionProvider>();
    }
    private IEnumerator SpawnLoop(float respawnTime)
    {
        yield return new WaitForSeconds(respawnTime);
        SpawnFlower();
    }

    private void SpawnFlower()
    {
        Vector3 randomPosition = randomPosProvider.GetRandomPosition();
        var respawnTime = statsManager.GetStat(StatType.FlowerMultiplierRespawnTime);
        StopCoroutine(SpawnLoop(respawnTime));
        spawnFactory.Create(
            SpecialUpgradeType.FlowerBuying,
            statsManager,
            randomPosition
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
