using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public GameObject gardenCheese;
    public SpriteRenderer mouseRenderer;
    public Sprite gardenMouse;

    public bool poweredUp;
    public bool mouseIsGardener;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GardenCheese"))
        {
            mouseIsGardener = true;
            poweredUp = true;
            collision.gameObject.SetActive(false);
        }
    }
}
