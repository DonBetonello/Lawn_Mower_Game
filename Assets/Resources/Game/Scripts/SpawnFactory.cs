using System.Collections.Generic;
using UnityEngine;

public class SpawnFactory : MonoBehaviour 
{
    [SerializeField] GameObject dronePrefab;
    [SerializeField] GameObject flowerPrefab;
 

    private Dictionary<SpecialUpgradeType, GameObject> prefabs;

    private void Awake()
    {
        prefabs = new Dictionary<SpecialUpgradeType, GameObject>()
    {
        { SpecialUpgradeType.DroneBuying, dronePrefab },
        { SpecialUpgradeType.FlowerBuying, flowerPrefab }
    };
    }

    public ISpawnable Create(SpecialUpgradeType type, Stat stat)
    {
        var prefab = prefabs[type];
        var obj = Instantiate(prefab);

        var spawnable = obj.GetComponent<ISpawnable>();
        spawnable.Initialize(stat);

        return spawnable;
    }
}
