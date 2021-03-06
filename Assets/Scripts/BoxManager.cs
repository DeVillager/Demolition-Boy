﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> boxes;
    public static BoxManager instance;

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
        Invoke("ResetBoxes", 0.5f);
        //ResetBoxes();
    }

    public void ResetBoxes()
    {
        for (int i = 0; i < boxes.Count; i++)
        {
            boxes[i].SetActive(true);
        }
        GameManager.instance.wallAmount = LevelInfo.instance.wallAmount;
    }
}
