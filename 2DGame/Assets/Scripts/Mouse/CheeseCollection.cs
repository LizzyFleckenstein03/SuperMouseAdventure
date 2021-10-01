using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheeseCollection : MonoBehaviour
{
    public Text countText;

    [HideInInspector]
    public int cheesecount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cheese"))
        {
            cheesecount++;

            countText.text = cheesecount.ToString();

            FindObjectOfType<AudioManager>().Play("cheese_plop");

            Destroy(collision.gameObject);
        }
    }
}