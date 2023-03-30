using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitAfterSeconds : MonoBehaviour
{
    [SerializeField] private float timer = 8f;
    void Start()
    {
        StartCoroutine(WaitAndQuit());
    }

    private IEnumerator WaitAndQuit()
    {
        yield return new WaitForSeconds(timer);
        Application.Quit(0);
    }
}
