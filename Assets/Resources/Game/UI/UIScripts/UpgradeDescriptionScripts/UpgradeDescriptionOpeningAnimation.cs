using UnityEngine;
using DG.Tweening;

public class UpgradeDescriptionOpeningAnimation : MonoBehaviour
{
     

    private Tween currentTween;
    private void OnEnable()
    {
        UIEventBus.OnUpgradeDescriptionOpened += PlayOpeningAnimation;
        UIEventBus.OnUpgradeDescriptionClosed += PlayClosingAnimation;
    }
    private void OnDisable()
    {
        UIEventBus.OnUpgradeDescriptionOpened -= PlayOpeningAnimation;
        UIEventBus.OnUpgradeDescriptionClosed -= PlayClosingAnimation;
    }


    private void PlayOpeningAnimation(GameObject obj, UpgradeData data)
    {
        currentTween?.Kill();

        var rect = obj.GetComponent<RectTransform>();
        obj.SetActive(true);
        rect.localScale = Vector3.zero;

        currentTween = DOTween.Sequence()
            .Append(rect.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack));
    }

    private void PlayClosingAnimation(GameObject obj)
    {
        currentTween?.Kill();

        var rect = obj.GetComponent<RectTransform>();

        currentTween = DOTween.Sequence()
            .Append(rect.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InBack))
            .AppendCallback(() => obj.SetActive(false));
    }
}
