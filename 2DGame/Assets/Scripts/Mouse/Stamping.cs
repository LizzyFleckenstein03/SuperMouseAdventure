using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Stamping : MonoBehaviour
{
    MouseController mouseController;
    Rigidbody2D rb;

    [SerializeField]
    private float stampingSpeed = 40;

    private bool isStamping = false;

    // Start is called before the first frame update
    void Start()
    {
        mouseController = GetComponent<MouseController>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!mouseController.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                isStamping = true;
                rb.velocity = Vector2.down * stampingSpeed;
            }
        }
        else
        {
            isStamping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stamp") && isStamping)
        {
            collision.gameObject.SetActive(false);
        }
    }
}
