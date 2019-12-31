using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip menumusic;
    [SerializeField]
    private GameLevels gameLevels;

    private void Start()
    {
        if (SoundManager.instance != null)
        {
            SoundManager.instance.musicSource.clip = menumusic;
            SoundManager.instance.musicSource.Play();
        }
        //Invoke("AddFirstLevel", 0.5f);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SelectFirstLevel()
    {
        //Debug.Log(firstLevelButton.name + "joo");
        //EventSystem.current.SetSelectedGameObject(firstLevelButton);
        EventSystem.current.SetSelectedGameObject(gameLevels.firstButton);
    }

    public void AddFirstLevel()
    {
        //firstLevelButton = GameObject.FindGameObjectWithTag("Content").transform.GetChild(0).gameObject;
    }

}
