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

    public float invincibilityFrames;

    private Color startSpriteColor;
    private Color startTrailColor;
    Color color;
    
    private bool invulnerable = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = mouse.GetComponent<SpriteRenderer>();
        trailRenderer = mouse.GetComponent<TrailRenderer>();
        powerUps = mouse.GetComponent<PowerUps>();
        health = mouse.GetComponent<Health>();
        eS = GetComponent<EnemyScript>();

        startSpriteColor = spriteRenderer.material.color;
        startTrailColor = trailRenderer.material.color;

    }

    // Update is called once per frame
    void Update()
    {
        
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
        color.a = 0.5f;
        spriteRenderer.material.color = color;
        trailRenderer.material.color = color;
        yield return new WaitForSeconds(invincibilityFrames);
        Physics2D.IgnoreLayerCollision(7, 8, false);
        spriteRenderer.material.color = startSpriteColor;
        trailRenderer.material.color = startTrailColor;
        invulnerable = false;
    }
}
