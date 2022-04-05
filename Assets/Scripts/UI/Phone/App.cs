using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class App : MonoBehaviour
{
    [SerializeField] private Phone _phone;
    [SerializeField] private GameObject _appGO;

    private RectTransform _appRT;

    private void Awake()
    {
        _appRT = _appGO.GetComponent<RectTransform>();
    }


    private void OnEnable()
    {
        //_appRT.transform.localScale = new Vector3(0f, 0f, 1f);

    }

    public void OpenApp()
    {
        _phone.SetOpendApp(this);

        _appGO.SetActive(true);

        //_appRT.DOScaleX(1, 0.3f).SetEase(Ease.InOutBack);
        //_appRT.DOScaleY(1, 0.3f).SetEase(Ease.InOutBack);
    }

    public void CloseApp()
    {
        _appGO.SetActive(false);
    }
}
