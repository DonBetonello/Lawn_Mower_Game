using UnityEngine;


public class UpdateUpgradeButtonUi : MonoBehaviour
{
    UpgradeData upgradeData;
    [SerializeField] TMPro.TextMeshProUGUI upgradeText;
    [SerializeField] TMPro.TextMeshProUGUI priceText;
    [SerializeField] private Upgrades upgrades;

    private void OnEnable()
    {
        if (upgrades != null)
            upgrades.OnRefreshUpgradeUI += Refresh;

        if (upgradeData != null)
            Refresh(upgradeData);
    }

    private void OnDisable()
    {
       // if (upgrades != null)
            upgrades.OnRefreshUpgradeUI -= Refresh;
    }

    public void Refresh(UpgradeData upgradeData)
    {
      if (upgradeData == null || this.upgradeData == null)
           return;

       
      if (upgradeData.Type != this.upgradeData.Type)
            return;

        priceText.text = Mathf.Round(upgradeData.CurrentCost).ToString();

        if (upgradeData.IsMaxUpgradeReached())
        {
            upgradeText.text = "MAX";
            gameObject.GetComponent<UnityEngine.UI.Button>().interactable = false;
            priceText.gameObject.SetActive(false);
        }
        else
        {
            
            gameObject.GetComponent<UnityEngine.UI.Button>().interactable = true;
            priceText.gameObject.SetActive(true);
        
        }
    }
}