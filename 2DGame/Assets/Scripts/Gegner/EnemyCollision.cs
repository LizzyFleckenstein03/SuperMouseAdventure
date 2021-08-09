using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField]
    GameObject mouse;

    SpriteRenderer spriteRenderer;

    TrailRenderer trailRenderer;

    PowerUps powerUps;

    Health health;

    EnemyScript eS;

    private float invincibilityFrames;
    public float startInvincibilityFrames = 0.2f;
    
    private bool invulnerable = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = mouse.GetComponent<SpriteRenderer>();
        trailRenderer = mouse.GetComponent<TrailRenderer>();
        powerUps = mouse.GetComponent<PowerUps>();
        health = mouse.GetComponent<Health>();
        eS = GetComponent<EnemyScript>();
        invincibilityFrames = startInvincibilityFrames;
    }

    // Update is called once per frame
    void Update()
    {
        print(invincibilityFrames);
        print(invulnerable);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && invulnerable == false)
        {
            powerUps.mouseIsGardener = false;
            health.GetDamage(eS.enemyDamage);
            StartCoroutine ("GetInvincible");
        }
    }

    IEnumerator GetInvincible()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(7, 8, true);
        while (invincibilityFrames > 0)
        {
            invincibilityFrames -= Time.deltaTime;
            spriteRenderer.enabled = false;
            trailRenderer.enabled = false;
            yield return new WaitForSeconds(0.3f);
            spriteRenderer.enabled = true;
            trailRenderer.enabled = true;
            yield return new WaitForSeconds(0.3f);
        }
        Physics2D.IgnoreLayerCollision(7, 8, false);
        spriteRenderer.enabled = true;
        trailRenderer.enabled = true;
        invincibilityFrames = startInvincibilityFrames;
        invulnerable = false;
    }
}
