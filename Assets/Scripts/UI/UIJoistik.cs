using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIJoistik : MonoBehaviour
{
    [SerializeField] private GameObject _joistick;
    [SerializeField] private Canvas _canvas;
    private Camera _camera;
    private RectTransform _joistickRT;


    private void Awake()
    {
        _joistickRT = _joistick.GetComponent<RectTransform>();
        _camera = Camera.main;
    }

    private void Start()
    {
        //InputManager.Instance.SimpleTouchAction += SetJoistikPosition;
    }

    private void OnDisable()
    {
        InputManager.Instance.SimpleTouchAction -= SetJoistikPosition;
    }

    //private void Update()
    //{
    //    if ( Input.GetMouseButtonDown(0))
    //    {
    //        _joistickRT.DOAnchorPos(Input.mousePosition, 0.3f);
    //    }
    //}

    private void SetJoistikPosition()
    {
        //Vector2 anchoredPosition;
        Vector2 screenPoint = new Vector2(InputManager.Instance.TouchScreenPos.x, InputManager.Instance.TouchScreenPos.y);
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(_joistickRT, screenPoint, _camera, out anchoredPosition);

        //_joistickRT.anchoredPosition = anchoredPosition;



        _joistickRT.DOAnchorPos(screenPoint, 0.3f);


        //Vector2 anchoredPosition;
        //Vector2 screenPoint = new Vector2(InputManager.Instance.TouchScreenPos.x, InputManager.Instance.TouchScreenPos.y);
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(_joistickRT, screenPoint, _camera, out anchoredPosition);

        //_joistickRT.anchoredPosition = anchoredPosition;
    }

}
