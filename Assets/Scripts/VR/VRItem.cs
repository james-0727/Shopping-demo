using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.XR.OpenXR.Samples.ControllerSample;

public class VRItem : ActionToControl
{
    [SerializeField] private TextMeshProUGUI _Status;
    [SerializeField] private bool _interactable;
    [SerializeField] private VRObjectSelector _Selector;

    [SerializeField] private VRInteractable _interactor;
    [SerializeField] private VRMover _mover;
    [SerializeField] private VRResizer _resize;
    [SerializeField] private VRRotator _rotator;


    private State m_CurrentState = 0;

    private enum State
    {
        Interact,
        Resize,
        Move,
        Rotate
    }

    // Start is called before the first frame update
    void Start()
    {
        m_CurrentState = (State)(_interactable? 0 : 1);
        _Selector.OnSelected.AddListener(ControllerAction);
        NextState();
    }

    public void NextState()
    {
        m_CurrentState++;
        if((int)m_CurrentState == System.Enum.GetValues(typeof(State)).Length)
        {
            m_CurrentState = (State)(_interactable ? 0 : 1);
        }
        _Status.text = m_CurrentState.ToString();
        if (_Selector._Selected)
        {
            _Selector.OnUnSelected.Invoke();
            _Selector.OnSelected.Invoke();
        }
    }

    protected override void OnActionStarted(InputAction.CallbackContext ctx)
    {
        NextState();
    }

    private void ControllerAction()
    {
        if(m_CurrentState == State.Interact)
        {
            _interactor.enabled = true;
        }
        else if (m_CurrentState == State.Resize)
        {
            _resize.enabled = true;
        }
        else if (m_CurrentState == State.Move)
        {
            _mover.enabled = true;
        }
        else if (m_CurrentState == State.Rotate)
        {
            _rotator.enabled = true;
        }
    }
}
