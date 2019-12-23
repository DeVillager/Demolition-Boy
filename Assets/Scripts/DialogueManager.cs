using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance = null;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Queue<string> sentences;

    public Animator animator;

    void Awake()
    {
        animator.SetBool("IsOpen", false);
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        FindObjectOfType<Player>().GetComponent<Movement>().enabled = false;
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (var sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        EventSystem.current.SetSelectedGameObject(EventSystem.current.firstSelectedGameObject);
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            FindObjectOfType<Player>().GetComponent<Movement>().enabled = true;
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            if (SoundManager.instance.efxSource.isPlaying)
            {
                if (SoundManager.instance.efxSource.clip.name != "letter")
                {
                    SoundManager.instance.PlaySingle("letter");
                }
            } else
            {
                SoundManager.instance.PlaySingle("letter");
            }
            dialogueText.text += letter;
            yield return null;
        }
    }

    private void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }




}
