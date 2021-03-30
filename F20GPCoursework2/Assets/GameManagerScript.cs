using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public PlayerMovement2 pm2;
    public GameObject dj;
    public Transform trans;
    // Update is called once per frame
    void Update()
    {
        if (pm2.doubleJumpValue == 1 && dj.activeSelf == false)
        {
            //Instantiate(dj, trans.position, trans.rotation);
            dj.SetActive(true);
        }
    }
}
