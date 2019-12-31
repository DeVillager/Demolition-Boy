using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField]
    private float startDelay = 0;
    private float time = 0;

    public Dialogue dialogue;
    private bool hasTriggered = false;


    public void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasTriggered && collision.gameObject.tag == "Player")
        {
            hasTriggered = true;
            TriggerDialogue();
        }
    }


}
