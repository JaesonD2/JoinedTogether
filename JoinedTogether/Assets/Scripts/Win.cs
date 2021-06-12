using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public string acceptedCol = "";
    public bool active = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered trigger with " + collision.name + collision.gameObject.layer);
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && collision.gameObject.name == acceptedCol)
        {
            // here
            active = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exited Trigger with " + collision.name + collision.gameObject.layer);
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && collision.gameObject.name == acceptedCol)
        {
            // No longer here
            active = false;
        }
    }
}
