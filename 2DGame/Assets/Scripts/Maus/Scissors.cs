using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissors : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    float lifeTime = 10;

    public void StartShoot(bool isFacingLeft)
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        if(isFacingLeft == true)
        {
            rb2d.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector3(-0.4f, 0.4f, 1);
        }
        else
        {
            rb2d.velocity = new Vector2(speed, 0);
            transform.localScale = new Vector3(0.4f, 0.4f, 1);
        }

        Destroy(gameObject, lifeTime);
    }
}
