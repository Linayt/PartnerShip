using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using FMODUnity;

public class EnemyLaserController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private float spawnTime;

    public float movementSpeed = 10.0f;
    public float lifetime = 10.0f;
    public float damageValue = 10.0f;
    public TemporaryVFXController temporaryVFX;
    public VisualEffectAsset explosionVFXAsset;
    public EventReference explosionSoundEffect;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        spawnTime = Time.time;
    }
    void Update()
    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
        // Destroy if too far away
        if (Time.time - spawnTime > lifetime)
        {
            Destroy(gameObject);
        }
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
            // TODO with player ship
            // PlayerShip target = collision.gameObject.GetComponent<PlayerShip>();
            // target.Damage(damageValue);
        }
        finally
        {
            Explode();
        }        
    }
}
