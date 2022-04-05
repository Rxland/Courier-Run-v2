using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayInputManager : MonoBehaviour
{
    public static RayInputManager Instance;

    private Camera _cameraMain;

    private Vector2 _rayPointPos;

    private Vector2 _maxVector = new Vector2(500f, 500f);
    private Vector2 _minVector = new Vector2(-500f, -500f);

    public Vector2 RayPointPos { get { return _rayPointPos; } private set { } }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;


        _cameraMain = Camera.main;
    }


    private void FixedUpdate()
    {
        Ray();
    }

    public void Ray()
    {
        Vector2 ScreenPos = InputManager.Instance.TouchScreenPos;
        //print("ScreenPos " + ScreenPos);

        float x = ScreenPos.x;
        float y = ScreenPos.y;

        x = Mathf.Clamp(x, 500f, -500);
        y = Mathf.Clamp(y, 500f, -500);

        ScreenPos = new Vector2(x, y);


        Ray ray = _cameraMain.ScreenPointToRay(ScreenPos);
        RaycastHit hit;
        //print("InputManager.Instance.TouchHoldDelta " + InputManager.Instance.TouchScreenPos);

        Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.black);

        if ( Physics.Raycast(ray.origin, ray.direction, out hit))
        {
            _rayPointPos = hit.point;
        }
    }
}
