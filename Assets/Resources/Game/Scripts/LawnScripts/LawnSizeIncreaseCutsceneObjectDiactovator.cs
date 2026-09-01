using UnityEngine;
using DG.Tweening;

public class LawnSizeIncreaseCutsceneObjectDiactovator : MonoBehaviour
{
    [SerializeField] private Drone Drone;
    [SerializeField] private LawnMover LawnMover;
    [SerializeField] private Flower Flower;
    [SerializeField] private UFO UFO;


    private void DeactivateObjects()
    {
        UFO.gameObject.SetActive(false);
        Drone.gameObject.SetActive(false);
        LawnMover.gameObject.SetActive(false);
        Flower.gameObject.SetActive(false);
    }
    private void ActivateObjects()
    {
        UFO.gameObject.SetActive(true);
        Drone.gameObject.SetActive(true);

        var LawnMoverStartSize = LawnMover.gameObject.transform.localScale;
        LawnMover.gameObject.transform.localScale = Vector3.zero;
        LawnMover.gameObject.SetActive(true);
        LawnMover.gameObject.transform.DOScale(LawnMoverStartSize, 0.3f).SetEase(Ease.Linear);
        

        Flower.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        GameplayEventBus.OnLawnIncreaseCutsceneStarted += DeactivateObjects;
        GameplayEventBus.OnLawnIncreaseCutsceneEnded += ActivateObjects;
    }
    private void OnDisable()
    {
        GameplayEventBus.OnLawnIncreaseCutsceneStarted -= DeactivateObjects;
        GameplayEventBus.OnLawnIncreaseCutsceneEnded -= ActivateObjects;
    }
}
