using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public static Exit instance;
    private bool isColliding = false;

    [SerializeField]
    public Sprite exitClosed;
    [SerializeField]
    public Sprite exitOpen;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        GameManager.instance.exit = this.gameObject;
        GameManager.instance.exit.SetActive(false);
        isColliding = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isColliding)
        {
            isColliding = true;
            GameManager.instance.LoadNextScene();
            //GameManager.LoadScene(GameManager.GetActiveScene().buildIndex);
        }
        else
        {
            isColliding = false;
        }
    }

}
