using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VRCockpitMover))]
[RequireComponent(typeof(VRCockpitInput))]
[RequireComponent(typeof(VRCockpitCanon))]

public class VRCockpitControler : MonoBehaviour
{
    [HideInInspector] public VRCockpitMover vrMover;
    [HideInInspector] public VRCockpitInput vrInput;
    [HideInInspector] public VRCockpitCanon vrCanon;

    private void Awake()
    {
        vrMover = GetComponent<VRCockpitMover>();
        vrMover.Initialize();
        vrInput = GetComponent<VRCockpitInput>();
        vrInput.Initialize();
        vrCanon = GetComponent<VRCockpitCanon>();
        vrCanon.Initialize();
    }

    private void Update()
    {
        vrMover.RotationCockpit();
        vrCanon.ChangeCooldownValue();
        vrCanon.SpawnProjectile();
    }

}
