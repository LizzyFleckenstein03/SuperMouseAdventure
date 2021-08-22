using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    public bool isGolden;

    Health health;

    public GameObject mouse;

    // Start is called before the first frame update
    void Start()
    {
        health = mouse.GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(isGolden == true)
            {
                health.mouseHealth = 5;
                gameObject.SetActive(false);
            }
            else
            {
                health.mouseHealth++;
                gameObject.SetActive(false);
            }
        }
    }
}
