 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    private float springForce;

    MouseController mouseCon;

    private bool onBumper;
    public Transform groundcheck;
    public LayerMask whatIsBumper;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mouseCon = GetComponent<MouseController>();
    }

    private void FixedUpdate()
    {
        onBumper = Physics2D.OverlapCircle(groundcheck.position, mouseCon.checkRadius, whatIsBumper);

        if(onBumper == true)
        {
            rb.velocity = Vector2.up * springForce;
        }
    }
}
