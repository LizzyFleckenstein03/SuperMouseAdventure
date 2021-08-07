using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityFrames : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Health health;

    public bool invincible;

    public float invincibilityFramesNumber = 2;
    private float invincibilityFrames;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if(invincible == true)
        {
            invincibilityFrames = invincibilityFramesNumber;
            invincibilityFrames -= Time.deltaTime;
            if(invincibilityFrames > 0)
            {
                invincible = true;
            }
            if (invincibilityFrames == 0)
            {
                invincible = false;
            }
        }

        print(invincible);
    }
}
