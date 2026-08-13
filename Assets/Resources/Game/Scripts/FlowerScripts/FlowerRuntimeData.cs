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
                 
                break;
            case StatType.FlowerMultiplierRespawnTime:
                multiplierFlowerRespawnTime = newValue;
               
                break;
            case StatType.FlowerMultiplierLenght:
                multiplierLenght = newValue;
               
                break;

        }
    }
}
