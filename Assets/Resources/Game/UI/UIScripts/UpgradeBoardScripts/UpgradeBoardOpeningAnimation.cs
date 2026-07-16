using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UpgradeBoardOpeningAnimation : MonoBehaviour
{

    // [SerializeField] private Button openingButton;
   
    private void Awake()
    {
        
    }
    private void OnEnable()
    {
        UIEventBus.OnUpgradeBoardOpened += PlayOpeningAnimation;
        UIEventBus.OnUpgradeBoardClosed += PlayClosingAnimation;
    }
    private void OnDisable()
    {
        UIEventBus.OnUpgradeBoardOpened -= PlayOpeningAnimation;
        UIEventBus.OnUpgradeBoardClosed -= PlayClosingAnimation;
    }

    private void PlayOpeningAnimation(GameObject upgradeBoard)
    {

        var canvasGroup = upgradeBoard.GetComponentInParent<CanvasGroup>();
        var upgradeBoardRectTransform = upgradeBoard.GetComponent<RectTransform>();
        DOTween.Sequence()   
         .AppendCallback(() => canvasGroup.interactable = false) // Disable interaction with the canvas group for the animation duration to prevent animation glitches
         .AppendCallback(() => upgradeBoard.SetActive(true))
         .Append(upgradeBoardRectTransform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack))
         .AppendCallback(() => upgradeBoardRectTransform.localScale = Vector3.one)    
         .AppendCallback(() => canvasGroup.interactable = true);


    }
    private void PlayClosingAnimation(GameObject upgradeBoard)
    {

        var canvasGroup = upgradeBoard.GetComponentInParent<CanvasGroup>();
        var upgradeBoardRectTransform = upgradeBoard.GetComponent<RectTransform>();

        DOTween.Sequence()
         .AppendCallback(() => canvasGroup.interactable = false) // Disable interaction with the canvas group for the animation duration to prevent animation glitches
         .Append(upgradeBoardRectTransform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InBack))
         .AppendCallback(() => upgradeBoard.SetActive(false))
         .AppendCallback(() => canvasGroup.interactable = true);
    }
}
