using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    GameObject explosionPrefab;
    [SerializeField]
    LayerMask indestructibleMask;
    [SerializeField]
    LayerMask destructibleMask;

    [SerializeField, Range (0, 20)]
    int explosionLength = 3;

    [SerializeField, Range(0, 0.1f)]
    float explosionExpandingTime = 0.02f;

    private float timer;
    private float fuseTime = 0.1f;

    Vector3 position;

    [SerializeField]
    ObjectColors bombColor = ObjectColors.Normal;

    private GameObject player;


    void Start()
    {
        // player = GameObject.FindWithTag("Player");
        // position = player.transform.position;
        // Invoke("Explode", fuseTime);
        // explosionLength = player.GetComponent<Player>().explosionLength;
    }


    void Update()
    {
        // timer += Time.deltaTime;
    }

    public void Explode()
    {
        //Center explosion sprite switch and instantiate
        player = Player.instance.gameObject;
        position = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), 0);

        GameObject centerFire = Instantiate(explosionPrefab, position, Quaternion.identity);
        explosionLength = player.GetComponent<Player>().explosionLength;

        BombType btype = Player.instance.bombType;
        if (btype == BombType.Normal)
        {
            StartCoroutine(CreateExplosions(Vector3.up));
            StartCoroutine(CreateExplosions(Vector3.right));
            StartCoroutine(CreateExplosions(Vector3.down));
            StartCoroutine(CreateExplosions(Vector3.left));
        }
        else if (btype == BombType.Horizontal)
        {
            explosionLength = 9;
            StartCoroutine(CreateExplosions(Vector3.right));
            StartCoroutine(CreateExplosions(Vector3.left));
        }
        else if (btype == BombType.Vertical)
        {
            explosionLength = 9;
            StartCoroutine(CreateExplosions(Vector3.up));
            StartCoroutine(CreateExplosions(Vector3.down));
        }
        else if (btype == BombType.Cross)
        {
            explosionLength = 9;
            StartCoroutine(CreateExplosions(Vector3.up));
            StartCoroutine(CreateExplosions(Vector3.right));
            StartCoroutine(CreateExplosions(Vector3.down));
            StartCoroutine(CreateExplosions(Vector3.left));
        }
        Player.instance.bombType = BombType.Normal;
    }

    private IEnumerator CreateExplosions(Vector3 direction)
    {
        GameObject explosion;

        for (int i = 1; i < explosionLength; i++)
        {
            RaycastHit2D hit;

            hit = Physics2D.Raycast(position, direction, i, indestructibleMask);

            if (!hit.collider)
            { 
                explosion = Instantiate(explosionPrefab, position + (i * direction), explosionPrefab.transform.rotation);

                // Sprite switch and direction check

                if(direction == Vector3.up || direction == Vector3.down)
                {
                    explosion.GetComponent<Fire>().isVertical = true;

                    if (explosionLength == i + 1)
                    {
                        if(direction == Vector3.up)
                        {
                            explosion.GetComponent<Fire>().isUp = true;
                        }
                        else if(direction == Vector3.down)
                        {
                            explosion.GetComponent<Fire>().isDown = true;
                        }
                    }
                }
                if(direction == Vector3.left || direction == Vector3.right)
                {
                    explosion.GetComponent<Fire>().isHorizontal = true;

                    if (explosionLength == i + 1)
                    {
                        if (direction == Vector3.left)
                        {
                            explosion.GetComponent<Fire>().isLeft = true;
                        }
                        else if (direction == Vector3.right)
                        {
                            explosion.GetComponent<Fire>().isRight = true;
                        }
                    }
                }
                if (explosionLength == i + 1)

                if (explosion.GetComponent<BoxCollider2D>().IsTouchingLayers(destructibleMask))
                {
                    break;
                }
            }
            else
            {
                break;
            }
            yield return new WaitForSeconds(explosionExpandingTime);
        }
        
    }
}

public enum BombType
{
    Normal,
    Vertical,
    Horizontal,
    Cross
}
