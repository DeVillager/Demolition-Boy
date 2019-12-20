using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    private List<GameObject> boxes;
    int boxAmount;
    void Start()
    {
        boxAmount = transform.childCount;
        for (int i = 0; i < boxAmount; i++)
        {
            boxes.Add(transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetBoxes()
    {
        for (int i = 0; i < boxes.Count; i++)
        {
            boxes.Add(transform.GetChild(i).gameObject);
        }
    }
}
