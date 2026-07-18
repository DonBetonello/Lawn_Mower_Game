using UnityEngine;

[CreateAssetMenu(fileName = "DroneData", menuName = "Scriptable Objects/Drone Data")]
public class DroneData : ScriptableObject
{

    [SerializeField] private float startSpeed;
    [SerializeField] private float startSize; 

    public float StartSpeed => startSpeed;
    public float StartSize => startSize;

    
}
