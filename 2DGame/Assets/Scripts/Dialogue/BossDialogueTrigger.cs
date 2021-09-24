using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDialogueTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject DialogueManager;

    BossDialogue dialogue;

    void Start()
    {
        dialogue = DialogueManager.GetComponent<BossDialogue>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(dialogue.Type());
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            collision.gameObject.GetComponent<MouseController>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            FindObjectOfType<AudioManager>().Stop("flowers");
        }
    }
}