using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private float spawnTime;

    public float movementSpeed = 10.0f;
    public float lifetime = 10.0f;

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

    void OnCollisionEnter(Collision collision)
    {
        // TODO add vfx
        // TODO add sfx
        Destroy(gameObject);
    }
}
