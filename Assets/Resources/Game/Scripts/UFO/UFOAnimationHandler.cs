using UnityEngine;
using DG.Tweening;


public class UFOAnimationHandler : MonoBehaviour
{
    private void OnEnable()
    {
        transform.DORotate(new Vector3(0, 360, 0), 2f, RotateMode.FastBeyond360)
                 .SetLoops(100, LoopType.Restart)
                 .SetEase(Ease.Linear);

        transform.DOMoveY(transform.position.y + 0.5f, 1.5f)
                 .SetLoops(100, LoopType.Yoyo)
                 .SetEase(Ease.InOutSine);

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
