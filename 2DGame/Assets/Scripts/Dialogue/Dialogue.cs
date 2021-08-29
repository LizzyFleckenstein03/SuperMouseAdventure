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
    public int index;

    public float typingSpeed;

    void Start()
    {
        dialogueBox.SetActive(false);
        SpeechBubble.SetActive(false);
        speechBubble = SpeechBubble.GetComponent<SpeechBubble>(); 
    }

    void Update()
    {
        if (dialogueText.text == sentences[index])
        {
            continueButton.SetActive(true);
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

    public void NextSentence()
    {
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
        }
    }
}
