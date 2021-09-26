using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossDialogue : MonoBehaviour
{
    public GameObject continueButton;
    public GameObject dialogueBox;
    public GameObject SpeechBubble;
    public GameObject mouse;

    BossSpeechBubble speechBubble;

    public Text dialogueText;

    [SerializeField]
    GameObject bossObject;

    Boss boss;

    public string[] sentences;

    [HideInInspector]
    public int index;

    public float typingSpeed;

    void Start()
    {
        dialogueBox.SetActive(false);
        continueButton.SetActive(false);
        //SpeechBubble.SetActive(false);
        speechBubble = SpeechBubble.GetComponent<BossSpeechBubble>();
        boss = bossObject.GetComponent<Boss>();
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
        SpeechBubble.SetActive(true);
        speechBubble.NextSpeaker();
        foreach (char letter in sentences[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        FindObjectOfType<AudioManager>().Play("click");
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
            boss.bossfight = true;
            bossObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            mouse.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            mouse.GetComponent<MouseController>().enabled = true;
            FindObjectOfType<AudioManager>().Play("snail_fight");
        }
    }
}
