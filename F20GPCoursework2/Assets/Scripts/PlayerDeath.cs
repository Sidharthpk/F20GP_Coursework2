using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public Animator anim;
    public PlayerMovement2 movement;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
       if (hitInfo.gameObject.CompareTag("Kill"))
        {
            StartCoroutine(waitOnDeath());
        }
       

        IEnumerator waitOnDeath()
        {
            anim.SetBool("isDead", true);
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
    }

}
