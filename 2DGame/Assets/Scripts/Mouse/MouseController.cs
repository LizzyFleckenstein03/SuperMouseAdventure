//Mit diesem Script kann man die Maus steuern.
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float jumpTimeCounter;
    public float jumptime;
    private bool isJumping;
    private float moveInput;

    public bool isGrounded;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    PowerUps powerUps;

    public bool isFacingLeft;

    private bool isShooting;

    [SerializeField]
    GameObject bullet;
    [SerializeField]
    Transform bulletSpawnPos;
    [SerializeField]
    private float shootDelay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        //Hier wird der Rigidbody initialisiert
        rb = GetComponent<Rigidbody2D>();

        powerUps = GetComponent<PowerUps>();
    }

    // Update is called once per frame
    void Update()
    {
		if (isGrounded == true && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            jumpTimeCounter = jumptime;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetButton("Jump") && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
                FindObjectOfType<AudioManager>().Play("sprung");
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
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
            if (Input.GetButtonDown("Fire1") && ! isShooting)
            {
                isShooting = true;

                GameObject b = Instantiate(bullet);
                b.GetComponent<Scissors>().StartShoot(isFacingLeft, rb.velocity);
                b.transform.position = bulletSpawnPos.transform.position;

                Invoke("ResetShoot", shootDelay);
            }
        }

        moveInput = Input.GetAxisRaw("Horizontal");
    }

    bool HasReachedTV(float acceleration)
    {
		if (acceleration < 0)
		{
			if (rb.velocity.x <= -speed)
				return true;
		}
		else if (acceleration > 0)
		{
			if (rb.velocity.x >= speed)
				return true;
		}

		return false;
	}

    void FixedUpdate()
    {
		 //Hier wird ein Kreis unter der Maus erzeugt, der prueft, ob die Maus den Boden beruehrt
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkRadius, whatIsGround);

		//Wenn a und d oder Pfeiltaste links und rechts gedrueckt werden, ist der Wert von moveInput -1 oder 1;

		float acceleration = speed;

		if (moveInput != 0)
		{
			acceleration *= moveInput * 4;
		}
		else if (isGrounded)
		{
			acceleration *= -Math.Sign(rb.velocity.x) * 16;
		}
		else
		{
			acceleration = 0;
		}

		if (! HasReachedTV(acceleration))
		{
			int oldSign = Math.Sign(rb.velocity.x);
			rb.velocity += new Vector2(acceleration * Time.fixedDeltaTime, 0);

			if (HasReachedTV(acceleration))
				rb.velocity = new Vector2(Math.Sign(rb.velocity.x) * speed, rb.velocity.y);
			if (oldSign == -Math.Sign(rb.velocity.x))
				rb.velocity = new Vector2(0, rb.velocity.y);
		}
    }

    void ResetShoot()
    {
        isShooting = false;
    }
}