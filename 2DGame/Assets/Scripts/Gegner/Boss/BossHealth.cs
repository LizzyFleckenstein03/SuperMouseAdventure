using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public int bossHealth;
    public int numberOfHearts;

    public Image[] bossHearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Update is called once per frame
    void Update()
    {
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

            if(bossHealth == 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    //Bei Berührung mit der Schere oder der Maus wird die Gesundheit um 1 verringert
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            bossHealth--;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            bossHealth--;
        }
    }
}
