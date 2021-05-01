using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour
{
    [SerializeField]
    int Bosshealth = 12;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Bosshealth == 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Bosshealth--;
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            Bosshealth--;
        }
    }
}
