using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBird : MonoBehaviour
{
    public float speed;

    public Transform rightTurningPoint;
    public Transform leftTurningPoint;

    bool movingRight;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > leftTurningPoint.position.x)
        {
            movingRight = false;

        }
        else if (transform.position.x < rightTurningPoint.position.x)
        {
            movingRight = true;
        }

        if (movingRight)
        {
            transform.position += transform.right * (Time.deltaTime * speed);
        }
        else
        {
            transform.position -= transform.right * (Time.deltaTime * speed);
        }
    }
}
