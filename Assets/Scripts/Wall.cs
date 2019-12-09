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
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        if (WallProperty == WallType.HitpointWall)
        {
            GetComponentInChildren<TextMeshProUGUI>().text = hitpoints.ToString();
        }
        Invoke("AddWall", 0.5f);
        // gm.wallAmount++;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddWall()
    {
        gm.wallAmount++;
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
            gm.DecreaseWalls();
            Debug.Log($"Walls left: {gm.wallAmount}");
            Destroy(gameObject);
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
