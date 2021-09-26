using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    GameObject mouse;

    SpriteRenderer spriteRenderer;

    TrailRenderer trailRenderer;

    PowerUps powerUps;

    Health health;

    EnemyScript eS;

    public float flashingTime = 0.3f;

    private bool invulnerable = false;

    // Start is called before the first frame update
    void Start()
    {
        mouse = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = mouse.GetComponent<SpriteRenderer>();
        trailRenderer = mouse.GetComponent<TrailRenderer>();
        powerUps = mouse.GetComponent<PowerUps>();
        health = mouse.GetComponent<Health>();
        eS = GetComponent<EnemyScript>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !invulnerable)
        {
            powerUps.mouseIsGardener = false;
            health.DealDamage(eS.enemyDamage);

            Vector2 mousePos = collision.gameObject.GetComponent<Transform>().position;
            Vector2 enemyPos = transform.position;

            Vector2 knockback = mousePos - enemyPos;
            knockback.Normalize();
            knockback *= eS.enemyDamage * 36;

            collision.gameObject.GetComponent<Rigidbody2D>().velocity += knockback;

            FindObjectOfType<AudioManager>().Play("drsh");
            StartCoroutine ("GetInvincible");
        }
    }

    IEnumerator GetInvincible()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(7, 8, true);
        for (int i = 0; i < 4; i++)
        {
            spriteRenderer.enabled = false;
            trailRenderer.enabled = false;
            yield return new WaitForSeconds(flashingTime);
            spriteRenderer.enabled = true;
            trailRenderer.enabled = true;
            yield return new WaitForSeconds(flashingTime);
        }
        Physics2D.IgnoreLayerCollision(7, 8, false);
        spriteRenderer.enabled = true;
        trailRenderer.enabled = true;
        invulnerable = false;
    }
}
