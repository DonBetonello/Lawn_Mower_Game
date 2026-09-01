using UnityEngine;
using UnityEngine.Pool;
using DG.Tweening;

public class GoldenCoin : MonoBehaviour
{
    private IObjectPool<GoldenCoin> objectPool;
    private Vector3 startSize;


    private void Awake()
    {
        startSize = transform.localScale;
    }
    
    private void OnDisable()
    {
        transform.DOKill();
    }
    public void SetPool(IObjectPool<GoldenCoin> pool)
    {
        objectPool = pool;
    }
    public void playAnimation()
    {
        transform.localScale = Vector3.zero;
        DOTween.Sequence().Append(
        transform.DOMoveY(transform.position.y + 0.2f, 0.3f)
                 .SetEase(Ease.InOutSine))
            .Join(transform.DORotate(new Vector3(0, 360, 0), 0.3f, RotateMode.FastBeyond360)
                 .SetEase(Ease.Linear))
            .Join(transform.DOScale(startSize, 0.3f))
                .SetEase(Ease.Linear)

            .AppendCallback(() => objectPool.Release(this));
    }
}
