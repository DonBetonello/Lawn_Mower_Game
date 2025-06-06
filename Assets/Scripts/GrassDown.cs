using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassDown : MonoBehaviour
{
   
  
    [SerializeField] private bool GrassGrow = false;
    [SerializeField] private float GrassTim = 0;
    public Upgrades money;
    public Upgrades GrowthUpg;
    public Upgrades MoneyUpg;
    [SerializeField] public float MoneyUpgrade;
    [SerializeField] public bool GrassDownBool;
    [SerializeField] private float GrassGoToPosition;
    [SerializeField] private float GrassStartPosition = -0.5f;
    [SerializeField] private GrassGradient Grass_Change_Color;
    public Flower_Multiplyer_Sript Pick_Up_Flower_Money_Multiplyer;
    private float Flower_Multiplyer =1;
    // Start is called before the first frame update
    void Start()
    {
        transform.DORotate(new Vector3(-90, Random.Range(0, 360), 0), 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (GrassDownBool == true)
        {
            
            transform.DOMove(new Vector3(transform.position.x, GrassGoToPosition, transform.position.z), 1);
            transform.DORotate(new Vector3(-90, Random.Range(0,360), 0), 0.5f);
            Grass_Change_Color.Grass_Changes_color();
            GrassDownBool = false;
        }
       

        if (GrassTim >= 5 - GrowthUpg.GrowthUpgrade)
        {
            GrassGrow = false;
            transform.DOMove(new Vector3(transform.position.x, GrassStartPosition, transform.position.z), 1);
            transform.DORotate(new Vector3(-90, Random.Range(0, 360), 0), 1.5f);
            GrassTim = 0;
        }
        
        
        if (GrassGrow == true)
        {
            GrassTim += 1 * Time.deltaTime;
        }
       
    }
    void OnTriggerEnter(Collider collision)
    {
        if (Pick_Up_Flower_Money_Multiplyer.flower_Money_Multiplyer == true)
        {
            Flower_Multiplyer = 2f;
        }
        else 
        {
            Flower_Multiplyer = 1f;
        }
        money.AddMoney((1.0f + MoneyUpg.MoneyUpgrade) * Flower_Multiplyer);
       
        GrassGrow = true;
        GrassDownBool = true;
        
    }
    private void OnTriggerExit(Collider collision)
    {
        GrassGrow = true;
        GrassDownBool = true;
    }
}

