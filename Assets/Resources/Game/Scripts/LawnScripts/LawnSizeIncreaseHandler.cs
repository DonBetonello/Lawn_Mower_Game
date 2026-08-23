using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LawnSizeIncreaseHandler : MonoBehaviour
{

    [Header("Disable objects references")]
    [SerializeField] private GameObject LawnMoverObject;
    [SerializeField] private Canvas canvas;
    private Drone Drone;
    private Flower Flower;


    [Header("Other references")]
    [SerializeField] private LawnCreator lawnCreator;
    [SerializeField] private LawnSizeIncreaseAnimationSequence lawnSizeIncreaseAnimation;
    [SerializeField] private LawnCreatingLoadingScreen loadingScreen;


    [Header("Settings")]
    [SerializeField] private int lawnHeight;
    [SerializeField] private int lawnWidth;  


    private int lawnSizeIncreaseCounter;
 

    private void OnEnable()
    {
        UpgradesEventBus.OnSpecialUpgradePurchased += IncreaseLawn;
    }
    private void OnDisable()
    {
        UpgradesEventBus.OnSpecialUpgradePurchased -= IncreaseLawn;
    }


    private void IncreaseLawn(UpgradeData upgradeData)
    {
        switch (upgradeData.specialUpgradeType)
        {
            case SpecialUpgradeType.LawnIncrease1:
                StartCoroutine(RegenerateLawn());
                break;
            case SpecialUpgradeType.LawnIncrease2:
                IncreaseLawnSize();
                StartCoroutine(RegenerateLawn());
                break;
            case SpecialUpgradeType.LawnIncrease3:
                IncreaseLawnSize();
                StartCoroutine(RegenerateLawn());
                break;
        }
    }

    private void IncreaseLawnSize()
    {
        lawnSizeIncreaseCounter++;
        lawnWidth = Mathf.RoundToInt(lawnWidth * 1.21f);
        lawnHeight = Mathf.RoundToInt(lawnHeight * 1.2f);

    }
    public IEnumerator RegenerateLawn()
    {
        loadingScreen.EnableLoadingScreen();

        yield return StartCoroutine(ManageObjectsActive(true));


        var previousGrassList = lawnCreator.GetGrassList();

        if (previousGrassList.Count > 0)
        {
            DisablePreviousGrass(previousGrassList);
        }

        foreach (var grass in previousGrassList)
        {
            var grassCuttingHandler = grass.GetComponent<GrassCuttingHandler>();
            grassCuttingHandler.ForceRegrow();

        }
        yield return new WaitForSeconds(1);

        yield return StartCoroutine(lawnCreator.GenerateLawn(lawnHeight, lawnWidth));

      


        loadingScreen.DisableLoadingScreen();

        yield return new WaitForSeconds(0.3f);

        canvas.gameObject.SetActive(false);


        if (lawnSizeIncreaseCounter > 0)
        {
            yield return StartCoroutine(
                lawnSizeIncreaseAnimation.PlaySizeIncreaseAnimation()
            );
        }

        yield return new WaitForSeconds(0.1f);

        
       

      
        var newGrassList = lawnCreator.GetGrassList();

        foreach (var grass in newGrassList)
        {

            var renderer = grass.GetComponentInChildren<Renderer>();

            if (renderer != null)
            {
                renderer.enabled = true;
            }

            var grassAnimator = grass.GetComponent<GrassAnimationHandler>();

            if (grassAnimator != null)
            {
                grassAnimator.PlayOnEnableAnimation();
            }

            yield return new WaitForEndOfFrame();
        }

        yield return StartCoroutine(ManageObjectsActive(false));
        canvas.gameObject.SetActive(true);
    }

    private IEnumerator ManageObjectsActive(bool isActive)
    {
        yield return new WaitForEndOfFrame();

        Drone = FindFirstObjectByType<Drone>(FindObjectsInactive.Include);
        if (Drone != null) { Drone.gameObject.SetActive(!isActive); }

        Flower = FindFirstObjectByType<Flower>(FindObjectsInactive.Include);
        if (Flower != null) { Flower.gameObject.SetActive(!isActive); }

        LawnMoverObject.SetActive(!isActive);
        

        yield return null;
    }

    private void DisablePreviousGrass(List<Grass> list)
    {
        foreach (var grass in list)
        {
            var renderer = grass.GetComponentInChildren<Renderer>();   
            renderer.enabled = false;
        }

    }
}
