using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject continueButton;
    public GameObject dialogueBox;
    public GameObject SpeechBubble;
    public GameObject mouse;

    SpeechBubble speechBubble;

    public Text dialogueText;

    public string[] sentences;
    
    [HideInInspector]
    public int index;

    public float typingSpeed;

    public bool skip;

    void Start()
    {
        dialogueBox.SetActive(false);
        continueButton.SetActive(false);
        SpeechBubble.SetActive(false);
        speechBubble = SpeechBubble.GetComponent<SpeechBubble>();
    }

    void Update()
    {
        if (dialogueText.text == sentences[index])
        {
            continueButton.SetActive(true);
        }

        if (dialogueText.text != sentences[index])
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                skip = true;
            }
            else
            {
                skip = false;
            }
        }
    }

    public IEnumerator Type()
    {
        dialogueBox.SetActive(true);
        speechBubble.NextSpeaker();
        SpeechBubble.SetActive(true);
        foreach (char letter in sentences[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void Skip()
    {
        dialogueText.text = sentences[index];
    }

    public void NextSentence()
    {
        FindObjectOfType<AudioManager>().Play("click");
        continueButton.SetActive(false);
        skip= false;

        if (index < sentences.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Type());
            speechBubble.NextSpeaker();
        }
        else
        {
            dialogueText.text = "";
            dialogueBox.SetActive(false);
            SpeechBubble.SetActive(false);
            mouse.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            mouse.GetComponent<MouseController>().enabled = true;
        }
    }
}