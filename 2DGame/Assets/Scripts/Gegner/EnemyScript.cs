using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int enemyHealth;
    public int enemyDamage;

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth == 0)
        {
            gameObject.SetActive(false);        
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            enemyHealth--;
            Destroy(collision.gameObject);
        }
    }
}
