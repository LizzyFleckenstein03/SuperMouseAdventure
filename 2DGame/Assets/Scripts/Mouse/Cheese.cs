using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cheese : MonoBehaviour
{
    public Text countText;
    
    [HideInInspector]
    public int cheesecount;

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

            FindObjectOfType<AudioManager>().Play("cheese_plop");

            collision.gameObject.SetActive(false);
        }
    }

    public void SetCountText()
    {
        countText.text = cheesecount.ToString();
    }
}
