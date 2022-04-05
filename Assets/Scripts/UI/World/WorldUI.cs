using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldUI : MonoBehaviour
{
    [SerializeField] protected Canvas Canvas;
    [SerializeField] protected bool _switchOnZ = false;

    protected Camera CameraMain;


    public virtual void Awake()
    {
        CameraMain = Camera.main;
    }

    private void Update()
    {
        Quaternion rotation = Quaternion.LookRotation(CameraMain.transform.position - Canvas.transform.position, _switchOnZ ? -Canvas.transform.up : Canvas.transform.up);
        rotation.x = 0f;
        rotation.z = 0f;

        Canvas.transform.rotation = rotation;
    }

}
