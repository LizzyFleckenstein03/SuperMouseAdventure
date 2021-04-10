using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissors : MonoBehaviour
{
    Rigidbody2D rb;

    // Update is called once per frame
    public void FixedUpdate()
    {
            rb.velocity = new Vector2(10, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6) {
            Destroy(gameObject);
        } else if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
