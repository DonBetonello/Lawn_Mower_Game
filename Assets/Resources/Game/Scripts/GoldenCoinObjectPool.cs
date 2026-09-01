using UnityEngine;
using UnityEngine.Pool;

public class GoldenCoinObjectPool : MonoBehaviour
{
    private IObjectPool<GoldenCoin> objectPool;
    [Header("References")]
    [SerializeField] private GameObject Coin;
    [SerializeField] private Transform poolParent;

    [Header("Settings")]
    [SerializeField] private int defaultCapacity;
    [SerializeField] private int maxCapacity;

    private void Awake()
    {
        objectPool = new ObjectPool<GoldenCoin>(CreateCoin, OnGetFromPool, OnReleaseToPool, OnDestroyObject, false, defaultCapacity, maxCapacity);
    }

    private GoldenCoin CreateCoin()
    {
         
        GameObject coinObject = Instantiate(Coin, poolParent);
        coinObject.transform.Rotate(new Vector3(0, 0, 0));
        GoldenCoin coin = coinObject.GetComponent<GoldenCoin>();
        coin.SetPool(objectPool);

        return coin;
    }
    private void OnGetFromPool(GoldenCoin obj)
    {
        obj.transform.SetParent(null);
        obj.gameObject.SetActive(true);
    }
    private void OnReleaseToPool(GoldenCoin obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(poolParent);
    }
    private void OnDestroyObject(GoldenCoin obj) { Destroy(obj.gameObject); }


    public GoldenCoin GetCoin()
    {
        return objectPool.Get();
    }
}
