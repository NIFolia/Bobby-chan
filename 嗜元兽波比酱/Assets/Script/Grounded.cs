using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{

    GameObject Player;

    public string ground;
    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
    
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        ground = collision.collider.tag;
        if (collision.collider.tag == "Untagged") {
            Player.GetComponent<Player_movement>().isGrounded = true;
            Player.GetComponent<Player_movement>().isSecJumped = false;
            Player.GetComponent<Player_movement>().jump_count = 0f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        ground = collision.collider.tag;
        if (collision.collider.tag == "Untagged")
        {
            Player.GetComponent<Player_movement>().isGrounded = false;
        }
    }
}
