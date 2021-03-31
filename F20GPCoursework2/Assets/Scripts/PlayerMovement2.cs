using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement2 : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator anim;
    public GameObject dj;
    public GameObject on;
    public GameObject off;
    public GameObject portal;
    float horizontalMoveRight = 0f;
    public float speed = 40f;
    bool jump = false;
    bool dash = false;
    bool dashStatus = false;
    bool glide = false;
    public int doubleJumpValue = 1; 

    // Update is called once per frame
    void Update()
    {
        horizontalMoveRight = Input.GetAxisRaw("Horizontal") * speed;
        if (controller.m_Grounded == true)
        {
            anim.SetFloat("run", Mathf.Abs(horizontalMoveRight));
        }

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
        if (Input.GetKey(KeyCode.Space) && controller.Falling == true)
        {
            glide = true;
            anim.SetFloat("run", 0f);
            anim.SetBool("isFalling", true);
        }
        else
        {
            glide = false;
        }
    }

    public void OnLanding()
    {
        anim.SetBool("isJumping", false);
        anim.SetBool("isDashing", false);
        anim.SetBool("isFalling", false);
        controller.countJump = doubleJumpValue;
        dashStatus = false;
        glide = false;

    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMoveRight * Time.fixedDeltaTime, false, jump, dash, glide);
        jump = false;
        dash = false;

    }

    public void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Jump"))
        {
            doubleJumpValue = 2;
            //Destroy(dj);
            dj.SetActive(false);
        }
        else if(hitInfo.gameObject.CompareTag("Switch"))
        {
            if(off.activeSelf == true)
            {
                off.SetActive(false);
                on.SetActive(true);
                portal.SetActive(true);
            }

        }
        else if(hitInfo.gameObject.CompareTag("Portal"))
        {
            if (SceneManager.GetActiveScene().name == "Tutorial Scene")
            {
                SceneManager.LoadScene("Level1");
            }
            else if (SceneManager.GetActiveScene().name == "Level1")
            {
                SceneManager.LoadScene("Start Menu");
            }
        }
    }

}
