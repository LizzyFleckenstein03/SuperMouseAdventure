using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cheese : MonoBehaviour
{
    public Text countText;
    private int cheesecount;

    void Start()
    {
        countText.text = "0";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cheese"))
        {
            cheesecount++;

            SetCountText();

            collision.gameObject.SetActive(false);
        }
    }

    void SetCountText()
    {
        countText.text = cheesecount.ToString();
    }
}
