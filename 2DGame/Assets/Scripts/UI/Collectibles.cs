using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectibles : MonoBehaviour
{
    public Text countText;
    private int cheesecount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cheese"))
        {
            collision.gameObject.SetActive(false);

            cheesecount++;

            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = cheesecount.ToString();
    }
}
