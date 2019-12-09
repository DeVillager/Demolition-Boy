﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombTextScript : MonoBehaviour
{
    Text text;
    public static int bombAmount = 5;
   
    void Start()
    {
        text = GetComponent<Text> ();
    }

    void Update()
    {
        text.text = bombAmount.ToString();
    }
}
