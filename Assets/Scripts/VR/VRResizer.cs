using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.OpenXR.Samples.ControllerSample;
public class VRResizer : ActionToControl
{
    [SerializeField] public Transform _mainObject = null;
    [SerializeField] public float _resizeFactor = 1.0f;

    protected override void OnActionPerformed(InputAction.CallbackContext ctx) => UpdateHandle(ctx);

    protected override void OnActionStarted(InputAction.CallbackContext ctx) => UpdateHandle(ctx);

    protected override void OnActionCanceled(InputAction.CallbackContext ctx) => UpdateHandle(ctx);

    private void UpdateHandle(InputAction.CallbackContext ctx)
    {
        _mainObject.localScale = _mainObject.localScale + _resizeFactor * ctx.ReadValue<Vector2>().x * Vector3.one;
    }
}
