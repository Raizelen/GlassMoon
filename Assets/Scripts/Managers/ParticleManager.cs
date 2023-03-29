using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] List<ParticleSystem> particleEffects;

    public void PlayEffect(int index)
    {
        if (index >= particleEffects.Count || index < 0) return;
        particleEffects[index].Play();
    }
}
