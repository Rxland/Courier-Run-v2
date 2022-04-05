using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    private Vector2 _touchHoldDelta;
    private Vector2 _touchScreenPos;
    public Vector2 TouchHoldDelta { get { return _touchHoldDelta; } private set {} }
    public Vector2 TouchScreenPos { get { return _touchScreenPos; } private set { } }

    public delegate void TouchHoldDeltaDelegate(Vector2 delta);
    public event TouchHoldDeltaDelegate TouchHoldDeltaAction;


    //public delegate void TouchScreenPosDelegate(Vector2 pos);
    //public event TouchScreenPosDelegate TouchScreenPosAction;


    public delegate void TouchPosPerformedDelegate();
    public event TouchPosPerformedDelegate TouchPosPerformedAction;

    public delegate void TouchPosReleseDelegate();
    public event TouchPosReleseDelegate TouchPosReleseAction;

    // Touch
    public delegate void SimpleTouchDelegate();
    public event SimpleTouchDelegate SimpleTouchAction;
    // Touch Relese
    public delegate void ReleseTouchDelegate();
    public event ReleseTouchDelegate ReleseTouchAction;



    private InputSystemMap _input;



    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        _input = new InputSystemMap();
    }

    private void Start()
    {
        _input.Input.SingleTouch.started += SimpleTouch;
        _input.Input.SingleTouch.canceled += ReleseTouch;
        //_input.Input.TouchRelese.performed += ReleseTouch;

        _input.Input.TouchPos.performed += TouchPosPressTrigger;
        _input.Input.TouchPos.performed += TouchPos;
        _input.Input.TouchPosRelese.performed += TouchPosReleseTrigger;
    }

    private void Update()
    {
        TouchHoldDeltaInput();


        _touchScreenPos = _input.Input.TouchScreenPos.ReadValue<Vector2>();
    }



    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Input.SingleTouch.started -= SimpleTouch;
        _input.Input.SingleTouch.canceled -= ReleseTouch;
        //_input.Input.TouchRelese.performed -= ReleseTouch;

        _input.Input.TouchPos.performed -= TouchPos;
        _input.Input.TouchPos.performed -= TouchPosPressTrigger;
        _input.Input.TouchPosRelese.performed -= TouchPosReleseTrigger;

        _input.Disable();
    }




    private void TouchHoldDeltaInput()
    {
        _touchHoldDelta = _input.Input.TouchPos.ReadValue<Vector2>();
    }
    private void TouchPos(InputAction.CallbackContext context)
    {
        //Debug.Log("Touch Pos");
        TouchHoldDeltaAction?.Invoke(_touchHoldDelta);
    }


    private void SimpleTouch(InputAction.CallbackContext context)
    {
        SimpleTouchAction?.Invoke();
    }
    private void ReleseTouch(InputAction.CallbackContext context)
    {
        ReleseTouchAction?.Invoke();
    }

    private void TouchPosPressTrigger(InputAction.CallbackContext context)
    {
        TouchPosPerformedAction?.Invoke();
    }
    private void TouchPosReleseTrigger(InputAction.CallbackContext context)
    {
        TouchPosReleseAction?.Invoke();
    }

}
