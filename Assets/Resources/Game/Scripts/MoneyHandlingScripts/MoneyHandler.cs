using Unity.VisualScripting;
using UnityEngine;

public class MoneyHandler : MonoBehaviour 
{
    private float money;
    
    [SerializeField] private float amount;
    private float earningUpgradeMultiplier = 1.0f; // Example multiplier for earning upgrades
    private float flowerMultiplier = 1.0f; // Example multiplier for flower upgrades
    private float flowerMultiplierTimer = 0f; // Timer for flower multiplier duration
   [SerializeField] private Upgrades upgrades;

    [SerializeField] private UpgradeData upgradesData;
    

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
        GrassCutting.OnGrassGotCut += OnGrassCut;
    }

    private void OnDisable()
    {
        GrassCutting.OnGrassGotCut -= OnGrassCut;
    }

    private void OnGrassCut()  // This method is called when the grass is cut, and it should add money to the player's total.  
    {
        AddMoney(amount);
    }

    private void OnFlowerMultiplyerPickedUp(float timer) // This method is called when the flower multiplier is picked up, and it should set the flower multiplier and start the timer. 
    {
        flowerMultiplierTimer += timer;
        flowerMultiplier = 2f;
    }


    private void Update()
    {
        if (flowerMultiplierTimer > 0f) {
            flowerMultiplierTimer -= Time.deltaTime;
        }
        else
        {
            flowerMultiplier = 1f;
        }
        earningUpgradeMultiplier = 1f + (upgrades.GetRuntimeData(upgradesData).CurrentValue * 0.1f); // Each level increases earnings by 10%
        // Fix this
    }
}
