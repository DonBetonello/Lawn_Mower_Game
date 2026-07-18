using UnityEngine;

public class DroneRuntimeData
{
    private bool isBought;
    private float currentMovingSpeed;
    public float CurrentMovingSpeed => currentMovingSpeed;
    private float currentSize;
    public float CurrentSize => currentSize;

    public DroneRuntimeData(DroneData droneData)
    {
        currentMovingSpeed = droneData.StartSpeed;
        currentSize = droneData.StartSize;

    }
    public float SetCurrentMovingSpeed(float newValue) { return currentMovingSpeed = newValue; }
    public float SetCurrentSize(float newValue) { return currentSize = newValue; }

    public void ApllyUpgrade(StatType type, float newValue)
    {

        switch (type)
        {
            case StatType.DroneSpeed:
                currentMovingSpeed = newValue;
                break;
            case StatType.DroneSize:
                currentSize = newValue; 
                break;

        }

    }
}