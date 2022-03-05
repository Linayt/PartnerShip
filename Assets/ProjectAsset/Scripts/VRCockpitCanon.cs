using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCockpitCanon : MonoBehaviour
{
    [Header("Spawn")]
    [SerializeField] GameObject projectile;
    [SerializeField] Transform spawnPoint;
    

    [Header("Timming")]
    [SerializeField] float cooldownBetweenFire;


    bool canFire;
    float cooldown;

    VRCockpitControler vrControler;
    public void Initialize()
    {
        vrControler = GetComponent<VRCockpitControler>();
        canFire = false;
        cooldown = cooldownBetweenFire;

    }

    

    public void ChangeCanFireState(bool state) => canFire = state;


    public bool CanFire() => canFire && cooldown == cooldownBetweenFire;

    public void SpawnProjectile()
    {
        if (CanFire())
        {
            Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
            cooldown = 0;
        }
    }

    public void ChangeCooldownValue() => cooldown = Mathf.Clamp(cooldown + Time.deltaTime, 0, cooldownBetweenFire);
}
