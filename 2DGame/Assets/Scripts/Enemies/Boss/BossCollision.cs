using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollision : MonoBehaviour
{
    Boss boss;

    SpriteRenderer spriteRenderer;

    public float flashingTime;
    
    [HideInInspector]
    public bool invulnerable;

    private void Start()
    {
        boss = GetComponent<Boss>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //Bei Beruehrung mit der Schere wird die Gesundheit um 1 verringert
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (boss.bossfight && !invulnerable)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                boss.bossHealth--;
                Destroy(collision.gameObject);
                invulnerable = true;
            }
        }
    }
}