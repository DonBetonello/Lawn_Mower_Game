
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DisplayMoney : MonoBehaviour
{
   [SerializeField]private MoneyHandler m_MoneyHandler;
    [SerializeField] private TextMeshProUGUI moneyText; 
   
    private void Update()
    {

        float money = m_MoneyHandler.GetMoney;

        moneyText.text = money >= 1000
            ? $"{money / 1000f:0.#}k"
            : money.ToString();
    }

}
