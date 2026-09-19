using UnityEngine;
using DG.Tweening;

public class LawnSizeIncreaseCutsceneObjectDiactovator : MonoBehaviour
{
    private Drone Drone;
    [SerializeField] private LawnMover LawnMover;
    private Flower Flower;
    private UFO UFO;


    private void DeactivateObjects()
    {
        UFO = FindAnyObjectByType<UFO>();
        if(UFO != null) { UFO.gameObject.SetActive(false); }
        

        Drone = FindAnyObjectByType<Drone>();
        if(Drone != null) { Drone.gameObject.SetActive(false); }
       

        LawnMover.gameObject.SetActive(false);

        Flower = FindAnyObjectByType<Flower>();
        if(Flower != null) { Flower.gameObject.SetActive(false); }
      
    }
    private void ActivateObjects()
    {
        if (UFO != null) { UFO.gameObject.SetActive(true); }
        if (Drone != null) { Drone.gameObject.SetActive(true); }


        LawnMover.gameObject.transform.localScale = Vector3.zero;
        LawnMover.gameObject.SetActive(true);
        LawnMover.gameObject.transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.Linear);


        if (Flower != null) { Flower.gameObject.SetActive(false); }
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
