using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.OpenXR.Samples.ControllerSample;

public class VRMover : ActionToControl
{
    [SerializeField] public Outline _outline;
    [SerializeField] public Transform _ParentObject;

    protected override void OnActionStarted(InputAction.CallbackContext ctx)
    {
        _outline.OutlineColor = Color.cyan;
        transform.SetParent(_ParentObject);
    }

    protected override void OnActionCanceled(InputAction.CallbackContext ctx)
    {
        transform.SetParent(null);
        _outline.OutlineColor = Color.white;
    }
}
