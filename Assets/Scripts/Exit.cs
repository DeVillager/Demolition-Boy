using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public static Exit instance;
    private bool isColliding = false;

    //[SerializeField]
    //public Sprite exitClosed;
    //[SerializeField]
    //public Sprite exitOpen;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        GameManager.instance.exit = this.gameObject;
    
        gameObject.SetActive(false);
        GameManager.instance.exitInitialized = true;
        //GameManager.instance.exit.SetActive(false);
        isColliding = false;
    }

    void HideExit()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isColliding)
        {
            if (!SoundManager.instance.efxSource.isPlaying)
            {
                SoundManager.instance.PlaySingle("stairs");
            }
            isColliding = true;
            LevelManager.instance.levelPoints[GameManager.instance.level] = 1;
            SaveSystem.SaveGameData(LevelManager.instance);
            GameManager.instance.LoadNextScene();
            //Player.instance.Fade();
            //Invoke("NextLevel", 0.5f);
            //GameManager.LoadScene(GameManager.GetActiveScene().buildIndex);
        }
        else
        {
            isColliding = false;
        }
    }

    void NextLevel()
    {
        GameManager.instance.LoadNextScene();
    }

}
