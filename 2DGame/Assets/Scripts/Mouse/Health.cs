using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int mouseHealth;
    public int numberOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Update is called once per frame
    void Update()
    {
        if (mouseHealth > numberOfHearts)
        {
            mouseHealth = numberOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            //Wenn i kleiner als die Gesundheit, zeige ein volles Herz an, ansonsten ein leeres
            if (i < mouseHealth)
            {
                hearts[i].sprite = fullHeart;
            } else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numberOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void DealDamage(int enemyDamage)
    {
        //Bei Beruehrung mit einem Gegner wird die Gesundheit um 1 verringert
        mouseHealth -= enemyDamage;
    }
}
