using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(SpaceShipInput))]
[RequireComponent(typeof(SpaceShipMovement))]
[RequireComponent(typeof(SpaceShipLife))]

public class SpaceShipControler : MonoBehaviour
{

    [HideInInspector] public SpaceShipInput sInput;
    [HideInInspector] public SpaceShipMovement sMovement;
    [HideInInspector] public SpaceShipLife sLife;

    private void Awake()
    {
        sInput = GetComponent<SpaceShipInput>();
        sInput.Initialize();
        sMovement = GetComponent<SpaceShipMovement>();
        sMovement.Initialize();
        sLife = GetComponent<SpaceShipLife>();
        sLife.Initialize();

    }

    private void Update()
    {
        sMovement.Move();
    }
}
