using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.OpenXR.Samples.ControllerSample;

public class VRRotator : ActionToControl
{
    [SerializeField] public Transform _mainObject = null;
    [SerializeField] public float _rotationSpeed = 5.0f;

    protected override void OnActionPerformed(InputAction.CallbackContext ctx) => UpdateHandle(ctx);

    protected override void OnActionStarted(InputAction.CallbackContext ctx) => UpdateHandle(ctx);

    protected override void OnActionCanceled(InputAction.CallbackContext ctx) => UpdateHandle(ctx);

    private void UpdateHandle(InputAction.CallbackContext ctx)
    {
        //_handle.anchorMin = _handle.anchorMax = (ctx.ReadValue<Vector2>() + Vector2.one) * 0.5f;
        
        var originAngles = _mainObject.eulerAngles;
        Vector3 vOffset = new Vector3(0, -ctx.ReadValue<Vector2>().x * _rotationSpeed, 0);
        _mainObject.eulerAngles = originAngles + vOffset;
    }
}
