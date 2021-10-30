using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOnEnemies : MonoBehaviour
{
    EnemyScript enemyScript;

    [SerializeField]
    GameObject mouse;

    public float knockBackValue = 30;

    public bool stunned = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !stunned)
        {
            enemyScript = collision.gameObject.GetComponent<EnemyScript>();

            if(!enemyScript.spiky)
            {
            enemyScript.enemyHealth -= 1;
            }

            Vector2 mousePos = mouse.transform.position;
            Vector2 enemyPos = collision.gameObject.transform.position;

            Vector2 knockback = mousePos - enemyPos;
            knockback.Normalize();
            knockback *= 36;

            mouse.GetComponent<Rigidbody2D>().velocity += knockback;
        }
    }
}
