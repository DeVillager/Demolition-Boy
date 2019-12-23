using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Loader : MonoBehaviour
{
    public GameObject gameManager;            //GameManager prefab to instantiate.
    public GameObject levelBuilder;

    [SerializeField]
    private AudioClip levelMusic;

    void Awake()
    {
        if (GameManager.instance == null)
            Instantiate(gameManager);
        Instantiate(levelBuilder, Vector3.zero, Quaternion.identity);

        //if (SoundManager.instance == null)

        //    //Instantiate SoundManager prefab
        //    Instantiate(soundManager);
    }

    private void Start()
    {
        if (SoundManager.instance.musicSource.clip.name != "bg1")
        {
            SoundManager.instance.musicSource.clip = levelMusic;
            SoundManager.instance.musicSource.Play();

        }
    }
}
