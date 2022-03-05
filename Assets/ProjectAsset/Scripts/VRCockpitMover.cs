using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VRCockpitMover : MonoBehaviour
{

    [SerializeField] float rotationSpeed;
    [SerializeField] Transform axeToRotate;
    [SerializeField] Vector2 minRotationRestrict;
    [SerializeField] Vector2 maxRotationRestrict;

    bool canRotate;


    VRCockpitControler vrControler;
    public void Initialize()
    {
        vrControler = GetComponent<VRCockpitControler>();
        canRotate = false;
    }


    public void RotationCockpit()
    {
         
        Vector2 inputRotaVector = vrControler.vrInput.rotationInputValue;
        if (canRotate) axeToRotate.Rotate(new Vector3(inputRotaVector.y, inputRotaVector.x, 0),Space.Self);
        Vector3 cockpitRota = axeToRotate.localRotation.eulerAngles;
        cockpitRota.y = (cockpitRota.y > 180) ? cockpitRota.y - 360 : cockpitRota.y;
        cockpitRota.y = Mathf.Clamp(cockpitRota.y, minRotationRestrict.y, maxRotationRestrict.y);
        cockpitRota.x = (cockpitRota.x > 180) ? cockpitRota.x - 360 : cockpitRota.x;
        cockpitRota.x = Mathf.Clamp(cockpitRota.x, minRotationRestrict.x, maxRotationRestrict.x);
        axeToRotate.localRotation = Quaternion.Euler(cockpitRota);
    }

    public void ChangeStateRotate(bool state) => canRotate = state;

}
