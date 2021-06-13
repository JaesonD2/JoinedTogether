using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{

    public Animator transition;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Quit());
    }

    IEnumerator Quit()
    {
        //play animation
        transition.SetTrigger("Start");
        //wait
        yield return new WaitForSeconds(1);

        //load
        Debug.Log("Quitting");
        Application.Quit();
    }
}
