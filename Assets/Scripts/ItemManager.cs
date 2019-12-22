using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> items;
    public static ItemManager instance;

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
        Invoke("ResetItems", 0.5f);
    }

    public void ResetItems()
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].SetActive(true);
        }
        GameManager.instance.wallAmount = LevelInfo.instance.wallAmount;
    }
}
