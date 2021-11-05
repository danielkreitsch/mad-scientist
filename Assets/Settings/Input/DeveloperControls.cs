// GENERATED AUTOMATICALLY FROM 'Assets/Settings/Input/DeveloperControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @DeveloperControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @DeveloperControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DeveloperControls"",
    ""maps"": [
        {
            ""name"": ""Default"",
            ""id"": ""61ee645b-feb8-4945-9619-7258beaf4da0"",
            ""actions"": [
                {
                    ""name"": ""Toogle Debug Screen"",
                    ""type"": ""Button"",
                    ""id"": ""6f089da9-6643-4343-a641-c11d3e52f075"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""62c1eebc-7a38-425d-9dc2-59938f28db4d"",
                    ""path"": ""<Keyboard>/f3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Toogle Debug Screen"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Default
        m_Default = asset.FindActionMap("Default", throwIfNotFound: true);
        m_Default_ToogleDebugScreen = m_Default.FindAction("Toogle Debug Screen", throwIfNotFound: true);
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

    // Default
    private readonly InputActionMap m_Default;
    private IDefaultActions m_DefaultActionsCallbackInterface;
    private readonly InputAction m_Default_ToogleDebugScreen;
    public struct DefaultActions
    {
        private @DeveloperControls m_Wrapper;
        public DefaultActions(@DeveloperControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ToogleDebugScreen => m_Wrapper.m_Default_ToogleDebugScreen;
        public InputActionMap Get() { return m_Wrapper.m_Default; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefaultActions set) { return set.Get(); }
        public void SetCallbacks(IDefaultActions instance)
        {
            if (m_Wrapper.m_DefaultActionsCallbackInterface != null)
            {
                @ToogleDebugScreen.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnToogleDebugScreen;
                @ToogleDebugScreen.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnToogleDebugScreen;
                @ToogleDebugScreen.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnToogleDebugScreen;
            }
            m_Wrapper.m_DefaultActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ToogleDebugScreen.started += instance.OnToogleDebugScreen;
                @ToogleDebugScreen.performed += instance.OnToogleDebugScreen;
                @ToogleDebugScreen.canceled += instance.OnToogleDebugScreen;
            }
        }
    }
    public DefaultActions @Default => new DefaultActions(this);
    public interface IDefaultActions
    {
        void OnToogleDebugScreen(InputAction.CallbackContext context);
    }
}
