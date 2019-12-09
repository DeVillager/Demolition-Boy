using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collect : MonoBehaviour
{
    private bool isColliding = false;
    GameManager gm;
    LevelInfo levelInfo;
    [SerializeField]
    ObjectColors objectColors = ObjectColors.Normal;
    [SerializeField]
    Player player;

    void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        isColliding = false;
        levelInfo = GameObject.FindWithTag("LevelInfo").GetComponent<LevelInfo>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isColliding)
        {
            isColliding = true;
            Debug.Log("Bomb found" + isColliding);
            player.bombList.Add(objectColors);
            Destroy(gameObject);
        }
    }
}
