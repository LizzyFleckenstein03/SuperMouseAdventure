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

    BossTrigger bossTrigger;

    public int bossHealth;
    public int numberOfHearts;

    public Image[] bossHearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Start is called before the first frame update
    void Start()
    {
        bossTrigger = bossTriggerObj.GetComponent<BossTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bossTrigger.bossFight == true)
        {
            bossText.enabled = true;
            bossText.text = bossName;
        } else
        {
            bossText.enabled = false;
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

            if(bossTrigger.bossFight == false)
            {
                bossHearts[i].enabled = false;
            }
        }

        if (bossHealth == 0)
        {
            gameObject.SetActive(false);
            bossText.enabled = false;
            for (int i = 0; i < bossHearts.Length; i++)
            {
                bossHearts[i].enabled = false;
            }
        }
    }

    //Bei Beruehrung mit der Schere oder der Maus wird die Gesundheit um 1 verringert
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(bossTrigger.bossFight == true)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                bossHealth--;
                Destroy(collision.gameObject);
            }
        }
    }
}
