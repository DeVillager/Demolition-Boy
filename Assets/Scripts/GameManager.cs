using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    public static GameManager instance = null;
    private int level = 1;
    public float levelStartDelay = 2f;

    private Text levelText;
    public Text bombText;

    private GameObject levelImage;

    [SerializeField]
    private GameObject splashScreen;

    public Player player;
    public bool doingSetup;
    public int wallAmount = 1;

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
        levelText = splashScreen.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>();
        levelImage = splashScreen.transform.GetChild(1).gameObject;
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        InitGame();
    }

    private void Start()
    {
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
        else if (btype == BombType.Vertical || btype == BombType.Horizontal)
        {
            bombText.text = $"{btype} bomb";
        }

        if (wallAmount <= 0 && !doingSetup)
        {
            exit.gameObject.SetActive(true);
        }
    }

    public int GetActiveScene()
    {
        return level;
    }
}