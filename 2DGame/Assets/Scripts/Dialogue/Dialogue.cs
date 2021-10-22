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

    [HideInInspector] public int index;

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
        if (dialogueText.text == dialogueTriggerer[0].stringFromFile[0].text)
        {
            continueButton.SetActive(true);
            skipButton.SetActive(true);
        }
    }

    public IEnumerator Type()
    {
        dialogueBox.SetActive(true);
        skipButton.SetActive(true);
        speechBubble.NextSpeaker();
        SpeechBubble.SetActive(true);
        /*foreach (char letter in sentences[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }*/

        //dialogueText.text = dialogueTrigger.stringFromFile[0].text;

        foreach (char letter in dialogueTriggerer[0].stringFromFile[1].text.ToCharArray())
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
        dialogueText.text = dialogueTriggerer[0].stringFromFile[0].text;
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
        dialogueText.text = dialogueTriggerer[0].stringFromFile[0].text;
    }
}