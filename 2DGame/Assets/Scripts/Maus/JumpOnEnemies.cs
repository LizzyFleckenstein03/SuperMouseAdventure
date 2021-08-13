using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOnEnemies : MonoBehaviour
{
    EnemyScript enemyScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyScript = collision.gameObject.GetComponent<EnemyScript>();

            if(!enemyScript.spiky)
            {
                enemyScript.enemyHealth -= 1;
            }
        }
    }
}
