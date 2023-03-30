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
            CameraUIManager.instance.ShowMessage(collision.transform.position + Vector3.up * 4, "Press E to advance", 4f);
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
