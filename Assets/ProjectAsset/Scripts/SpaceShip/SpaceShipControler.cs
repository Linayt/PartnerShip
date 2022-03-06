using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(SpaceShipInput))]
[RequireComponent(typeof(SpaceShipMovement))]

public class SpaceShipControler : MonoBehaviour
{

    [HideInInspector] public SpaceShipInput sInput;
    [HideInInspector] public SpaceShipMovement sMovement;

    private void Awake()
    {
        sInput = GetComponent<SpaceShipInput>();
        sInput.Initialize();
        sMovement = GetComponent<SpaceShipMovement>();
        sMovement.Initialize();

    }

    private void Update()
    {
        sMovement.Move();
    }
}
