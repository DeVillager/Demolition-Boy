using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalBomb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player.instance.ChangeBomb(BombType.Horizontal);
        Player.instance.currentBombAmount++;
        gameObject.SetActive(false);
    }
}
