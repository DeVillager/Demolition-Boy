using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wall : MonoBehaviour
{
    [SerializeField]
    private WallType WallProperty = WallType.Normal;
    [SerializeField, Range(1, 5)]
    private int hitpoints;
    [SerializeField]
    public ObjectColors wallColor;
    Player player;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        if (WallProperty == WallType.HitpointWall)
        {
            GetComponentInChildren<TextMeshProUGUI>().text = hitpoints.ToString();
        }
        //Invoke("AddWall", 0.5f);
        // gm.wallAmount++;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddWall()
    {
        GameManager.instance.wallAmount++;
        Debug.Log("walls " + GameManager.instance.wallAmount);
    }

    public void DamageWall(int wallDamage)
    {
        if (hitpoints > 1 && WallProperty == WallType.HitpointWall)
        {
            hitpoints -= wallDamage;
            GetComponentInChildren<TextMeshProUGUI>().text = hitpoints.ToString();
        }
        else if (hitpoints <= 1)
        {
            GameManager.instance.DecreaseWalls();
            Debug.Log($"Walls left: {GameManager.instance.wallAmount}");
            gameObject.SetActive(false);
        }
    }

    public enum WallType
    {
        Normal,
        HitpointWall,
        ColorWall
    }
}

public enum ObjectColors
{
    Normal,
    Blue,
    Orange,
    Red,
}
