using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeData", menuName = "Scriptable Objects/Upgrade Data")]
public class UpgradeData : ScriptableObject
{

    public string Name;
   
    public float IncreaseAmount;

    public float StartValue;

    public int StartLevel;
    public int MaxLevel;

    public float StartCost;
    public float CostMultiplier;

    public string Description;


    [System.Serializable]
    public struct UpgradeDataStruct
    {
        public string Name;
      
        public float IncreaseAmount;
        public int MaxLevel;
        public float StartCost;
        public float CostMultiplier;

        public string Description;

        public UpgradeDataStruct(UpgradeData upgradeData)
        {
           
            Name = upgradeData.Name;
            IncreaseAmount = upgradeData.IncreaseAmount;
            MaxLevel = upgradeData.MaxLevel;
            StartCost = upgradeData.StartCost;
            CostMultiplier = upgradeData.CostMultiplier;
            Description = upgradeData.Description;
         
        }
    }

}
