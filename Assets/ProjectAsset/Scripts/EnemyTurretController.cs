using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using FMODUnity;

public class EnemyTurretController : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    public float cooldown = 2.0f;
    public float sphereCastWidth = 1.0f;
    public float maxPlayerDistance = 100.0f;
    public int targetMask = 0;
    public Transform canonPosition;
    public VisualEffect canonVisualEffect;
    public VisualEffect destructionVisualEffect;
    public EventReference destructionSoundEffect;
    public GameObject projectile;

    private GameObject target;
    private bool isInCooldown = false;
    private float lastShotTime = 0f;
    private float hitPoints = 100.0f;
    private bool isDestroyed = false;

    void Start()
    {
        // Lock player as target
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (isDestroyed)
            return;

        if (target != null && target.activeSelf && Vector3.Distance(target.transform.position, transform.position) < maxPlayerDistance)
        {
            // rotation
            var direction = (transform.position - target.transform.position).normalized;
            Vector3 addAngle = direction * (Time.fixedDeltaTime * rotationSpeed);
            transform.forward += addAngle;
        }

        // exit if in cooldown
        if (Time.time < lastShotTime + cooldown)
            return;

        RaycastHit hit;
        if (Physics.SphereCast(transform.position, sphereCastWidth, transform.TransformDirection(Vector3.back), out hit, maxPlayerDistance, 1 << targetMask))
        {
            Shoot();
        }
        UnityEngine.Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * maxPlayerDistance, Color.yellow);
    }

    void Shoot()
    {
        lastShotTime = Time.time;
        // Inverse to shoot forward
        var projectileRotation = canonPosition.rotation.eulerAngles;
        projectileRotation.y *= -1;
        GameObject newProjectile = Instantiate(projectile, canonPosition.position, Quaternion.LookRotation(-transform.forward, Vector3.up));

        RuntimeManager.PlayOneShot(destructionSoundEffect, canonPosition.transform.position);
        canonVisualEffect.Play();
    }

    void Explode()
    {
        RuntimeManager.PlayOneShot("event:/Explosion", transform.position);
        destructionVisualEffect.Play();
    }

    public void Damage(float damage)
    {
        if (isDestroyed)
            return;

        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Explode();
            isDestroyed = true;
        }
    }
}
