// GENERATED AUTOMATICALLY FROM 'Assets/Settings/Input/MenuControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MenuControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MenuControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MenuControls"",
    ""maps"": [
        {
            ""name"": ""Default"",
            ""id"": ""5c5f7728-01d1-4f56-b64d-4a65f422ed13"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""4d4d401f-061d-4385-9ed7-2f517f7bfcb0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""fb932802-9cfc-4a45-ad8b-cc0983f8ec32"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OpenPauseMenu"",
                    ""type"": ""Button"",
                    ""id"": ""06c733e1-e1db-4c9b-b69f-796fe4a45908"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""f4ecab54-337b-467c-ae2d-e4f9b314d47a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""45fb211d-75fc-4fb2-9c23-df4e3991f2ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""a5c9a8fb-aeb7-446f-8e16-7b684260e2a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""fb9cc20a-2fdb-42c6-af58-0a9c5f438744"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftTab"",
                    ""type"": ""Button"",
                    ""id"": ""7cfde225-8ebd-478d-a921-90b0c1b46550"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightTab"",
                    ""type"": ""Button"",
                    ""id"": ""c6353890-8e86-48ab-92bc-dcee93d6a03b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""60fcb694-55a5-4097-b19f-6aa4cb5cff54"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenPauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15ce9ce9-e1b4-4297-869b-66e625126412"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenPauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""edbe758b-c238-4642-9b85-da31cf0bc00d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bfc8dacc-1bb7-42ac-8ec8-3a08ad9e00b7"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e77250e2-bc8e-48c2-8d29-856dc23d8758"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee532ad7-11d1-4b2a-b9f5-a7614e16d1b2"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8afd656b-50d2-4b2f-9543-f4efa132b3a3"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c9dd510e-b471-4e7f-8294-e9228b600ebb"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e5b5e3ee-282c-4efe-86b2-172fdf33973c"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1b95ccb0-82c9-4941-ad21-33a161994549"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6778c14-9d49-4a72-80dc-bf90f2a8f0dc"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72ef9840-9cdd-4084-a420-8d3678e6287b"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f20311e6-d2a9-47a2-a3a8-ea492012a05c"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5d98a15-c5a7-4bc5-9a7f-dc92e6c1da01"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""406d609f-8820-4ba7-a925-f79cc47c9455"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9c9be6b-b658-4506-a6d0-f11526aea938"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0bd2f6c8-f4ea-407b-a8be-9da3d0c6fdcc"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2fa9218-1ed8-477a-822a-56825e539363"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3682a477-3b0f-4972-939c-ada5f94a7d12"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd9a8290-468f-4c98-ad97-fef903fbb904"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d23b5d61-079f-4ab1-b909-08d27bd22938"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3bf64448-5eda-4d7d-b12d-f43c50141d39"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3775d1ef-97ec-4951-96f5-52aa7d2973f8"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e0f3846e-ad2d-41ca-8ecb-f1967d1abf2f"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftTab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9564cf3-d9e6-4d49-8ca1-d706cfd70c6a"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightTab"",
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
        m_Default_Select = m_Default.FindAction("Select", throwIfNotFound: true);
        m_Default_Back = m_Default.FindAction("Back", throwIfNotFound: true);
        m_Default_OpenPauseMenu = m_Default.FindAction("OpenPauseMenu", throwIfNotFound: true);
        m_Default_Up = m_Default.FindAction("Up", throwIfNotFound: true);
        m_Default_Down = m_Default.FindAction("Down", throwIfNotFound: true);
        m_Default_Left = m_Default.FindAction("Left", throwIfNotFound: true);
        m_Default_Right = m_Default.FindAction("Right", throwIfNotFound: true);
        m_Default_LeftTab = m_Default.FindAction("LeftTab", throwIfNotFound: true);
        m_Default_RightTab = m_Default.FindAction("RightTab", throwIfNotFound: true);
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
    private readonly InputAction m_Default_Select;
    private readonly InputAction m_Default_Back;
    private readonly InputAction m_Default_OpenPauseMenu;
    private readonly InputAction m_Default_Up;
    private readonly InputAction m_Default_Down;
    private readonly InputAction m_Default_Left;
    private readonly InputAction m_Default_Right;
    private readonly InputAction m_Default_LeftTab;
    private readonly InputAction m_Default_RightTab;
    public struct DefaultActions
    {
        private @MenuControls m_Wrapper;
        public DefaultActions(@MenuControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Select => m_Wrapper.m_Default_Select;
        public InputAction @Back => m_Wrapper.m_Default_Back;
        public InputAction @OpenPauseMenu => m_Wrapper.m_Default_OpenPauseMenu;
        public InputAction @Up => m_Wrapper.m_Default_Up;
        public InputAction @Down => m_Wrapper.m_Default_Down;
        public InputAction @Left => m_Wrapper.m_Default_Left;
        public InputAction @Right => m_Wrapper.m_Default_Right;
        public InputAction @LeftTab => m_Wrapper.m_Default_LeftTab;
        public InputAction @RightTab => m_Wrapper.m_Default_RightTab;
        public InputActionMap Get() { return m_Wrapper.m_Default; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefaultActions set) { return set.Get(); }
        public void SetCallbacks(IDefaultActions instance)
        {
            if (m_Wrapper.m_DefaultActionsCallbackInterface != null)
            {
                @Select.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSelect;
                @Back.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnBack;
                @OpenPauseMenu.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnOpenPauseMenu;
                @OpenPauseMenu.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnOpenPauseMenu;
                @OpenPauseMenu.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnOpenPauseMenu;
                @Up.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnDown;
                @Left.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRight;
                @LeftTab.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnLeftTab;
                @LeftTab.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnLeftTab;
                @LeftTab.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnLeftTab;
                @RightTab.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRightTab;
                @RightTab.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRightTab;
                @RightTab.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRightTab;
            }
            m_Wrapper.m_DefaultActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @OpenPauseMenu.started += instance.OnOpenPauseMenu;
                @OpenPauseMenu.performed += instance.OnOpenPauseMenu;
                @OpenPauseMenu.canceled += instance.OnOpenPauseMenu;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @LeftTab.started += instance.OnLeftTab;
                @LeftTab.performed += instance.OnLeftTab;
                @LeftTab.canceled += instance.OnLeftTab;
                @RightTab.started += instance.OnRightTab;
                @RightTab.performed += instance.OnRightTab;
                @RightTab.canceled += instance.OnRightTab;
            }
        }
    }
    public DefaultActions @Default => new DefaultActions(this);
    public interface IDefaultActions
    {
        void OnSelect(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnOpenPauseMenu(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnLeftTab(InputAction.CallbackContext context);
        void OnRightTab(InputAction.CallbackContext context);
    }
}
