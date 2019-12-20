using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    IEnumerator m_MoveCoroutine;

    [SerializeField]
    float m_SpeedFactor;

    int xDir;
    int yDir;
    bool legalMove;
    Vector2 direction;

    [SerializeField]
    LayerMask solid;

    private bool acceptingInput = true;

    private Animator anim;
    private bool walking;
    private bool shouldIdle;
    public bool exploding = false;
    private Vector2 lastMove;

    private Vector2 startPosition;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        startPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !exploding)
        {
            exploding = true;
            anim.SetBool("Exploding", exploding);
            GetComponent<Player>().DropBomb();
        }
        else if (Input.GetKeyDown("r"))
        {
            ResetStage();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            exploding = false;
            anim.SetBool("Exploding", exploding);
        }

        // if character is already moving, just return
        if (m_MoveCoroutine != null)
            return;
        if (yDir != 0 && xDir == 0)
        {
            xDir = (int)Input.GetAxisRaw("Horizontal");
            yDir = 0;
        }
        else if (xDir != 0 && yDir == 0)
        {
            yDir = (int)Input.GetAxisRaw("Vertical");
            xDir = 0;
        }
        else
        {
            xDir = (int)Input.GetAxisRaw("Horizontal");
            yDir = (int)Input.GetAxisRaw("Vertical");
        }

        if (xDir != 0 && yDir != 0)
        {
            yDir = 0;
        }

        if (!acceptingInput)
        {
            xDir = 0;
            yDir = 0;
        }

        direction = new Vector2(xDir, yDir);
        legalMove = AttemptMove();

        if (!walking)
        {
            shouldIdle = true;
        }
        //if (lastMove != direction && legalMove)
        if (lastMove != direction && legalMove)
        {
            walking = false;
            anim.SetBool("Walking", !shouldIdle);
        }

        //if (direction != Vector2.zero && legalMove)
        if (direction != Vector2.zero && legalMove)
        {
            // start moving your character
            m_MoveCoroutine = Move(direction);
            acceptingInput = false;
            StartCoroutine(m_MoveCoroutine);
        }
    }

    private void ResetStage()
    {
        transform.position = startPosition;
        GetComponent<Player>().ResetBombs();
        FindObjectOfType<BoxManager>().ResetBoxes();
    }

    private bool AttemptMove()
    {
        if (GameManager.instance.doingSetup)
        {
            return false;
        }
        bool canMove = true;
        this.GetComponent<BoxCollider2D>().enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1f, solid.value);
        if (hit.collider != null)
        {
            canMove = false;
            //Debug.Log("Exit found.");
        }
        this.GetComponent<BoxCollider2D>().enabled = true;
        return canMove;
    }

    IEnumerator Move(Vector2 direction)
    {
        // SoundManager.Instance.PlaySFX("Walk");
        // Lerp(Vector2 a, Vector2 b, float t);
        Vector2 orgPos = transform.position; // original position
        Vector2 newPos = orgPos + direction; // new position after move is done
        float t = 0; // placeholder to check if we're on the right spot
        walking = true;
        shouldIdle = false;
        anim.SetBool("Walking", !shouldIdle);
        anim.SetFloat("MoveX", direction.x);
        anim.SetFloat("MoveY", direction.y);
        while (t < 1.0f) // loop while player is not in the right spot
        {
            if (t > 0.9f)
            {
                acceptingInput = true;
            }

            transform.position = Vector2.Lerp(orgPos, newPos, (t += Time.deltaTime * m_SpeedFactor));
            // calculate and set new position based on the deltaTime's value
            // wait for new frame
            yield return new WaitForEndOfFrame();
        }
        acceptingInput = true;
        anim.SetFloat("LastMoveX", direction.x);
        anim.SetFloat("LastMoveY", direction.y);
        lastMove = direction;
        // stop coroutine
        StopCoroutine(m_MoveCoroutine);
        // get rid of the reference to enable further movements
        m_MoveCoroutine = null;
    }
}

