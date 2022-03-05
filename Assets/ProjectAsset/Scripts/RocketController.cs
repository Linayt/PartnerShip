using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public float movementSpeed = 250.0f;
    public float rotationSpeed = 0.5f;

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
        // TODO add vfx
        // TODO add sfx
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        Explode();
    }
}
