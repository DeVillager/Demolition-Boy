using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private bool legalMove;
    private bool isFading = true;

    [SerializeField]
    public int currentBombAmount = 2;

    [SerializeField]
    GameObject[] bombPrefabs;

    public BombType bombType;

    Movement movement;
    GameManager gm;

    public Bomb bomb;

    private LevelInfo levelInfo;
    public int explosionLength;
    public List<ObjectColors> bombList = new List<ObjectColors>();

    [SerializeField]
    public GameObject introDialogue;

    public static Player instance;
    private SpriteRenderer spriteRenderer;

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
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gm = GameManager.instance.GetComponent<GameManager>();
        gm.player = this;
        Invoke("ResetWalls", 0.5f);
        bomb = this.GetComponent<Bomb>();
        legalMove = true;
        movement = GetComponent<Movement>();
        levelInfo = GameObject.FindWithTag("LevelInfo").GetComponent<LevelInfo>();

        if (introDialogue != null)
        {
            GetComponent<Movement>().enabled = false;
            Invoke("TriggerMyDialogue", 2);
        }
        explosionLength = levelInfo.explosionLength;
        currentBombAmount = levelInfo.bombAmount;

        for (int i = 0; i < levelInfo.bombAmount; i++)
        {
            bombList.Add(ObjectColors.Normal);
        }
    }

    public void Fade()
    {
        isFading = true;
    }

    public void ChangeBomb(BombType type)
    {
        bombType = type;
        GameManager.instance.bombText.text = $"{type}";
    }

    private void TriggerMyDialogue()
    {
        introDialogue.GetComponent<DialogueTrigger>().TriggerDialogue();
    }

    void ResetWalls()
    {
        gm.wallAmount = 1;
    }


    public void DropBomb()
    {
        if (currentBombAmount > 0)
        {
            gm.bombsLeft--;
            bomb.Explode();
            currentBombAmount--;
        } else
        {
            SoundManager.instance.PlaySingle("nobomb2");
        }
    }

    public void ResetBombs()
    {
        currentBombAmount = levelInfo.bombAmount;
    }

}