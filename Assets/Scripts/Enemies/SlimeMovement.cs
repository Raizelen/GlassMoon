using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    [SerializeField] int direction = 1;
    [SerializeField] float speed = 2f;
    [SerializeField] float maxX, minX;

    void Update()
    {
        transform.Translate(Vector3.right * direction * speed);
        if (transform.position.x > maxX)
        {
            direction = -1;
        }
        if (transform.position.x < minX)
        {
            direction = 1;
        }
    }
}
