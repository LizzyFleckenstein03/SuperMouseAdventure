using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingSound : MonoBehaviour
{
    [SerializeField]
    GameObject groundCheck;

    [SerializeField]
    GameObject dustEffect;

    private void OnCollisionEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("landung");
            Instantiate(dustEffect, groundCheck.transform.position, Quaternion.identity);
        }
    }
}
