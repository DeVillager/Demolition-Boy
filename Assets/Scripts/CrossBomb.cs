using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBomb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player.instance.ChangeBomb(BombType.Cross);
        Player.instance.currentBombAmount++;
        gameObject.SetActive(false);
    }
}
