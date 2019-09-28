using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{

    public float speed = 0.3f;
    public float jump_strength = 7f;
    public float jump_count = 0f;
    public float max_jump_count = 2f;

    public bool isGrounded = false;
    public bool isSecJumped = false;

    public bool isFacingRight = true;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slowMove();
        horiMove();
        jumpMove();
        check_max_jump();
    }

    private void horiMove() {
        float movingPosition = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(movingPosition, 0f, 0f);
        transform.position += movement * speed;
        if (isFacingRight == true && movingPosition > 0)
        {
            Flip();
        }
        else if (isFacingRight == false && movingPosition < 0) {
            Flip();
        }
    }

    private void jumpMove() {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && (isGrounded || !isSecJumped)) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jump_strength), ForceMode2D.Impulse);
            jump_count += 1f;
        }
    }

    private void check_max_jump() {
        if (jump_count >= max_jump_count)
        {
            isSecJumped = true;
        }
    }

    private void slowMove() {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 0.1f;
        }
        else {
            speed = 0.3f;
        }
    }

    private void Flip() {
        isFacingRight = !isFacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}
