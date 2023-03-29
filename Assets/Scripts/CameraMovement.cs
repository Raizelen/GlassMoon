using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 1f, -10f);
    private float smoothTime = .25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;
    [SerializeField] private Rigidbody2D rb;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        rb = player.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        try
        {
            Vector3 targetPosition = target.position + offset + new Vector3(rb.velocity.x / 5, rb.velocity.y / 5, 0);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        } catch
        {
            enabled = false;
        }
    }
}
