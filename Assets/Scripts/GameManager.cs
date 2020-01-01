using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    public static GameManager instance = null;
    public int level = 1;
    public float levelStartDelay = 2f;

    private Text levelText;
    public Text bombText;

    private GameObject levelImage;

    [SerializeField]
    private GameObject splashScreen;

    public Player player;
    public bool doingSetup;
    public int wallAmount;
    public bool exitInitialized = false;
    public bool exitRevealed = false;

    [SerializeField]
    public int bombsLeft;
    public GameObject exit;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        wallAmount = 0;
        level = SceneManager.GetActiveScene().buildIndex;

        splashScreen = Instantiate(splashScreen);
        bombText = splashScreen.transform.Find("BombText").GetComponent<Text>();
        levelText = splashScreen.transform.GetChild(2).GetChild(0).GetComponent<Text>();
        levelImage = splashScreen.transform.GetChild(2).gameObject;
        player = Player.instance;
        InitGame();
    }

    public void Init2()
    {
        doingSetup = true;
        exitRevealed = false;
        Invoke("HideLevelImage", 0.5f);
    }

    private void Start()
    {
        Debug.Log("Loaded scene: " + level);
        Debug.Log("Total scenes: " + SceneManager.sceneCountInBuildSettings);
        Invoke("UpdateWalls", 1f);
    }

    private void UpdateWalls()
    {
        wallAmount = LevelInfo.instance.wallAmount;
    }

    public void DecreaseWalls()
    {
        wallAmount--;
    }

    public void LoadNextScene()
    {
        Debug.Log("Loaded scene " + level);
        level++;
        InitGame();
        SceneManager.LoadScene(level);
    }

    public void RestartLevel()
    {
        Debug.Log("Restarted scene " + level);
        InitGame();
        SceneManager.LoadScene(level);
    }


    public void LoadScene(int index)
    {
        InitGame();
        SceneManager.LoadScene(index);
    }


    public void InitGame()
    {
        doingSetup = true;
        levelText.text = "Level " + level;
        levelImage.SetActive(true);
        Invoke("HideLevelImage", levelStartDelay);
    }

    private void HideLevelImage()
    {
        levelImage.SetActive(false);
        doingSetup = false;
    }

    public void GameOver()
    {
        levelText.text = "You died.";
        levelImage.SetActive(true);
    }

    void FixedUpdate()
    {
        bombsLeft = player.currentBombAmount;
        BombType btype = Player.instance.bombType;
        if (btype == BombType.Normal)
        {
            bombText.text = $"Bombs left: {bombsLeft}";
        }
        else if (btype != BombType.Normal)
        {
            bombText.text = $"{btype} bomb";
        }
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (wallAmount <= 0 && !doingSetup && !exit.activeInHierarchy)
            {
                //exitRevealed = true;
                if (LevelInfo.instance.showDialogue != null)
                {
                    LevelInfo.instance.showDialogue.SetActive(true);
                }
                SoundManager.instance.PlaySingle("reveal");
                if (level == SceneManager.sceneCountInBuildSettings - 2)
                {
                    SoundManager.instance.PlayMusic("ending");
                }
                exit.gameObject.SetActive(true);
            }
        }
    }

    public int GetActiveScene()
    {
        return level;
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // here you can use scene.buildIndex or scene.name to check which scene was loaded
        if (scene.name == "Ending")
        {
            // Destroy the gameobject this script is attached to
            Destroy(gameObject);
        }
    }
}