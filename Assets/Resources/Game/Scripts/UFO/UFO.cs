using System.Collections;
using UnityEngine;

public class UFO : MonoBehaviour, ISpawnable
{
     private GameObject ufoObject;
     private UFORuntimeData UFORuntimeData;

    private Stat statManager;

    public void Initialize(Stat stats)
    {
        statManager = stats;
        UFORuntimeData = new UFORuntimeData(
            statManager.GetStat(StatType.UFOSize),
            statManager.GetStat(StatType.UFORespawnTime),
            statManager.GetStat(StatType.UFOGoldenMultiplier)
            );
        ufoObject = this.gameObject;
        ManageUFOSize();
    }

    private void OnEnable()
    {
        UpgradesEventBus.OnUpgradeProcessed += UpgradeUFO;
        StartCoroutine(DestroyCoroutine());
     
    }
    private void OnDisable()
    {
        UpgradesEventBus.OnUpgradeProcessed += UpgradeUFO;
    }
    private void UpgradeUFO(UpgradeData upgradeData) {
        UFORuntimeData.Upgrade(upgradeData.statType, statManager.GetStat(upgradeData.statType));
        
    }

    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(5);

        GameplayEventBus.RaiseUFODisappeared();

        yield return new WaitForEndOfFrame();

        Destroy(gameObject);
    }
    private void ManageUFOSize()
    {

        ufoObject.transform.localScale = ufoObject.transform.localScale * statManager.GetStat(StatType.UFOSize);
    }
}
