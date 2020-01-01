using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    [SerializeField]
    private string levelName;
    [SerializeField, Range(0,50)]
    public int bombAmount;
    [SerializeField, Range(0,11)]
    public int explosionLength;
    [SerializeField]
    public ObjectColors objectColors = ObjectColors.Normal;

    [SerializeField]
    public int wallAmount;

    public static LevelInfo instance;

    public GameObject showDialogue;

    private void Awake()
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
        wallAmount = GameObject.FindGameObjectsWithTag("Wall1").Length;
        GameManager.instance.wallAmount = wallAmount;
    }

    public void UpdateColor(ObjectColors color)
    {
        this.objectColors = color;
        Debug.Log(color);
    }
}
