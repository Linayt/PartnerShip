using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceShipMovement : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] float startThrusterForce;
    [SerializeField] float thrusterAcceleration;
    [SerializeField] float minThrusterForce;
    [SerializeField] float maxThrusterForce;
    [SerializeField] float rollSpeed;
    [SerializeField] float hoverSpeed;

    float currentThrusterForce;

    [Header("Turbo")]
    [SerializeField] float turboSpeed;


    /*[Header("Limit")]
    [SerializeField] Vector2 hoverMaxLimits;
    [SerializeField] Vector2 hoverMinLimits;*/

    CharacterController characControl;

    [Header("Camera")]
    [SerializeField] Animator cameraAnimator;
    [SerializeField] string speedCameraAnimatorParameter;

    SpaceShipControler sControler;

    float percantSpeed;

    public void Initialize()
    {
        sControler = GetComponent<SpaceShipControler>();
        characControl = GetComponent<CharacterController>();
        currentThrusterForce = startThrusterForce;
    }

    //public void Thrust() => characControl.Move(transform.forward * thrusterForce * Time.deltaTime);

    public void Move()
    {
        ChangeThrusterValue(sControler.sInput.GetThrustInputValue());
        Vector3 thrusteValue = transform.forward * currentThrusterForce * Time.deltaTime;
        characControl.Move(thrusteValue);

        cameraAnimator.SetFloat(speedCameraAnimatorParameter, CalculPercantSpeed());

        //float shipRotationX = Mathf.Clamp()

        Vector3 shipRotationValue = 
            new Vector3(-sControler.sInput.GetHoverInputValue().y * hoverSpeed, sControler.sInput.GetHoverInputValue().x * hoverSpeed, -sControler.sInput.GetRollInputValue() * rollSpeed);

        Vector3 cameraRotation = new Vector3(0, 0, -sControler.sInput.GetRollInputValue() * rollSpeed);

        transform.Rotate(shipRotationValue*Time.deltaTime, Space.Self);
        //cameraAxe.Rotate(cameraRotation, Space.Self);
    }

    public void ChangeThrusterValue(float delta) => currentThrusterForce = Mathf.Clamp(currentThrusterForce + (delta * thrusterAcceleration * Time.deltaTime), minThrusterForce, maxThrusterForce);
    

    public float CalculPercantSpeed() => currentThrusterForce >= startThrusterForce ? (currentThrusterForce - startThrusterForce) / (maxThrusterForce - startThrusterForce)
            : (startThrusterForce - currentThrusterForce) / (minThrusterForce - startThrusterForce);

    

     
}
