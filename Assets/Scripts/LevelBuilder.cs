using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{

    [SerializeField]
    GameObject wall;
    public int height = 0;
    public int width = 0;
    int startHeight;
    int startWidth;

    void Start()
    {
        startHeight = -(int)Mathf.Floor(height/2);
        startWidth = -(int)Mathf.Floor(width/2);
        Debug.Log($"{startWidth} {startHeight}");
        BuildWalls();
    }

    private void BuildWalls()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (i == 0 || j == 0 || i == width - 1 || j == height - 1)
                {
                    Instantiate(wall, new Vector3(i+startWidth, -j-startHeight, 0), Quaternion.identity, gameObject.transform);
                }
            }
        }
    }
}
