using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    bool inRange = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inRange)
            {
                GameManager.instance.OnFinish();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish_"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish_"))
        {
            inRange = false;
        }
    }
}
