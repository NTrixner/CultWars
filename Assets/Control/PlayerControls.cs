// GENERATED AUTOMATICALLY FROM 'Assets/Control/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Priest"",
            ""id"": ""c5a7de78-b2ff-44f5-84b9-04fd83a88d3b"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""Value"",
                    ""id"": ""9a2d069e-c7e5-437a-87b8-4d645fc66014"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Command"",
                    ""type"": ""Button"",
                    ""id"": ""877ea9d0-5987-40d3-8555-f749942c9832"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""158855e1-9f33-4f03-a226-df3677024367"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""66ea9659-1446-45de-ad61-baab037d9b3a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""88bbbd29-0540-429d-a701-ce630a81f328"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""dd4a7237-e248-4b43-95fa-b36ec0cf745a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""80bdae05-02f8-46ac-884a-efe7cca40715"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""73d9dec6-8737-47ae-82db-7d291f4b83ab"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""391ed727-13b7-4a27-8d6c-2200da8848d1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a627cb41-8502-42e4-aaf6-2f0a42001ff8"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Command"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c99982c-9042-41cf-b9e7-30652e9ebdd5"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f78d7e1-fde7-4bb3-9721-eeb77db8d8a0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Priest
        m_Priest = asset.FindActionMap("Priest", throwIfNotFound: true);
        m_Priest_Walk = m_Priest.FindAction("Walk", throwIfNotFound: true);
        m_Priest_Command = m_Priest.FindAction("Command", throwIfNotFound: true);
        m_Priest_Confirm = m_Priest.FindAction("Confirm", throwIfNotFound: true);
        m_Priest_Cancel = m_Priest.FindAction("Cancel", throwIfNotFound: true);
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

    // Priest
    private readonly InputActionMap m_Priest;
    private IPriestActions m_PriestActionsCallbackInterface;
    private readonly InputAction m_Priest_Walk;
    private readonly InputAction m_Priest_Command;
    private readonly InputAction m_Priest_Confirm;
    private readonly InputAction m_Priest_Cancel;
    public struct PriestActions
    {
        private @PlayerControls m_Wrapper;
        public PriestActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_Priest_Walk;
        public InputAction @Command => m_Wrapper.m_Priest_Command;
        public InputAction @Confirm => m_Wrapper.m_Priest_Confirm;
        public InputAction @Cancel => m_Wrapper.m_Priest_Cancel;
        public InputActionMap Get() { return m_Wrapper.m_Priest; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PriestActions set) { return set.Get(); }
        public void SetCallbacks(IPriestActions instance)
        {
            if (m_Wrapper.m_PriestActionsCallbackInterface != null)
            {
                @Walk.started -= m_Wrapper.m_PriestActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_PriestActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_PriestActionsCallbackInterface.OnWalk;
                @Command.started -= m_Wrapper.m_PriestActionsCallbackInterface.OnCommand;
                @Command.performed -= m_Wrapper.m_PriestActionsCallbackInterface.OnCommand;
                @Command.canceled -= m_Wrapper.m_PriestActionsCallbackInterface.OnCommand;
                @Confirm.started -= m_Wrapper.m_PriestActionsCallbackInterface.OnConfirm;
                @Confirm.performed -= m_Wrapper.m_PriestActionsCallbackInterface.OnConfirm;
                @Confirm.canceled -= m_Wrapper.m_PriestActionsCallbackInterface.OnConfirm;
                @Cancel.started -= m_Wrapper.m_PriestActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_PriestActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_PriestActionsCallbackInterface.OnCancel;
            }
            m_Wrapper.m_PriestActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @Command.started += instance.OnCommand;
                @Command.performed += instance.OnCommand;
                @Command.canceled += instance.OnCommand;
                @Confirm.started += instance.OnConfirm;
                @Confirm.performed += instance.OnConfirm;
                @Confirm.canceled += instance.OnConfirm;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
            }
        }
    }
    public PriestActions @Priest => new PriestActions(this);
    public interface IPriestActions
    {
        void OnWalk(InputAction.CallbackContext context);
        void OnCommand(InputAction.CallbackContext context);
        void OnConfirm(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
    }
}
