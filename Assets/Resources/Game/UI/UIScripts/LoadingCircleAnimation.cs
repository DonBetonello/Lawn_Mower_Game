using UnityEngine;
using UnityEngine.UI;

public class LoadingCircleAnimation : MonoBehaviour
{
    private Image loadingCircle;

    private bool isSpinningClockwise;

    [Range(0f, 1f)]
    private float value;

    private void OnEnable()
    {
        loadingCircle = GetComponent<Image>();
    }

    private void Update()
    {
        value += isSpinningClockwise ? -Time.deltaTime : Time.deltaTime;

        if (value <= 0f)
        {
            value = 0f;
            isSpinningClockwise = false;
            loadingCircle.fillClockwise = false;
        }
        else if (value >= 1f)
        {
            value = 1f;
            isSpinningClockwise = true;
            loadingCircle.fillClockwise = true;
        }

        loadingCircle.fillAmount = value;
    }
}
