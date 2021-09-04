using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpeechBubble : MonoBehaviour
{
    [SerializeField]
    GameObject dialogueManager;

    BossDialogue dialogue;

    public Transform[] speakers;

    void Start()
    {
        dialogue = dialogueManager.GetComponent<BossDialogue>();
    }

    public void NextSpeaker()
    {
        transform.position = speakers[dialogue.index].position;
    }
}