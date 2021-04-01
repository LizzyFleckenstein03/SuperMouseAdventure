using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public GameObject gardenCheese;
    public SpriteRenderer mouseRenderer;
    public Sprite gardenMouse;
    Object scissorBullet;

    public bool mouseIsGardener;

    // Start is called before the first frame update
    void Start()
    {
        scissorBullet = Resources.Load("schere");
    }

    // Update is called once per frame
    void Update()
    {
        if(mouseIsGardener == true)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                GameObject scissor = (GameObject)Instantiate(scissorBullet);
                scissor.transform.position = new Vector3(transform.position.x + 10f, transform.position.y, transform.position.z);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GardenCheese"))
        {
            mouseRenderer.sprite = gardenMouse;
            mouseIsGardener = true;
            collision.gameObject.SetActive(false);
        }
    }
}
