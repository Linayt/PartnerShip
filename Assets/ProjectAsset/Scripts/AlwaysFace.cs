using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysFace : MonoBehaviour
{
    GameObject radarCamera;
    SpriteRenderer spriteRenderer;
    GameObject player;
    float yDistance;

    public Sprite circle;
    public Sprite up;
    public Sprite down;

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        radarCamera = GameObject.Find("Radar Camera");
        player = GameObject.Find("Player");
    }


    void Update()
    {

        transform.rotation = radarCamera.transform.rotation;
        yDistance = player.transform.InverseTransformDirection(transform.position).y - player.transform.InverseTransformDirection(player.transform.position).y;
        if (yDistance < -2)
        {
            spriteRenderer.sprite = down;
        }
        else
        {
            if (yDistance > 2)
            {
                spriteRenderer.sprite = up;
            }
            else
            {
                spriteRenderer.sprite = circle;
            }
        }
    }
}
