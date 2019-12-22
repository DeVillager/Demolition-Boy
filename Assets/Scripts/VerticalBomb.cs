using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalBomb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player.instance.ChangeBomb(BombType.Vertical);
        Player.instance.currentBombAmount++;
        gameObject.SetActive(false);
    }
}
