using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject DialogueManager;

    Dialogue dialogue;

    void Start()
    {
        dialogue = DialogueManager.GetComponent<Dialogue>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(dialogue.Type());
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            collision.gameObject.GetComponent<MouseController>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}