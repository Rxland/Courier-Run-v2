using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomerUI : WorldUI
{
    [SerializeField] private TextMeshProUGUI _nameUi;


    public void UpdateCustomerName(string name)
    {
        _nameUi.text = name;
    }


}
