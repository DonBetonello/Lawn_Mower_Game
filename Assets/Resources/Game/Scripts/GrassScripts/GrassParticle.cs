using System.Collections;
 
using UnityEngine;
using UnityEngine.Pool;

public class GrassParticle : MonoBehaviour
{
    private IObjectPool<GameObject> objectPool;
 
    private void OnParticleSystemStopped()
    {
        objectPool.Release(gameObject);
    }

    public void SetPool(IObjectPool<GameObject> pool)
    {
        objectPool = pool;
    }
}
