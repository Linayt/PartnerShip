using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TemporaryVFXController : MonoBehaviour
{
    public float lifeTime = 5.0f;
    private float creationTime;

    void Start()
    {
        creationTime = Time.time;
    }

    void Update()
    {
        if(Time.time > creationTime + lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
