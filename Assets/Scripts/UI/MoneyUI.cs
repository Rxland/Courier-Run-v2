using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;


    private void Start()
    {
        UpdateMoneyUI();

        MoneyManager.Instance.MoneyCountChanged += UpdateMoneyUI;
    }


    private void OnDisable()
    {
        MoneyManager.Instance.MoneyCountChanged -= UpdateMoneyUI;
    }

    public void UpdateMoneyUI()
    {
        _moneyText.text = MoneyManager.Instance.MoneyCount.ToString();
    }
}
