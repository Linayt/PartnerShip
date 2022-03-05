using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurretController : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    public float cooldown = 2.0f;
    public float sphereCastWidth = 1.0f;
    public float maxPlayerDistance = 100.0f;
    public int targetMask = 0;
    public Transform canonPosition;
    public GameObject projectile;

    private GameObject target;
    private MeshCollider targetCollider;
    private bool isInCooldown = false;
    private float lastShotTime = 0f;

    void Start()
    {
        // Lock player as target
        target = GameObject.FindGameObjectWithTag("Player");
        targetCollider = target.GetComponentInChildren<MeshCollider>();
    }

    void Update()
    {
        if (target != null && target.activeSelf && Vector3.Distance(target.transform.position, transform.position) < maxPlayerDistance)
        {
            // rotation
            var direction = (target.transform.position - transform.position).normalized;
            Vector3 addAngle = direction * (Time.fixedDeltaTime * rotationSpeed);
            transform.forward += addAngle;
        }

        // exit if in cooldown
        if (Time.time < lastShotTime + cooldown)
            return;

        RaycastHit hit;
        if (Physics.SphereCast(transform.position, sphereCastWidth, transform.TransformDirection(Vector3.forward), out hit, maxPlayerDistance, 1 << targetMask)){
            Shoot();
        }
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * maxPlayerDistance, Color.yellow);
    }

    void Shoot()
    {
        lastShotTime = Time.time;
        GameObject newProjectile = Instantiate(projectile, canonPosition.position, canonPosition.rotation);
        // TODO SFX
        // TODO VFX
    }
}
