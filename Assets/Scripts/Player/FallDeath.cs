using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDeath : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FallDeath"))
        {
            if (CompareTag("Player"))
            {
                Debug.Log("Player died");
            }
            Destroy(gameObject);
        }
    }
}
