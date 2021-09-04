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

    void Start()
    {
        SetCheeseCount(0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cheese"))
        {
            SetCheeseCount(cheesecount + 1);

            FindObjectOfType<AudioManager>().Play("cheese_plop");

            collision.gameObject.SetActive(false);
        }
    }

    public void SetCheeseCount(int count)
    {
		cheesecount = count;
		countText.text = cheesecount.ToString();
	}
}
