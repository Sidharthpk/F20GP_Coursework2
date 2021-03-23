using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody2D player;
    public Animator anim;
    public bool inRange;
    public string npc;
    Vector2 move;

    public Vector3 jump;
    public float jumpForce = 2.0f;

    public bool isGrounded;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

// Update is called once per frame
void Update2()
    {
        move.x = Input.GetAxisRaw("Horizontal") * speed;
        anim.SetFloat("run", move.x);
        //anim.SetFloat("jump", move.y);
        if(Mathf.Sign(move.x) == 1)
        {
            if (Input.GetButtonDown("Jump"))
            {
                anim.SetFloat("jump", 0.5f);
                move.y = 0.5f;
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump"))
            {
                anim.SetFloat("jump", -0.5f);
                move.y = 0.5f;
            }
        }
        anim.SetFloat("Speed", move.sqrMagnitude);
    }

    void FixedUpdate()
    {
        // Movement
        player.MovePosition(player.position + move * speed * Time.fixedDeltaTime);
    }
}