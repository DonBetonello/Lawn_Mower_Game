using TMPro;
using UnityEngine;
using DG.Tweening;

public class FlowerMultiplierTextHandler : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI multiplierText;
    [SerializeField] private TextMeshProUGUI multiplierTimeText;
    private float multiplierTimeLenght;
    private Tween pulseTween;

    private void Update()
    {
        if(multiplierTimeLenght > 0) { ChangeTimeText(); }
    }
    private void OnEnable()
    {
        GameplayEventBus.OnMultiplyerFlowerPickedUp += OnFlowerPickedUp;
    }
    private void OnDisable()
    {
        GameplayEventBus.OnMultiplyerFlowerPickedUp -= OnFlowerPickedUp;
    }

    private void OnFlowerPickedUp(float multiplierTimeLenght, float multiplier, float respawnTime)
    {
        OnSpawnAnimation(multiplierTimeLenght, multiplier);
    }

    private void ChangeTimeText() {
        var newMultiplierTime = multiplierTimeLenght -= Time.deltaTime;
       
        multiplierTimeText.text = Mathf.Round(newMultiplierTime).ToString();
    }

    private void OnSpawnAnimation(float multiplierTimeLenght, float multiplier)
    {
        var sequence = DOTween.Sequence();
        var textObject = multiplierText.gameObject;
        var rect = multiplierText.rectTransform;

        rect.localScale = Vector3.zero;
        rect.rotation = Quaternion.Euler(0, 0, 0);
        multiplierText.text = "Multiplier " + multiplier + "X";

        this.multiplierTimeLenght = multiplierTimeLenght;
        multiplierTimeText.text = multiplierTimeLenght.ToString();

        textObject.SetActive(true);
        multiplierText.alpha = 0;

        StartPulse();
        sequence

            .Append(rect.DOScale(1.4f, 0.15f).SetEase(Ease.OutBack))

            .Join(multiplierText.DOFade(1, 0.1f))

            .Join(rect.DORotate(new Vector3(0, 0, 15f), 0.15f))

            .Append(rect.DOScale(1f, 0.1f))

            .Join(rect.DORotate(Vector3.zero, 0.1f))

            .Append(rect.DOScale(1.1f, 0.08f))
            .Append(rect.DOScale(1f, 0.08f))


            .AppendInterval(multiplierTimeLenght)


            //Dissapear
            .Append(rect.DOScale(0f, 0.15f).SetEase(Ease.Linear));
            
          //  .OnComplete(() => textObject.SetActive(false));
    }
    public void StartPulse()
    {
        var rect = multiplierText.rectTransform;
        rect.localScale = Vector3.one * 0.8f;

        pulseTween?.Kill();

        //Pulsating animation
        pulseTween = rect
            .DOScale(1.1f, 0.5f)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
