using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MoneyHandler : MonoBehaviour 
{
    private float money;
    
    [SerializeField] private float amount;
    private float earningUpgradeMultiplier = 1.0f; // Example multiplier for earning upgrades

  
    

    private float flowerMultiplier = 1;

    Stat statManager;

    public float GetMoney => money;

    public void AddMoney(float amount)
    {
        money += calculateMoneyMultiplier(amount, flowerMultiplier, earningUpgradeMultiplier);
    }
    public void RemoveMoney(float amount) { money -= amount; }


    private float calculateMoneyMultiplier(float baseAmount, float flowerMultiplier, float earningUpgradeMultiplier)
    {
        return baseAmount * flowerMultiplier * earningUpgradeMultiplier;
    }


    private void OnEnable(){
        GameplayEventBus.OnGrassCut += OnGrassCut;
        GameplayEventBus.OnMultiplyerFlowerPickedUp += OnFlowerMultiplyerPickedUp;
    }

    private void OnDisable()
    {
        GameplayEventBus.OnGrassCut -= OnGrassCut;
        GameplayEventBus.OnMultiplyerFlowerPickedUp -= OnFlowerMultiplyerPickedUp;
    }

    private void OnGrassCut(Grass grass)  // This method is called when the grass is cut, and it should add money to the player's total.  
    {
        AddMoney(amount);
    }

    private void OnFlowerMultiplyerPickedUp(float timer, float multiplier, float respawnTime) // This method is called when the flower multiplier is picked up, and it should set the flower multiplier and start the timer. 
    {
        StartCoroutine(ManageFlowerMultiplier(timer, multiplier)); 
    }

    private void Awake()
    {
        statManager = FindFirstObjectByType<Stat>();
    }
    private void Update()
    {
        
        earningUpgradeMultiplier = 1f + (statManager.GetStat(StatType.IncomeIncrease) * 0.01f); // Each level increases earnings by 10% 
        
    }
    private IEnumerator ManageFlowerMultiplier(float multiplierLenght, float multiplier)
    {        
        flowerMultiplier = multiplier;
        yield return new WaitForSeconds(multiplierLenght);
        flowerMultiplier = 1;
    }
}
