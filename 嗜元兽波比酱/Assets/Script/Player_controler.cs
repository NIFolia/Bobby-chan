using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_controler : MonoBehaviour
{


    public float speed;
    public float jumpForce;

    public float moveInput;

    public Rigidbody2D rb;

    public bool facingRight = true;


    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;


    public int extraJumps;
    public int extraJumpsValue;

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();

    }


    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius,whatIsGround);



        moveInput = Input.GetAxis("Horizontal");
        Debug.Log(moveInput);
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == true && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == false && moveInput < 0) {
            Flip();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isGrounded == true) {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps -= 1;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true) {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x = -1;
        transform.localScale = Scaler;
    }
}
