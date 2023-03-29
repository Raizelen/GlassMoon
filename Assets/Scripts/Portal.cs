using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Transform destination;

    public Transform GetDestination()
    {
        return destination;
    }

}
