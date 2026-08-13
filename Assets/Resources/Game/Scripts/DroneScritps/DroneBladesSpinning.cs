using UnityEngine;
using DG.Tweening;

public class DroneBladesSpinning : MonoBehaviour
{
    [SerializeField] private GameObject droneBlades;
 


    private void OnEnable()
    {
        droneBlades.transform
            .DORotate(new Vector3(-90,360, -90),0.3f)
            .SetEase(Ease.Linear)
            .SetLoops(-1); 
    }
    private void OnDisable()
    {
        transform.DOKill();
    }
    private void OnDestroy()
    {
        transform.DOKill();
    }
}
