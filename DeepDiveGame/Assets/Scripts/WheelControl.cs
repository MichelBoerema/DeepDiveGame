//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/WheelControl.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @WheelControl: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @WheelControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""WheelControl"",
    ""maps"": [
        {
            ""name"": ""Wheel"",
            ""id"": ""a8316dff-158f-4741-80e4-f94a27e1b706"",
            ""actions"": [
                {
                    ""name"": ""Accelerate"",
                    ""type"": ""Button"",
                    ""id"": ""e546d331-1e9c-4b39-9e8e-dbbb338aad99"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Brake"",
                    ""type"": ""Button"",
                    ""id"": ""1d491d8f-0909-4eea-8221-f74ac06a842c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Clutch"",
                    ""type"": ""Button"",
                    ""id"": ""ba16362c-18d0-4772-9e7c-8b31618b30ef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Steer"",
                    ""type"": ""Button"",
                    ""id"": ""5420204c-e810-4514-bde0-f18ebe336660"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""60b13b2f-92d2-4210-88cd-d48708ae845c"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b687bbf-41ec-491a-94fd-0a6ecf910da2"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0312ea2d-0724-4e71-8226-93da96bf4d27"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Clutch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4dc76e6f-3312-4e65-bf88-bda10c2c86d8"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Controller"",
            ""id"": ""12f03122-974c-41d2-b215-4ae2697c5697"",
            ""actions"": [
                {
                    ""name"": ""Steer"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7559e2e0-ab66-4b42-a892-d099a2bccd4b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Accelerate"",
                    ""type"": ""Value"",
                    ""id"": ""572bcab7-2573-4747-aa1f-e1a478b707d5"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Brake"",
                    ""type"": ""Value"",
                    ""id"": ""47b85871-4f31-4cd4-8cba-0bcf4c70ae5b"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Clutch"",
                    ""type"": ""Button"",
                    ""id"": ""f0807cd4-ad83-45e4-852b-c82aee45300d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ShiftUp"",
                    ""type"": ""Button"",
                    ""id"": ""b1cc41dc-cb4c-4d3c-8885-138ba1ed07e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap(duration=0.1,pressPoint=0.1)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ShiftDown"",
                    ""type"": ""Button"",
                    ""id"": ""4cb1bd66-304d-4a88-98f7-3977ab744c90"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap(duration=0.1,pressPoint=0.1)"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3bf7d9c7-b0cc-4bec-9ddd-98f24ed87c9f"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19182bf7-a638-457a-91c4-c7da5e7937fd"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c05ede4-7a4a-4f85-8406-7a12376b24c4"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f77ab541-30b1-4e6f-b50b-1686b9b28e93"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Clutch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3c24bf7-d1cf-4f6f-9fcf-8b9ddb8a91cb"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShiftUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1b10ae1c-c6f5-4cee-8e64-699829356c08"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShiftDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Wheel
        m_Wheel = asset.FindActionMap("Wheel", throwIfNotFound: true);
        m_Wheel_Accelerate = m_Wheel.FindAction("Accelerate", throwIfNotFound: true);
        m_Wheel_Brake = m_Wheel.FindAction("Brake", throwIfNotFound: true);
        m_Wheel_Clutch = m_Wheel.FindAction("Clutch", throwIfNotFound: true);
        m_Wheel_Steer = m_Wheel.FindAction("Steer", throwIfNotFound: true);
        // Controller
        m_Controller = asset.FindActionMap("Controller", throwIfNotFound: true);
        m_Controller_Steer = m_Controller.FindAction("Steer", throwIfNotFound: true);
        m_Controller_Accelerate = m_Controller.FindAction("Accelerate", throwIfNotFound: true);
        m_Controller_Brake = m_Controller.FindAction("Brake", throwIfNotFound: true);
        m_Controller_Clutch = m_Controller.FindAction("Clutch", throwIfNotFound: true);
        m_Controller_ShiftUp = m_Controller.FindAction("ShiftUp", throwIfNotFound: true);
        m_Controller_ShiftDown = m_Controller.FindAction("ShiftDown", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Wheel
    private readonly InputActionMap m_Wheel;
    private List<IWheelActions> m_WheelActionsCallbackInterfaces = new List<IWheelActions>();
    private readonly InputAction m_Wheel_Accelerate;
    private readonly InputAction m_Wheel_Brake;
    private readonly InputAction m_Wheel_Clutch;
    private readonly InputAction m_Wheel_Steer;
    public struct WheelActions
    {
        private @WheelControl m_Wrapper;
        public WheelActions(@WheelControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Accelerate => m_Wrapper.m_Wheel_Accelerate;
        public InputAction @Brake => m_Wrapper.m_Wheel_Brake;
        public InputAction @Clutch => m_Wrapper.m_Wheel_Clutch;
        public InputAction @Steer => m_Wrapper.m_Wheel_Steer;
        public InputActionMap Get() { return m_Wrapper.m_Wheel; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WheelActions set) { return set.Get(); }
        public void AddCallbacks(IWheelActions instance)
        {
            if (instance == null || m_Wrapper.m_WheelActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_WheelActionsCallbackInterfaces.Add(instance);
            @Accelerate.started += instance.OnAccelerate;
            @Accelerate.performed += instance.OnAccelerate;
            @Accelerate.canceled += instance.OnAccelerate;
            @Brake.started += instance.OnBrake;
            @Brake.performed += instance.OnBrake;
            @Brake.canceled += instance.OnBrake;
            @Clutch.started += instance.OnClutch;
            @Clutch.performed += instance.OnClutch;
            @Clutch.canceled += instance.OnClutch;
            @Steer.started += instance.OnSteer;
            @Steer.performed += instance.OnSteer;
            @Steer.canceled += instance.OnSteer;
        }

        private void UnregisterCallbacks(IWheelActions instance)
        {
            @Accelerate.started -= instance.OnAccelerate;
            @Accelerate.performed -= instance.OnAccelerate;
            @Accelerate.canceled -= instance.OnAccelerate;
            @Brake.started -= instance.OnBrake;
            @Brake.performed -= instance.OnBrake;
            @Brake.canceled -= instance.OnBrake;
            @Clutch.started -= instance.OnClutch;
            @Clutch.performed -= instance.OnClutch;
            @Clutch.canceled -= instance.OnClutch;
            @Steer.started -= instance.OnSteer;
            @Steer.performed -= instance.OnSteer;
            @Steer.canceled -= instance.OnSteer;
        }

        public void RemoveCallbacks(IWheelActions instance)
        {
            if (m_Wrapper.m_WheelActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IWheelActions instance)
        {
            foreach (var item in m_Wrapper.m_WheelActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_WheelActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public WheelActions @Wheel => new WheelActions(this);

    // Controller
    private readonly InputActionMap m_Controller;
    private List<IControllerActions> m_ControllerActionsCallbackInterfaces = new List<IControllerActions>();
    private readonly InputAction m_Controller_Steer;
    private readonly InputAction m_Controller_Accelerate;
    private readonly InputAction m_Controller_Brake;
    private readonly InputAction m_Controller_Clutch;
    private readonly InputAction m_Controller_ShiftUp;
    private readonly InputAction m_Controller_ShiftDown;
    public struct ControllerActions
    {
        private @WheelControl m_Wrapper;
        public ControllerActions(@WheelControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Steer => m_Wrapper.m_Controller_Steer;
        public InputAction @Accelerate => m_Wrapper.m_Controller_Accelerate;
        public InputAction @Brake => m_Wrapper.m_Controller_Brake;
        public InputAction @Clutch => m_Wrapper.m_Controller_Clutch;
        public InputAction @ShiftUp => m_Wrapper.m_Controller_ShiftUp;
        public InputAction @ShiftDown => m_Wrapper.m_Controller_ShiftDown;
        public InputActionMap Get() { return m_Wrapper.m_Controller; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControllerActions set) { return set.Get(); }
        public void AddCallbacks(IControllerActions instance)
        {
            if (instance == null || m_Wrapper.m_ControllerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ControllerActionsCallbackInterfaces.Add(instance);
            @Steer.started += instance.OnSteer;
            @Steer.performed += instance.OnSteer;
            @Steer.canceled += instance.OnSteer;
            @Accelerate.started += instance.OnAccelerate;
            @Accelerate.performed += instance.OnAccelerate;
            @Accelerate.canceled += instance.OnAccelerate;
            @Brake.started += instance.OnBrake;
            @Brake.performed += instance.OnBrake;
            @Brake.canceled += instance.OnBrake;
            @Clutch.started += instance.OnClutch;
            @Clutch.performed += instance.OnClutch;
            @Clutch.canceled += instance.OnClutch;
            @ShiftUp.started += instance.OnShiftUp;
            @ShiftUp.performed += instance.OnShiftUp;
            @ShiftUp.canceled += instance.OnShiftUp;
            @ShiftDown.started += instance.OnShiftDown;
            @ShiftDown.performed += instance.OnShiftDown;
            @ShiftDown.canceled += instance.OnShiftDown;
        }

        private void UnregisterCallbacks(IControllerActions instance)
        {
            @Steer.started -= instance.OnSteer;
            @Steer.performed -= instance.OnSteer;
            @Steer.canceled -= instance.OnSteer;
            @Accelerate.started -= instance.OnAccelerate;
            @Accelerate.performed -= instance.OnAccelerate;
            @Accelerate.canceled -= instance.OnAccelerate;
            @Brake.started -= instance.OnBrake;
            @Brake.performed -= instance.OnBrake;
            @Brake.canceled -= instance.OnBrake;
            @Clutch.started -= instance.OnClutch;
            @Clutch.performed -= instance.OnClutch;
            @Clutch.canceled -= instance.OnClutch;
            @ShiftUp.started -= instance.OnShiftUp;
            @ShiftUp.performed -= instance.OnShiftUp;
            @ShiftUp.canceled -= instance.OnShiftUp;
            @ShiftDown.started -= instance.OnShiftDown;
            @ShiftDown.performed -= instance.OnShiftDown;
            @ShiftDown.canceled -= instance.OnShiftDown;
        }

        public void RemoveCallbacks(IControllerActions instance)
        {
            if (m_Wrapper.m_ControllerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IControllerActions instance)
        {
            foreach (var item in m_Wrapper.m_ControllerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ControllerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ControllerActions @Controller => new ControllerActions(this);
    public interface IWheelActions
    {
        void OnAccelerate(InputAction.CallbackContext context);
        void OnBrake(InputAction.CallbackContext context);
        void OnClutch(InputAction.CallbackContext context);
        void OnSteer(InputAction.CallbackContext context);
    }
    public interface IControllerActions
    {
        void OnSteer(InputAction.CallbackContext context);
        void OnAccelerate(InputAction.CallbackContext context);
        void OnBrake(InputAction.CallbackContext context);
        void OnClutch(InputAction.CallbackContext context);
        void OnShiftUp(InputAction.CallbackContext context);
        void OnShiftDown(InputAction.CallbackContext context);
    }
}
