using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cheese : MonoBehaviour
{
    public Text countText;

    [HideInInspector]
    public int cheesecount;

    public bool collected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cheese"))
        {
            cheesecount++;

            countText.text = cheesecount.ToString();

            FindObjectOfType<AudioManager>().Play("cheese_plop");

            collision.gameObject.SetActive(false);
        }
    }
}
