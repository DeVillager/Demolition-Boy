using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Loader : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject soundManager;
    public GameObject levelManager;
    public GameObject levelBuilder;

    [SerializeField]
    private AudioClip levelMusic;

    void Awake()
    {
        if (GameManager.instance == null)
            Instantiate(gameManager);
        if (SoundManager.instance == null)
            Instantiate(soundManager);
        if (LevelManager.instance == null)
            Instantiate(levelManager);
        Instantiate(levelBuilder, Vector3.zero, Quaternion.identity);
    }

    private void Start()
    {
        if (levelMusic.name == "final")
        {
            if (SoundManager.instance.musicSource.clip != levelMusic)
            {
                SoundManager.instance.musicSource.clip = levelMusic;
                SoundManager.instance.musicSource.Play();
            }
        }
        else if (SoundManager.instance.musicSource.clip.name != "bg1")
        {
            SoundManager.instance.musicSource.clip = levelMusic;
            SoundManager.instance.musicSource.Play();
        }
    }
}
