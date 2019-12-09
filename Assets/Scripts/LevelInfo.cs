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



    // Start is called before the first frame update
    void Start()
    {  
        wallAmount = GameObject.FindGameObjectsWithTag("Wall1").Length;
    }

    // Update is called once per frame
    void Update()
    {    
    }

    public void UpdateColor(ObjectColors color)
    {
        this.objectColors = color;
        Debug.Log(color);
    }

    public int Get100()
    {
        return bombAmount;
    }
}
