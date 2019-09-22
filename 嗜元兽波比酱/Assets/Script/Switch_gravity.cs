using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_gravity : MonoBehaviour
{
    private Rigidbody2D rb;

    private bool top;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space)) {
        //    rb.gravityScale *= -1;  
        //}
        //if (Input.GetKeyDown(KeyCode.DownArrow)) {
        //     this.Rotation();
        //}
        GravityControl();
    }

    private void Rotation() {
        if (top == false) {
            transform.eulerAngles = new Vector3(0,0,180f);
        }  else {
            transform.eulerAngles = Vector3.zero;
        } 
        top = !top;
    }

    private void GraToLeft() {
        Physics2D.gravity = new Vector2(-9.81f, 0f);
    }

    private void GraToRight() {
        Physics2D.gravity = new Vector2(9.81f, 0f);
    }

    private void GraToUp() {
        Physics2D.gravity = new Vector2(0f, 9.81f);
    }

    private void GraToDown() {
        Physics2D.gravity = new Vector2(0f, -9.81f);
    }

    private void GravityControl() {
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            GraToLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            GraToRight();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            GraToUp();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            GraToDown();
        }
    }
}
