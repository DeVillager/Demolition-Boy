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

    private GameObject firstLevelButton;

    private void Start()
    {
        SoundManager.instance.musicSource.clip = menumusic;
        SoundManager.instance.musicSource.Play();
        Invoke("AddFirstLevel", 0.2f);
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
        Debug.Log(firstLevelButton.name + "joo");
        EventSystem.current.SetSelectedGameObject(firstLevelButton);
    }

    public void AddFirstLevel()
    {
        firstLevelButton = GameObject.FindGameObjectWithTag("Content").transform.GetChild(0).gameObject;
    }

}
