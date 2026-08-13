using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFactory : MonoBehaviour 
{
    [SerializeField] GameObject dronePrefab;
    [SerializeField] GameObject flowerPrefab;
    [SerializeField] private RandomSpawningPositionProvider spawningPositionProvider;

    private Dictionary<SpecialUpgradeType, GameObject> prefabs;

    [SerializeField] Stat statManager;

    private void Awake()
    {
        
        prefabs = new Dictionary<SpecialUpgradeType, GameObject>()
    {
        { SpecialUpgradeType.DroneBuying, dronePrefab },
        { SpecialUpgradeType.FlowerBuying, flowerPrefab }
    };
    }


    private void OnEnable()
    {
        UpgradesEventBus.OnSpecialUpgradePurchased += createObject;
    }
    private void OnDisable()
    {
        UpgradesEventBus.OnSpecialUpgradePurchased -= createObject;
    }
    private void createObject(UpgradeData upgradeData)
    {
       if(upgradeData.specialUpgradeType == SpecialUpgradeType.DroneBuying) { Create(upgradeData.specialUpgradeType, statManager); }
       else if ( upgradeData.specialUpgradeType == SpecialUpgradeType.FlowerBuying )
        { Create(upgradeData.specialUpgradeType, statManager); }  


    }

    public ISpawnable Create(SpecialUpgradeType type, Stat stat)
    {
        var prefab = prefabs[type];
        var obj = Instantiate(prefab);
        obj.transform.position = spawningPositionProvider.GetRandomPosition();
        var spawnable = obj.GetComponent<ISpawnable>();
        spawnable.Initialize(stat);
     
        return spawnable;
    }
}
