using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.XR.OpenXR.Samples.ControllerSample;

public class VRInteractable : ActionToControl
{
    [SerializeField] private UnityEvent _OnActionStarted;
    protected override void OnActionStarted(InputAction.CallbackContext ctx)
    {
        _OnActionStarted.Invoke();
        //Debug.Log("hehe");
    }
}
