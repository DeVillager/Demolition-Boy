using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigBomb : MonoBehaviour
{
    [SerializeField]
    private Image flashImage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.instance.PlaySingle("item");
        Player.instance.explosionLength++;
        gameObject.SetActive(false);
        flashImage.GetComponent<Flash>().CameraFlash();
    }
}
