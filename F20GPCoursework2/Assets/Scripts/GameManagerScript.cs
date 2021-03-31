using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public PlayerMovement2 pm2;
    public GameObject dj;
    public Transform trans;
    public GameObject bot;
    public Animator anim;
    public Boombot boom;
    bool spawning = false;
    // Update is called once per frame
    void Update()
    {
        if (pm2.doubleJumpValue == 1 && dj.activeSelf == false)
        {
            //Instantiate(dj, trans.position, trans.rotation);
            dj.SetActive(true);
        }
        if (bot.activeSelf == false && spawning == false)
        {
            spawning = true;
            StartCoroutine(respawn());
        }
    }


    IEnumerator respawn()
    {
        yield return new WaitForSeconds(7.5f);
        boom.speed = 3f;
        anim.SetBool("isAlarmed", false);
        bot.SetActive(true);
        spawning = false;
    }
}
