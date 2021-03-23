using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator anim;
    float horizontalMoveRight = 0f;
    public float speed = 40f;
    bool jump = false;
    bool dash = false;
    bool dashStatus = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMoveRight = Input.GetAxisRaw("Horizontal") * speed;
        anim.SetFloat("run", Mathf.Abs(horizontalMoveRight));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            anim.SetBool("isJumping", true);
        }
        if (Input.GetKeyDown("e") && dashStatus == false)
        {
            dash = true;
            dashStatus = true;
            anim.SetBool("isJumping", false);
            anim.SetBool("isDashing", true);
            
        }
    }

    public void OnLanding()
    {
        anim.SetBool("isJumping", false);
        anim.SetBool("isDashing", false);
        anim.SetBool("isFalling", false);
        controller.countJump = 2;
        dashStatus = false;

    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMoveRight * Time.fixedDeltaTime, false, jump, dash);
        jump = false;
        dash = false;

    }
}
