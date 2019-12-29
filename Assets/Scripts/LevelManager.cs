using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance = null;
    public int[] levelPoints = new int[20];
    public string title = "bruh";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("two levelmanagers!");
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        GameData data = SaveSystem.LoadGameData();
        if (data != null)
        {
            instance.levelPoints = data.levelPoints;
            instance.title = data.title;
        }
    }
}