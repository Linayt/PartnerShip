using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictRotation : MonoBehaviour
{
    [SerializeField] Vector3 rotationMinLimite;
    [SerializeField] Vector3 rotationMaxLimite;

    [SerializeField] Transform axeToRestrict;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void  FixedUpdate()
    {

        RestrictRota();
        
    }

    public void RestrictRota()
    {
        Vector3 rotaAxe = axeToRestrict.localRotation.eulerAngles;
        rotaAxe.x = (rotaAxe.x > 180) ? rotaAxe.x - 360 : rotaAxe.x;
        rotaAxe.x = Mathf.Clamp(rotaAxe.x, rotationMinLimite.x, rotationMaxLimite.x);
        rotaAxe.y = (rotaAxe.y > 180) ? rotaAxe.y - 360 : rotaAxe.y;
        rotaAxe.y = Mathf.Clamp(rotaAxe.y, rotationMinLimite.y, rotationMaxLimite.y);
        rotaAxe.z = (rotaAxe.z > 180) ? rotaAxe.z - 360 : rotaAxe.z;
        rotaAxe.z = Mathf.Clamp(rotaAxe.z, rotationMinLimite.z, rotationMaxLimite.z);

        axeToRestrict.rotation = Quaternion.Euler(rotaAxe);
    }
}
