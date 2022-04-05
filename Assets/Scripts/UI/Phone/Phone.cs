using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Phone : MonoBehaviour
{
    [SerializeField] private GameObject _ordersApp;
    [SerializeField] private GameObject _openPhoneButton;

    private App _opendApp;
    private RectTransform _phoneReact;

    private bool _isPhoneScaled = false;

    private void Awake()
    {
        _phoneReact = GetComponent<RectTransform>();
    }

    public void HomeButtonClick()
    {
        if (_opendApp == null) return;

        _opendApp.CloseApp();

        _opendApp = null;
    }

    public void SetOpendApp(App app)
    {
        _opendApp = app;
    }


    public void OpenPhone()
    {
        _openPhoneButton.SetActive(false);

        _phoneReact.DOAnchorPosY(0f, 0.4f).SetEase(Ease.InOutBack);
    }

    public void ClosePhone()
    {
        ScalseDown();

        _phoneReact.DOAnchorPosY(-680f, 0.4f).SetEase(Ease.InOutBack).OnComplete(() => {
            _openPhoneButton.SetActive(true);
        });
    }

    public void ScaleButton()
    {
        if (!_isPhoneScaled)
            ScaleUp();
        else
            ScalseDown();
    }

    private void ScaleUp()
    {
        _isPhoneScaled = true;

        _phoneReact.DOScaleX(2, 0.3f).SetEase(Ease.InOutBack);
        _phoneReact.DOScaleY(2, 0.3f).SetEase(Ease.InOutBack);
    }

    private void ScalseDown()
    {
        _isPhoneScaled = false;

        _phoneReact.DOScaleX(1, 0.3f).SetEase(Ease.InOutBack);
        _phoneReact.DOScaleY(1, 0.3f).SetEase(Ease.InOutBack);
    }

}
