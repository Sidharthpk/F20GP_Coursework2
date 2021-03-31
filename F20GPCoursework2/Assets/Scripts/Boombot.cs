using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boombot : MonoBehaviour
{

    public float speed = 3.0f;
    public bool moveRight = true;
    public Animator anim;
    public Animator anim2;
    public Transform botTrans;
    public Transform playerPos;
    public GameObject bot;
    public GameObject ex;
    public Transform wallPos;
    public GameObject wall;
    float minDistance =5.5f;
    public PlayerMovement2 movement;
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
            StartCoroutine(waitOnDeath());
        }
    }
    IEnumerator waitOnDeath()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(ex, botTrans.position, botTrans.rotation);
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            if ((wallPos.position - botTrans.position).magnitude <= 3.5f)
            {
                wall.SetActive(false);
            }
        }
        yield return new WaitForSeconds(0.65f);
        if ((playerPos.position - botTrans.position).magnitude <= minDistance)
        {
            anim2.SetBool("isDead", true);
            movement.enabled = false;
            yield return new WaitForSeconds(3);
            if (SceneManager.GetActiveScene().name == "Tutorial Scene")
            {
                SceneManager.LoadScene("Tutorial Scene");
            }
            else if (SceneManager.GetActiveScene().name == "Level1")
            {
                SceneManager.LoadScene("Level1");
            }
        }
        else
        {    
            bot.SetActive(false);
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

}
