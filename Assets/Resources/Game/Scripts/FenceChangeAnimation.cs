 
using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;
using System.Collections;

public class FenceChangeAnimation : MonoBehaviour
{

    [SerializeField] private GameObject woodFence;
    [SerializeField] private GameObject stoneFence;
    private List<Transform> woodfenceObjects;
    private List<Transform> stonefenceObjects;


    private bool alreadyUpgraded = false;
    private void Awake()
    {
        woodfenceObjects = new List<Transform>();
        for (int i = 0; i < woodFence.transform.childCount; i++)
        {
            woodfenceObjects.Add(woodFence.transform.GetChild(i));
        }
        stonefenceObjects = new List<Transform>();
        for (int i = 0; i < stoneFence.transform.childCount; i++)
        {
            stonefenceObjects.Add(stoneFence.transform.GetChild(i));
        }
    }


    public IEnumerator PlayFenceChangeAnimation()
    {
        if (!alreadyUpgraded) { 
        foreach (Transform t in woodfenceObjects)
        {
            var disableSequence = DOTween.Sequence();

            disableSequence

                .Append(t.DOScale(0, 0.1f).SetEase(Ease.Linear))
                .AppendCallback(() => { t.gameObject.SetActive(false); });
            yield return new WaitForSeconds(0.1f);
        }
        foreach (Transform t in stonefenceObjects)
        {
            var startScale = t.localScale;

            t.DOScale(0, 0);

            var enableSequence = DOTween.Sequence();

            enableSequence
            .AppendCallback(() => { t.gameObject.SetActive(true); })
            .Append(t.DOScale(startScale, 0.1f)).SetEase(Ease.Linear);

            t.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
        alreadyUpgraded = true;
        }
    }
}
