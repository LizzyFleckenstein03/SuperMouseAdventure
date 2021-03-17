//Mit diesem Script kann man die Maus steuern.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MouseMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool isGrounded;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;
        
        //Hier wird der Rigidbody initialisiert
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        //Hier ist der Code für das Springen
        if(isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        } 
        else if(Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
 
    }

    void FixedUpdate() 
    {
        //Hier wird ein Kreis unter der Maus erzeugt, der prüft, ob die Maus den Boden berührt
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkRadius, whatIsGround);

        //Wenn a und d oder Pfeiltaste links und rechts gedrückt werden, ist der Wert von moveInput -1 oder 1;
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
}
