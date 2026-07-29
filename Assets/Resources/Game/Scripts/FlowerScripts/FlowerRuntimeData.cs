using UnityEngine;

public class FlowerRuntimeData : IUpgradable
{

    private float multiplierLenght;
    private float multiplier;
    private float multiplierFlowerRespawnTime;

    public float MultiplierLenght => multiplierLenght;
    public float Multiplier => multiplier;
    public float MultiplierFlowerRespawnTime => multiplierFlowerRespawnTime;

    public FlowerRuntimeData(float StartMultiplier,float StartMultiplierLenght,float StartMultiplierRespawnTime)
    {
        multiplier = StartMultiplier;
        multiplierLenght = StartMultiplierLenght;
        multiplierFlowerRespawnTime = StartMultiplierRespawnTime; 
    }

    public void Upgrade(StatType type, float newValue)
    {
        switch (type)
        {
            case StatType.FlowerMultiplier:
                multiplier = newValue;
                Debug.Log("Value " + StatType.FlowerMultiplier + "changed to " + multiplier);
                break;
            case StatType.FlowerMultiplierRespawnTime:
                multiplierFlowerRespawnTime = newValue;
                Debug.Log("Value " + StatType.FlowerMultiplierRespawnTime + "changed to " + multiplierFlowerRespawnTime);
                break;
            case StatType.FlowerMultiplierLenght:
                multiplierLenght = newValue;
                Debug.Log("Value " + StatType.FlowerMultiplierLenght + "changed to " + multiplierLenght);
                break;

        }
    }
}
