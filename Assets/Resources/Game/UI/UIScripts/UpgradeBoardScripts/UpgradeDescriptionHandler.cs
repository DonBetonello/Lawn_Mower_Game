using UnityEngine;
using TMPro;

public class UpgradeDescriptionHandler : MonoBehaviour
{
    [SerializeField] private GameObject UpgradeDescriptionObject;
   // private TextMeshProUGUI UpgradeDescription;
    private TextMeshProUGUI UpgradeName;
    private TextMeshProUGUI UpgradeValueChange;
    private TextMeshProUGUI UpgradeLevel;
    private TextMeshProUGUI UpgradePrice;


    private void Awake()
    {
     //   UpgradeDescription = UpgradeDescriptionObject.transform.Find("UpgradeDescriptionText").GetComponent<TextMeshProUGUI>();
        UpgradeName = UpgradeDescriptionObject.transform.Find("Name").GetComponent<TextMeshProUGUI>();
        UpgradeValueChange = UpgradeDescriptionObject.transform.Find("ValueChange").GetComponent<TextMeshProUGUI>();
        UpgradeLevel = UpgradeDescriptionObject.transform.Find("Level").GetComponent<TextMeshProUGUI>();
        UpgradePrice = UpgradeDescriptionObject.transform.Find("Price").GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        UIEventBus.OnUpgradeDescriptionOpened += OnUpgradeDescriptionOpened;
    }
    private void OnDisable()
    {
        
    }

    private void OnUpgradeDescriptionOpened(GameObject upgradeDescription, UpgradeData upgradeData)
    {
        if (upgradeDescription == UpgradeDescriptionObject)
        {
            // Update the description text here
         //   UpgradeData upgradeData = upgradeDescription.GetComponent<UpgradeDescription>().GetUpgradeData();
            if (upgradeData != null)
            {
                float currentValue = upgradeData.Value;
                float futureValue = currentValue + upgradeData.IncreaseAmount;


                UpgradeName.text = upgradeData.Type.ToString();
                UpgradeValueChange.text = "" + currentValue.ToString() + " → " + futureValue.ToString();
             //   UpgradeLevel.text = "Level: " + upgradeData.CurrentLevel.ToString();
                UpgradePrice.text =  Mathf.Round(upgradeData.CurrentCost).ToString();
            }
        }
    }
}
