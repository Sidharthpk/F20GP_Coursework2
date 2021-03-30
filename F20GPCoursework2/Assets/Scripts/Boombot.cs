using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boombot : MonoBehaviour
{
    private bool m_FacingRight = true;
    public float speed = 3.0f;
    public bool moveRight = true;
    public Animator anim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            if(moveRight)
            {
                moveRight = false;
            }
            else
            {
                moveRight = true;
            }
        }

        if(collision.gameObject.CompareTag("Player"))
        {
            speed = 0f;
            anim.SetBool("isAlarmed", true);
        }
    }

    private void Update()
    {
        if (moveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0,0);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0,0);
            transform.localScale = new Vector2(-1, 1);
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
