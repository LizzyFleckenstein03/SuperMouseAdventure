using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingSound : MonoBehaviour
{
    [SerializeField]
    GameObject groundCheck;

    [SerializeField]
    GameObject dustEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("landung");
            Instantiate(dustEffect, groundCheck.transform.position, Quaternion.identity);
        }
    }
}
