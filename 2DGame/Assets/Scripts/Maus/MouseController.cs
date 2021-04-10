//Mit diesem Script kann man die Maus steuern.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MouseController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput;

    private bool isGrounded;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    PowerUps powerUps;

    Object scissorBullet;

    public bool isFacingLeft;
    
    private Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;
        
        //Hier wird der Rigidbody initialisiert
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animation>();

        scissorBullet = Resources.Load("schere");
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
            FindObjectOfType<AudioManager>().Play("sprung");
        } 
        else if(Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            anim.Play("secondJump");
        }

        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isFacingLeft = true;
        }
        else if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isFacingLeft = false;
        }

        if (powerUps.mouseIsGardener == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject scissor = (GameObject)Instantiate(scissorBullet);
                scissor.transform.position = new Vector3(transform.position.x + 10f, transform.position.y, transform.position.z);
            }
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
