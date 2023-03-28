using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public PlayerController player;
    public float smoothening = .1f;

    private Transform target;
    void Start()
    {
        target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetLocation = new Vector3(target.position.x + (player.facingRight ? 1 : -1), target.position.y, -10);
        transform.position = Vector3.MoveTowards(transform.position, targetLocation, smoothening);
    }
}
