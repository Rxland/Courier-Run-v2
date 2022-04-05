using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : CharacterStateMachine
{
    [SerializeField] public int Speed = 20;
    public PlayerAnimatinRigging PlayerAnimatinRigging;

    private Camera _cameraMain;
    private bool _canMoving = true;

    public Camera CameraMain => _cameraMain;
    public bool CanMoving { get { return _canMoving; } private set { } }

    public override void Awake()
    {
        base.Awake();

        _cameraMain = Camera.main;
        PlayerAnimatinRigging = GetComponent<PlayerAnimatinRigging>();
    }

    private void Start()
    {
        TransportManager.Instance.EqupeAnyTransprot += OnTransoprtMode;
        TransportManager.Instance.UnequpeAnyTransprot += SetNormalMode;
    }

    private void OnDisable()
    {
        TransportManager.Instance.EqupeAnyTransprot -= OnTransoprtMode;
        TransportManager.Instance.UnequpeAnyTransprot -= SetNormalMode;
    }

    private void OnTransoprtMode()
    {
        _rb.isKinematic = true;

        _canMoving = false;
    }

    private void SetNormalMode()
    {
        _rb.isKinematic = false;

        _canMoving = true;
    }

}
