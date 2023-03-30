using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] List<AudioClip> audioClips;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }

    [SerializeField] private AudioSource backgroundSource;
    [SerializeField] private AudioSource effectsSource;

    public void Play(int clipIndex)
    {
        backgroundSource.clip = audioClips[clipIndex];
        backgroundSource.Play();
    }

    public void PlayOneShot(int clipIndex)
    {
        effectsSource.PlayOneShot(audioClips[clipIndex]);
    }
}
