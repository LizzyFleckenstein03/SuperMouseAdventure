using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    float mass;
    Vector3 gravity;
    public float gravityScale;
    public float jumpForce;
    private float moveInput;

    [HideInInspector]
    public bool isGrounded;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        gravity = new Vector3(0, gravityScale, 0);
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        
        if(Input.GetButtonDown("Jump"))
        {
            transform.position = new Vector3(transform.position.x, jumpForce, 0);
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkRadius, whatIsGround);

        if (!isGrounded)
        {
            transform.position -= gravity;
        }

        transform.position += new Vector3(moveInput * speed, 0, 0);
    }
}
