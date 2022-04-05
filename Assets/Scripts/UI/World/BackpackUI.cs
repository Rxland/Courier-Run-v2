using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BackpackUI : WorldUI
{
    private BackpackBase _backpack;
    [SerializeField] private TextMeshProUGUI _textCount;

    public override void Awake()
    {
        base.Awake();

        _backpack = GetComponent<BackpackBase>();
    }

    private void Start()
    {
        UpdateBackpackUI();

        _backpack.SlotsCountChanged += UpdateBackpackUI;
    }

    private void OnDisable()
    {
        _backpack.SlotsCountChanged -= UpdateBackpackUI;
    }



    public void UpdateBackpackUI()
    {
        _textCount.text = $"{_backpack.ReturnBusySlotsCount()} / {_backpack.BackpackSlots.Count}";
    }




}
