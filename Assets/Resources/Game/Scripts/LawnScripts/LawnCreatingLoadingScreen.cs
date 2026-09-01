using DG.Tweening;
using System;
using UnityEngine;

public class LawnCreatingLoadingScreen : MonoBehaviour
{

    [SerializeField] private GameObject loadingScreen;
 
    public void EnableLoadingScreen()
    {
        var rect = loadingScreen.GetComponent<RectTransform>();
        rect.transform.DOScale(0, 0f);
        loadingScreen.SetActive(true);
        
       
        rect.transform.DOScale(1, 0.3f).SetEase(Ease.OutBack);
    }
    public void DisableLoadingScreen()
    {
       
        var rect = loadingScreen.GetComponent<RectTransform>();


        DOTween.Sequence()
            .Append(rect.transform.DOScale(0, 0.3f).SetEase(Ease.InBack))
            .AppendCallback(() => { loadingScreen.SetActive(false); });

     
    }


}
