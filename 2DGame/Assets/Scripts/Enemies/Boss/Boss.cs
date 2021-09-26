using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [SerializeField]
    string bossName;

    [SerializeField]
    Text bossText;

    [SerializeField]
    GameObject bossTriggerObj;

    public int bossHealth;
    public int numberOfHearts;
    public bool bossfight = false;

    public Image[] bossHearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Start()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        if(bossfight)
        {
            bossText.enabled = true;
            bossText.text = bossName;
            GetComponent<FollowPlayer>().enabled = true;
        }
        else
        {
            bossText.enabled = false;
            GetComponent<FollowPlayer>().enabled = false;
        }

        if (bossHealth > numberOfHearts)
        {
            bossHealth = numberOfHearts;
        }

        for (int i = 0; i < bossHearts.Length; i++)
        {
            //Wenn i kleiner als die Gesundheit, zeige ein volles Herz an, ansonsten ein leeres
            if (i < bossHealth)
            {
                bossHearts[i].sprite = fullHeart;
            }
            else
            {
                bossHearts[i].sprite = emptyHeart;
            }

            if (i < numberOfHearts)
            {
                bossHearts[i].enabled = true;
            }
            else
            {
                bossHearts[i].enabled = false;
            }

            if(!bossfight)
            {
                bossHearts[i].enabled = false;
            }
        }

        if (bossHealth <= 0)
        {
            gameObject.SetActive(false);
            bossText.enabled = false;
            for (int i = 0; i < bossHearts.Length; i++)
            {
                bossHearts[i].enabled = false;
            }
        }
    }
}
