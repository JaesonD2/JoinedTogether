using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public List<Win> places;
    private bool won = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        won = true;
        foreach (Win win in places)
        {
            if (!win.active)
            {
                won = false;
            }
        }
        if (won)
        {
            Debug.Log("UWIN");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
