using DG.Tweening;
using System.Linq;
using UnityEngine;

public class FlowerAnimationHandler : MonoBehaviour
{
    private Sequence[] sequences;
    private void OnEnable()
    {
        sequences = new Sequence[3];

        
        var spawnSequence = DOTween.Sequence();
        sequences[2] = spawnSequence;
        GameObject go = this.gameObject;

        Vector3 startScale = go.transform.localScale;
        go.transform.localScale = Vector3.zero;

        spawnSequence.Append(transform.DOScale(startScale, 0.3f)).OnComplete(() => spawnSequence.Kill());

        var rotateSequence = DOTween.Sequence();
        sequences[0] = rotateSequence; 
        

        sequences[0].Append(transform.DORotate(new Vector3(0, 360, 0), 2f, RotateMode.FastBeyond360)
                 .SetLoops(-1, LoopType.Restart)
                 .SetEase(Ease.Linear));

        var howerSequence = DOTween.Sequence();
        sequences[1] = howerSequence;
        sequences[1] = DOTween.Sequence();
        sequences[1].Append(transform.DOMoveY(transform.position.y + 0.5f, 1.5f)
                 .SetLoops(-1, LoopType.Yoyo)
                 .SetEase(Ease.InOutSine));
    }
    private void OnDisable()
    {
        foreach (var sequence in sequences)
        {
            sequence.Kill();
        }
    }

    private void OnDestroy()
    {
        foreach (var sequence in sequences)
        {
            sequence.Kill();
        }
    }
}
