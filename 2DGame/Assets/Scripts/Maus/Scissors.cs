using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissors : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    float lifeTime;

    public void StartShoot(bool isFacingLeft, Vector2 velocity)
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        transform.localScale = new Vector3(0.4f, 0.4f, 1);

        if (isFacingLeft == true)
        {
            rb2d.velocity = new Vector2(-speed, 0) + velocity;
        }
        else
        {
            rb2d.velocity = new Vector2(speed, 0) + velocity;
        }

        Vector2 movementDirection = rb2d.velocity;
		movementDirection.Normalize();
		transform.rotation = Quaternion.LookRotation(Vector3.forward, movementDirection) * Quaternion.Euler(0, 0, 90);

        Destroy(gameObject, lifeTime);
    }
}
