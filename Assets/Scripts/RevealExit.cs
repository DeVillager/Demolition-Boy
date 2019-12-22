using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealExit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Exit.instance.gameObject.SetActive(true);
    }
}
