using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using FMODUnity;

public class IEMRocketController : MonoBehaviour
{
    public float movementSpeed = 250.0f;
    public float rotationSpeed = 0.5f;
    public float damageValue = 10.0f;
    public TemporaryVFXController temporaryVFX;
    public VisualEffectAsset explosionVFXAsset;
    public EventReference explosionSoundEffect;

    private GameObject target;
    private Vector3 velocity;
    
    void Start()
    {
        // Lock player as target
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (target != null && target.activeSelf)
        {
            // rotation
            var direction = (target.transform.position - transform.position).normalized;
            Vector3 addAngle = direction * (Time.fixedDeltaTime * rotationSpeed);
            transform.forward += addAngle;

            // velocity
            velocity = transform.forward * (Time.fixedDeltaTime * movementSpeed);
        }

        transform.position += velocity;
    }

    void Explode()
    {
        RuntimeManager.PlayOneShot(explosionSoundEffect, transform.position);
        var newTemporaryVFX = GameObject.Instantiate(temporaryVFX, transform.position, transform.rotation);
        var newVisualEffect = newTemporaryVFX.GetComponent<VisualEffect>();
        newVisualEffect.visualEffectAsset = explosionVFXAsset;
        newVisualEffect.Play();
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        try
        {
            SpaceShipControler target = collision.gameObject.GetComponent<SpaceShipControler>();
            target.sLife.TakeDamage(damageValue);
        }
        finally
        {
            Explode();
        }   
    }
}
