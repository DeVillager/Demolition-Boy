// Mutes-Unmutes the sound from this object each time the user presses space.
using UnityEngine;
using System.Collections;

public class MuteAudio : MonoBehaviour
{
    [SerializeField]
    private AudioSource efxSource;    
    [SerializeField]
    private AudioSource musicSource;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            efxSource.mute = !efxSource.mute;
            musicSource.mute = !musicSource.mute;
    }
}