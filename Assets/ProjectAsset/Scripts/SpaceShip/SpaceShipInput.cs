using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceShipInput : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] string thrustInput;
    [SerializeField] string hoverXInput;
    [SerializeField] string hoverYInput;
    [SerializeField] string rollInput;

    SpaceShipControler sControler;
    public void Initialize()
    {
        sControler = GetComponent<SpaceShipControler>();
        
    }

    public float GetThrustInputValue() => Input.GetAxisRaw(thrustInput);

    public Vector2 GetHoverInputValue() => new Vector2(Input.GetAxis(hoverXInput), Input.GetAxis(hoverYInput));

    public float GetRollInputValue() => Input.GetAxisRaw(rollInput);

}
