using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float speed = .6f;

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, speed));
    }
}
