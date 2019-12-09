using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private bool legalMove;

    [SerializeField]
    public int currentBombAmount = 2;

    [SerializeField]
    GameObject[] bombPrefabs;
    Movement movement;
    GameManager gm;

    public Bomb bomb;

    private LevelInfo levelInfo;
    public int explosionLength;
    public List<ObjectColors> bombList = new List<ObjectColors>();


    void Start()
    {
        explosionLength = levelInfo.explosionLength;
        currentBombAmount = levelInfo.bombAmount;

        for (int i = 0; i < levelInfo.bombAmount; i++)
        {
            bombList.Add(ObjectColors.Normal);
        }
    }

    void Awake()
    {
        gm = GameManager.instance.GetComponent<GameManager>();
        gm.player = this;
        Invoke("ResetWalls", 0.5f);
        bomb = this.GetComponent<Bomb>();
        legalMove = true;
        movement = GetComponent<Movement>();
        levelInfo = GameObject.FindWithTag("LevelInfo").GetComponent<LevelInfo>();
    }

    void ResetWalls()
    {
        gm.wallAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            DropBomb();
        }
        else if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void DropBomb()
    {
        if (currentBombAmount > 0)
        {
            gm.bombsLeft--;
            //Instantiate(bombPrefabs[(int)bombList[bombList.Count-1]], new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), 0), bombPrefabs[(int)bombList[bombList.Count - 1]].transform.rotation);
            //Instantiate(bomb, new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), 0), Quaternion.identity);
            // bombList.RemoveAt((int)bombList.Count-1);
            bomb.Explode();
            currentBombAmount--;
        }
    }
}