using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UninstallExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitOnDeath());
    }

    IEnumerator waitOnDeath()
    {
        yield return new WaitForSeconds(0.65f);
        Destroy(gameObject);
    }
}
