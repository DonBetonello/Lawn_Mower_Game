using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

public class LawnSizeIncreaseAnimationSequence : MonoBehaviour
{
    [SerializeField] private GameObject ScaleParent;
    [SerializeField] private GameObject lawn;
    private FenceChangeAnimation fenceChangeAnimation;

    private void Awake()
    {
 
        fenceChangeAnimation = gameObject.GetComponent<FenceChangeAnimation>();
    }
    public IEnumerator PlayLawnSizeIncreaseUpgradeAnimation()
    {
 
        var previousScaleParentScale = ScaleParent.transform.localScale;
        var newScaleParentScale = new Vector3(
            previousScaleParentScale.x - 0.1f,
            previousScaleParentScale.y - 0.1f,
            previousScaleParentScale.z - 0.1f);

        ScaleParent.transform.localScale = newScaleParentScale;


        var previuosLawnScale = lawn.transform.localScale;
        var newLawnScale = new Vector3(
            previuosLawnScale.x - 0.1f,
            previuosLawnScale.y - 0.1f,
            previuosLawnScale.z - 0.1f);

        lawn.transform.localScale = newLawnScale;

        yield return StartCoroutine(fenceChangeAnimation.PlayFenceChangeAnimation());
    }

    

}
