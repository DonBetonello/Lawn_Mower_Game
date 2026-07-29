using UnityEngine;

public class DroneRuntimeData: IUpgradable
{
    private bool isBought;
    private float currentMovingSpeed;
    public float CurrentMovingSpeed => currentMovingSpeed;
    private float currentSize;
    public float CurrentSize => currentSize;

    private GameObject drone;

    public DroneRuntimeData(DroneData droneData)
    {
        currentMovingSpeed = droneData.StartSpeed;
        currentSize = droneData.StartSize;
    }
    public float SetCurrentMovingSpeed(float newValue) { return currentMovingSpeed = newValue; }
    public float SetCurrentSize(float newValue) { return currentSize = newValue; }

    public void GetDrone(GameObject drone)
    {
        this.drone = drone;
    }

    public void Upgrade(StatType type, float newValue)
    {

        switch (type)
        {
            case StatType.DroneSpeed:
                currentMovingSpeed = newValue;
                break;
            case StatType.DroneSize:
                currentSize = newValue;
                drone.gameObject.transform.localScale = new Vector3(currentSize, currentSize, currentSize);
                break;
        }

    }
}