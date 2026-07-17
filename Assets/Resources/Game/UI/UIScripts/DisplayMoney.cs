
using TMPro;
using UnityEngine;

public class DisplayMoney : MonoBehaviour
{
   private MoneyHandler m_MoneyHandler;
    [SerializeField] private TextMeshProUGUI moneyText; 
    private void Awake()
    {
        m_MoneyHandler = FindFirstObjectByType<MoneyHandler>();        
    }
    private void Update()
    {
        moneyText.text = m_MoneyHandler.GetMoney.ToString();
    }

}
