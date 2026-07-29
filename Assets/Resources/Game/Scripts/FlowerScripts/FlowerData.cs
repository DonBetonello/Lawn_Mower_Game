using UnityEngine;

[CreateAssetMenu(fileName = "FlowerData", menuName = "Scriptable Objects/FlowerData")]
public class FlowerData : ScriptableObject
{
    [Tooltip("How much will multiplier last in seconds after picking up")]
    [SerializeField] private float startMultiplierLenght;

    [Tooltip("Provided multiplier after picking up")]
    [SerializeField] private float startMultiplier;

    [Tooltip("Value that indicates in seconds when will flower respawn")]
    [SerializeField] private float startMultiplierRespawnTime;


    public float StartMultiplierLenght => startMultiplierLenght;
    public float StartMultiplier => startMultiplier;
    public float StartMultiplaierRespawnTime => startMultiplierRespawnTime;
}
