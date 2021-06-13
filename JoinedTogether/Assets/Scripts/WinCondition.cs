using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public Animator transition;
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
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //play animation
        transition.SetTrigger("Start");
        //wait
        yield return new WaitForSeconds(1);

        //load
        SceneManager.LoadScene(levelIndex);
    }
}
