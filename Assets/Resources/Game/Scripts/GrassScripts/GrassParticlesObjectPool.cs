
using UnityEngine;
using UnityEngine.Pool;
public class GrassParticlesObjectPool : MonoBehaviour
{
   private IObjectPool<GameObject> objectPool;
    [Header("References")]
    [SerializeField]private GameObject[] particles;
    [SerializeField] private Transform poolParent;

    [Header("Settings")]
    [SerializeField] private int defaultCapacity;
    [SerializeField] private int maxCapacity;

    private void Awake()
    {
        objectPool = new ObjectPool<GameObject>(CreateParticle, OnGetFromPool, OnReleaseToPool, OnDestroyObject, false, defaultCapacity, maxCapacity);
    }



    private GameObject CreateParticle()
    {
        int getRandomParticle = Random.Range(0, particles.Length);
        GameObject particleObject = Instantiate(particles[getRandomParticle], poolParent);

        GrassParticle particle = particleObject.GetComponent<GrassParticle>();
        particle.SetPool(objectPool);    

        return particleObject;
    }
    private void OnGetFromPool(GameObject obj) {
        obj.transform.SetParent(null);
        obj.SetActive(true);
        obj.GetComponent<ParticleSystem>().Play();
    }
    private void OnReleaseToPool(GameObject obj) {
        obj.SetActive(false);
        obj.transform.SetParent(poolParent);
    }
    private void OnDestroyObject(GameObject obj) { Destroy(obj); }


    public GameObject GetParticle()
    {
        return objectPool.Get();
    }
}
