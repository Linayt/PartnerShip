using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using FMODUnity;

public class VRCockpitCanon : MonoBehaviour
{
    [Header("Spawn")]
    [SerializeField] GameObject projectile;
    [SerializeField] List<Transform> spawnPoints;
    

    [Header("Timming")]
    [SerializeField] float cooldownBetweenFire;

    [Header("Fmod")]
    [SerializeField] EventReference sonTirEvent;

    bool canFire;
    float cooldown;
    bool isFiring;

    VRCockpitControler vrControler;
    public void Initialize()
    {
        vrControler = GetComponent<VRCockpitControler>();
        canFire = false;
        isFiring = false;
        cooldown = cooldownBetweenFire;
        XRIDefaultInputActions vrPlayerInput = new XRIDefaultInputActions();
        vrPlayerInput.XRIRightHand.Enable();
        vrPlayerInput.XRIRightHand.Fireinput.started += StartFire;
        vrPlayerInput.XRIRightHand.Fireinput.canceled += StopFire;
    }

    

    public void ChangeCanFireState(bool state) => canFire = state;


    public bool CanFire() => canFire && cooldown == cooldownBetweenFire && isFiring;

    public void SpawnProjectile()
    {
        if (CanFire())
        {
            foreach (var spawnPoint in spawnPoints)
            {
                Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
                RuntimeManager.PlayOneShot(sonTirEvent, spawnPoint.position);
            }
            cooldown = 0;
            
        }
    }

    public void StartFire(InputAction.CallbackContext context)
    { 
        isFiring = true;
        Debug.Log("StartFire");
    }

    public void StopFire(InputAction.CallbackContext context)
    {
        isFiring = false;
        Debug.Log("StopFire");
    }

    public void ChangeCooldownValue() => cooldown = Mathf.Clamp(cooldown + Time.deltaTime, 0, cooldownBetweenFire);
}
