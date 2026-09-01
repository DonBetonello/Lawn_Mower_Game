using UnityEngine;

[CreateAssetMenu(fileName = "DialogScriptableData", menuName = "Scriptable Objects/DialogScriptableData")]
public class DialogScriptableData : ScriptableObject
{
   [SerializeField] private string[] lines;

    public string[] Lines => lines;

}
