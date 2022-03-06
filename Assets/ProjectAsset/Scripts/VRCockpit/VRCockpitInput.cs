using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VRCockpitInput : MonoBehaviour
{
    [HideInInspector]
    public Vector2 rotationInputValue;

    VRCockpitControler vrControler;
    public void Initialize()
    {
        vrControler = GetComponent<VRCockpitControler>();
        XRIDefaultInputActions vrPlayerInput = new XRIDefaultInputActions();
        vrPlayerInput.XRILeftHand.Enable();
        vrPlayerInput.XRILeftHand.RotateAnchor.performed += InputRotationXCockpit;
        vrPlayerInput.XRILeftHand.TranslateAnchor.performed += InputRotationYCockpit;
        vrPlayerInput.XRIRightHand.Enable();
        vrPlayerInput.XRIRightHand.Fireinput.performed += InputFireCockpit;
    }


    public void InputRotationXCockpit(InputAction.CallbackContext context)
    {
        rotationInputValue.x = context.ReadValue<Vector2>().x;
        
    }
    public void InputRotationYCockpit(InputAction.CallbackContext context)
    {
        rotationInputValue.y = context.ReadValue<Vector2>().y;
    }

    public void InputFireCockpit(InputAction.CallbackContext context)
    {
        //vrControler.vrCanon.SpawnProjectile();
    }

}
