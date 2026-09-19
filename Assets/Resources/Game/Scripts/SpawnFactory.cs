using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFactory : MonoBehaviour
{
    [SerializeField] GameObject dronePrefab;
    [SerializeField] GameObject flowerPrefab;
    [SerializeField] GameObject ufoPrefab;
    [SerializeField] private RandomSpawningPositionProvider spawningPositionProvider;
    [SerializeField] private UFOSpawningPositionProvider ufoSpawningPositionProvider;
    private Dictionary<SpecialUpgradeType, GameObject> prefabs;

    [SerializeField] GameObject ScaleParent;

    [SerializeField] Stat statManager;

    private void Awake()
    {

        prefabs = new Dictionary<SpecialUpgradeType, GameObject>()
    {
        { SpecialUpgradeType.Drone, dronePrefab },
        { SpecialUpgradeType.Flower, flowerPrefab },
            {SpecialUpgradeType.UFO, ufoPrefab  },
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
        if (upgradeData.specialUpgradeType != SpecialUpgradeType.None
            && upgradeData.specialUpgradeType != SpecialUpgradeType.LawnIncrease1
            && upgradeData.specialUpgradeType != SpecialUpgradeType.LawnIncrease2
            && upgradeData.specialUpgradeType != SpecialUpgradeType.LawnIncrease3
            && upgradeData.specialUpgradeType != SpecialUpgradeType.LawnIncrease4)
        {
            Create(upgradeData.specialUpgradeType, statManager);
        }

    }
    

    public ISpawnable Create(SpecialUpgradeType type, Stat stat)
    {
        var prefab = prefabs[type];
        var obj = Instantiate(prefab);
        if (type == SpecialUpgradeType.UFO)
        {
            obj.transform.position = ufoSpawningPositionProvider.GetRandomPosition();
        }
        else
        {
            obj.transform.position = spawningPositionProvider.GetRandomPosition();
        }

        var spawnable = obj.GetComponent<ISpawnable>();
        spawnable.Initialize(stat);

        obj.transform.SetParent(ScaleParent.transform);

        return spawnable;
    }
}
