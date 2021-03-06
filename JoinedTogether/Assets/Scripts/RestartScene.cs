using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with " + collision.name + collision.gameObject.layer);
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Death");
            //Restarts the level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
