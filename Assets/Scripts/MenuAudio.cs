using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    private void Start()
    {
        AudioManager.instance.Play(0);
    }
}
