using System.Collections;
using UnityEngine;

public class UFOSpawn : MonoBehaviour
{
    [SerializeField] private SpawnFactory spawnFactory;
    [SerializeField] private Stat statsManager;
    

    IEnumerator SpawnLoop(float respawnTime)
    {
        yield return new WaitForSeconds(respawnTime);
        spawnFactory.Create(SpecialUpgradeType.UFO, statsManager);
    }

    private void OnEnable()
    {
        GameplayEventBus.OnUFODisappeared += StartUFORespawn;
    }
    private void OnDisable()
    {
        GameplayEventBus.OnUFODisappeared -= StartUFORespawn;
    }

    private void StartUFORespawn()
    {
        StartCoroutine(SpawnLoop(statsManager.GetStat(StatType.UFORespawnTime)));

    }
}
