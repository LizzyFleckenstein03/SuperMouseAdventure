 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float bumperForce;

    public GameObject mouse;
    Rigidbody2D rb;

    private void Start()
    {
        rb = mouse.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            rb.velocity = Vector2.up * bumperForce; 
        }
    }
}
