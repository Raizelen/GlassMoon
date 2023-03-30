using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraUIManager : MonoBehaviour
{
    public static CameraUIManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
        GetComponent<Canvas>().worldCamera = Camera.main;
    }

    [SerializeField] private GameObject messagePrefab;

    public GameObject ShowMessage(Vector3 position, string message)
    {
        GameObject messageObj = Instantiate(messagePrefab, position, Quaternion.identity, transform);
        messageObj.GetComponent<TMP_Text>().text = message;
        return messageObj;
    }

    public void ShowMessage(Vector3 position, string message, float duration)
    {
        GameObject messageObj = Instantiate(messagePrefab, position, Quaternion.identity, transform);
        messageObj.GetComponent<TMP_Text>().text = message;
        Destroy(messageObj, duration);
    }

    public void HideMessage(GameObject messageObj)
    {
        Destroy(messageObj);
    }
}
