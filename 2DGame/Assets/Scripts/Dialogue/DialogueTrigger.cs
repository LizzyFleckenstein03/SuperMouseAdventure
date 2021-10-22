using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] GameObject DialogueManager;

    Dialogue dialogue;

    public TextAsset[] stringFromFile;

    void Start()
    {
        dialogue = DialogueManager.GetComponent<Dialogue>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            StartCoroutine(dialogue.Type());
        }
    }
}