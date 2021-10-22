using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubble : MonoBehaviour
{
    [SerializeField]
    GameObject dialogueManager;

    Dialogue dialogue;

    public Transform[] speakers;

    void Start()
    {
        dialogue = dialogueManager.GetComponent<Dialogue>();
    }

    public void NextSpeaker()
    {
        transform.position = speakers[0].position;
    }
}
