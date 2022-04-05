// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Characters/Player/Input/InputSystemMap.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputSystemMap : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystemMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystemMap"",
    ""maps"": [
        {
            ""name"": ""Input"",
            ""id"": ""77b96269-f192-4ecf-839f-6fadaf1b1cfc"",
            ""actions"": [
                {
                    ""name"": ""TouchPos"",
                    ""type"": ""Value"",
                    ""id"": ""eebe9e39-2818-4349-a3eb-46d3cc37dc1c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchScreenPos"",
                    ""type"": ""Value"",
                    ""id"": ""490dd99a-66c1-458d-937e-b3f84566a1d8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPosRelese"",
                    ""type"": ""Value"",
                    ""id"": ""9b05462f-cb38-4705-ab8e-c8124d1b3f3f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SingleTouch"",
                    ""type"": ""Button"",
                    ""id"": ""4bee9bc1-7e3a-4670-92b1-73a2aa95e549"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""TouchRelese"",
                    ""type"": ""Button"",
                    ""id"": ""f1546e63-6d05-437e-ab07-a96f7ecb3bd1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5c3433c2-ef4e-4c27-807b-52a7662a7bf4"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb25981c-06c1-4cfe-9360-e4853f03cb82"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SingleTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""28e6d95e-a8bd-45f8-954a-ee27e3aa4fe1"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchRelese"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""380ccad7-2150-49a3-8d45-295fa910995a"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosRelese"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7f83843-12df-4dfe-af4e-fea46ae89696"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchScreenPos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Input
        m_Input = asset.FindActionMap("Input", throwIfNotFound: true);
        m_Input_TouchPos = m_Input.FindAction("TouchPos", throwIfNotFound: true);
        m_Input_TouchScreenPos = m_Input.FindAction("TouchScreenPos", throwIfNotFound: true);
        m_Input_TouchPosRelese = m_Input.FindAction("TouchPosRelese", throwIfNotFound: true);
        m_Input_SingleTouch = m_Input.FindAction("SingleTouch", throwIfNotFound: true);
        m_Input_TouchRelese = m_Input.FindAction("TouchRelese", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Input
    private readonly InputActionMap m_Input;
    private IInputActions m_InputActionsCallbackInterface;
    private readonly InputAction m_Input_TouchPos;
    private readonly InputAction m_Input_TouchScreenPos;
    private readonly InputAction m_Input_TouchPosRelese;
    private readonly InputAction m_Input_SingleTouch;
    private readonly InputAction m_Input_TouchRelese;
    public struct InputActions
    {
        private @InputSystemMap m_Wrapper;
        public InputActions(@InputSystemMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @TouchPos => m_Wrapper.m_Input_TouchPos;
        public InputAction @TouchScreenPos => m_Wrapper.m_Input_TouchScreenPos;
        public InputAction @TouchPosRelese => m_Wrapper.m_Input_TouchPosRelese;
        public InputAction @SingleTouch => m_Wrapper.m_Input_SingleTouch;
        public InputAction @TouchRelese => m_Wrapper.m_Input_TouchRelese;
        public InputActionMap Get() { return m_Wrapper.m_Input; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputActions set) { return set.Get(); }
        public void SetCallbacks(IInputActions instance)
        {
            if (m_Wrapper.m_InputActionsCallbackInterface != null)
            {
                @TouchPos.started -= m_Wrapper.m_InputActionsCallbackInterface.OnTouchPos;
                @TouchPos.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnTouchPos;
                @TouchPos.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnTouchPos;
                @TouchScreenPos.started -= m_Wrapper.m_InputActionsCallbackInterface.OnTouchScreenPos;
                @TouchScreenPos.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnTouchScreenPos;
                @TouchScreenPos.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnTouchScreenPos;
                @TouchPosRelese.started -= m_Wrapper.m_InputActionsCallbackInterface.OnTouchPosRelese;
                @TouchPosRelese.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnTouchPosRelese;
                @TouchPosRelese.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnTouchPosRelese;
                @SingleTouch.started -= m_Wrapper.m_InputActionsCallbackInterface.OnSingleTouch;
                @SingleTouch.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnSingleTouch;
                @SingleTouch.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnSingleTouch;
                @TouchRelese.started -= m_Wrapper.m_InputActionsCallbackInterface.OnTouchRelese;
                @TouchRelese.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnTouchRelese;
                @TouchRelese.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnTouchRelese;
            }
            m_Wrapper.m_InputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TouchPos.started += instance.OnTouchPos;
                @TouchPos.performed += instance.OnTouchPos;
                @TouchPos.canceled += instance.OnTouchPos;
                @TouchScreenPos.started += instance.OnTouchScreenPos;
                @TouchScreenPos.performed += instance.OnTouchScreenPos;
                @TouchScreenPos.canceled += instance.OnTouchScreenPos;
                @TouchPosRelese.started += instance.OnTouchPosRelese;
                @TouchPosRelese.performed += instance.OnTouchPosRelese;
                @TouchPosRelese.canceled += instance.OnTouchPosRelese;
                @SingleTouch.started += instance.OnSingleTouch;
                @SingleTouch.performed += instance.OnSingleTouch;
                @SingleTouch.canceled += instance.OnSingleTouch;
                @TouchRelese.started += instance.OnTouchRelese;
                @TouchRelese.performed += instance.OnTouchRelese;
                @TouchRelese.canceled += instance.OnTouchRelese;
            }
        }
    }
    public InputActions @Input => new InputActions(this);
    public interface IInputActions
    {
        void OnTouchPos(InputAction.CallbackContext context);
        void OnTouchScreenPos(InputAction.CallbackContext context);
        void OnTouchPosRelese(InputAction.CallbackContext context);
        void OnSingleTouch(InputAction.CallbackContext context);
        void OnTouchRelese(InputAction.CallbackContext context);
    }
}
