using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassCutting : MonoBehaviour
{


    [SerializeField] private bool isGrassGrowing = false;
    [SerializeField] private float GrassRegrowTimer = 0;
    

    private MoneyHandler moneyHandler;

    private Upgrades upgrades;


    [SerializeField] private bool isGrassDownBool;
    [SerializeField] private float GrassGoToPosition;
    [SerializeField] private float GrassStartPosition = -0.5f;
  
 

    public static event System.Action OnGrassGotCut; // Event to notify when the grass is cut


    void Start()
    {
        upgrades = FindFirstObjectByType<Upgrades>();
        RandomizeGrassRotationAtStart();
    }

    
    void FixedUpdate()
    {
        
        if (isGrassDownBool == true)
        {

            GetGrassDown();
           
            isGrassDownBool = false;
        }
       

        if (GrassRegrowTimer >= 5 - upgrades.GrowthUpgradeData.Value)
        {
            isGrassGrowing = false;
            GetGrassUp();
            GrassRegrowTimer = 0;
        }
        
        
        if (isGrassGrowing == true)
        {
            GrassRegrowTimer += 1 * Time.deltaTime;
        }
       
    }
    void OnTriggerEnter(Collider collision)
    {
       /* if (Pick_Up_Flower_Money_Multiplyer.flower_Money_Multiplyer == true)
        {
            Flower_Multiplyer = 2f;
        }
        else 
        {
            Flower_Multiplyer = 1f;
        }*/
        isGrassGrowing = true;
        isGrassDownBool = true;
        OnGrassGotCut?.Invoke(); // Notify subscribers that the grass has been cut
    }
    private void OnTriggerExit(Collider collision)
    {
        isGrassGrowing = true;
        isGrassDownBool = true;
    }
    private void RandomizeGrassRotationAtStart()
    {
        transform.DORotate(new Vector3(-90, Random.Range(0, 360), 0), 0);
    }
    private void GetGrassDown()
    {
        transform.DOMove(new Vector3(transform.position.x, GrassGoToPosition, transform.position.z), 1);
        transform.DORotate(new Vector3(-90, Random.Range(0, 360), 0), 0.5f);
    }
    private void GetGrassUp()
    {
        transform.DOMove(new Vector3(transform.position.x, GrassStartPosition, transform.position.z), 1);
        transform.DORotate(new Vector3(-90, Random.Range(0, 360), 0), 1.5f);
    }

}

