using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject continueButton;
    public GameObject skipButton;
    public GameObject dialogueBox;
    public GameObject SpeechBubble;
    public GameObject mouse;

    SpeechBubble speechBubble;

    public Text dialogueText;

    int sffIndex = 0;
    int dtIndex = 0;

    public float typingSpeed;

    [SerializeField] DialogueTrigger[] dialogueTriggerer;

    void Start()
    {
        dialogueBox.SetActive(false);
        continueButton.SetActive(false);
        skipButton.SetActive(false);
        SpeechBubble.SetActive(false);
        speechBubble = SpeechBubble.GetComponent<SpeechBubble>();
    }

    void Update()
    {
        if (dialogueText.text == dialogueTriggerer[dtIndex].stringFromFile[sffIndex].text)
        {
            continueButton.SetActive(true);
            skipButton.SetActive(true);
        } 
        else 
        {
            continueButton.SetActive(false);
        }
    }

    public IEnumerator Type()
    {
        dialogueBox.SetActive(true);
        skipButton.SetActive(true);
        speechBubble.NextSpeaker();
        SpeechBubble.SetActive(true);
        dialogueText.text = "";

        foreach (char letter in dialogueTriggerer[dtIndex].stringFromFile[sffIndex].text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        /*FindObjectOfType<AudioManager>().Play("click");
        continueButton.SetActive(false);

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
        }*/
        if(index < dialogueTriggerer[dtIndex].stringFromFile.Length) {
                    index += 1;
        }
        StartCoroutine(Type());
    }

    public void Skip()
    {
        /*StopCoroutine(Type());
        FindObjectOfType<AudioManager>().Play("click");
        skipButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            dialogueText.text = "";
            dialogueText.text = sentences[index];
            speechBubble.NextSpeaker();
        }
        else
        {
            dialogueText.text = "";
            dialogueBox.SetActive(false);
            SpeechBubble.SetActive(false);
            mouse.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            mouse.GetComponent<MouseController>().enabled = true;
        }*/
        dialogueText.text = dialogueTriggerer[index].stringFromFile[index].text;
    }
}