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
            Vector3 spawnPos = new Vector3(groundCheck.transform.position.x, groundCheck.transform.position.y + 1, groundCheck.transform.position.z);
            Instantiate(dustEffect, spawnPos, Quaternion.identity);
        }
    }
}
