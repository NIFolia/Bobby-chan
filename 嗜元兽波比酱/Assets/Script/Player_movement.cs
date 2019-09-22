using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{

    public float speed = 1f;
    public float jump_strength = 8f;

    public bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horiMove();
        jumpMove();
    }

    private void horiMove() {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * speed;
    }

    private void jumpMove() {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && isGrounded) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jump_strength), ForceMode2D.Impulse);
        }
    }
}
