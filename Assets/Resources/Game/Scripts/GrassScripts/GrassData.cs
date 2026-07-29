using UnityEngine;

[CreateAssetMenu(fileName = "GrassData", menuName = "Scriptable Objects/GrassData")]
public class GrassData : ScriptableObject
{
    [SerializeField] private float startRegrowTime;
    [SerializeField] private bool isGold;

    public float StartRegrowTime => startRegrowTime;
    public bool IsGold => isGold;

}
