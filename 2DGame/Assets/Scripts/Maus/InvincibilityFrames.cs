using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityFrames : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    Health health;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health.invincible == true)
        {

        }
    }
}
