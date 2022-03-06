using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class VRCockpitProjectile : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float lifeTime;

    Rigidbody rigid;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigid.AddForce(transform.forward * moveSpeed * Time.deltaTime, ForceMode.Force);
    }
}
