using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

public class LawnSizeIncreaseAnimationSequence : MonoBehaviour
{
    [SerializeField] private GameObject ground;
    private Camera mainCamera;

    [SerializeField] private Transform lawnGoToPosition;

    [SerializeField] private Transform lawnTransform;


    private FenceChangeAnimation fenceChangeAnimation;

    private void Awake()
    {
        mainCamera = Camera.main;
        fenceChangeAnimation = gameObject.GetComponent<FenceChangeAnimation>();
    }
    public IEnumerator PlaySizeIncreaseAnimation()
    {

        mainCamera.transform.DOMoveY(mainCamera.transform.position.y + 2.5f, 1f).SetEase(Ease.OutBack);

        ground.transform.DOScale(ground.transform.localScale * 1.2f, 0.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.5f);
        lawnTransform.transform.position = new Vector3(lawnGoToPosition.transform.position.x, -5, lawnGoToPosition.transform.position.z);

        yield return StartCoroutine(fenceChangeAnimation.PlayFenceChangeAnimation());
    }

}
