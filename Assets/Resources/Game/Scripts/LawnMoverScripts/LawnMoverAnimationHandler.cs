using UnityEngine;
using DG.Tweening;
public class LawnMoverAnimationHandler : MonoBehaviour
{
    private Sequence sequence;
    private Vector3 startSize;
    private bool isAlreadyPlaying;
    [SerializeField] private ParticleSystem smokeParticle;
    
    private void Awake()
    {
        startSize = transform.localScale;
    }

    private void OnEnable()
    {
        GameplayEventBus.OnLawnMoverStartedMoving += PlayMovingAnimation;
        GameplayEventBus.OnLawnMoverStoppedMoving += StopMovingAnimation;
    }
    private void OnDisable()
    {
        GameplayEventBus.OnLawnMoverStartedMoving -= PlayMovingAnimation;
        GameplayEventBus.OnLawnMoverStoppedMoving -= StopMovingAnimation;
    }

    public void PlayMovingAnimation() {
       
        if (isAlreadyPlaying) { return; }
        
        GameObject lawnMover = gameObject;

        sequence = DOTween.Sequence();
        smokeParticle.Play();
        sequence
            .AppendCallback(() => isAlreadyPlaying = true)
     
            .Append(lawnMover.transform.DOScale(startSize*1.05f, 0.5f)
            
            .SetEase(Ease.InOutSine)
            
            .SetLoops(-1, LoopType.Yoyo));
    }

    public void StopMovingAnimation() {
        gameObject.transform.DOScale(startSize, 0.1f);
        sequence.Kill();
        isAlreadyPlaying = false;
        smokeParticle.Stop();
    }
}
