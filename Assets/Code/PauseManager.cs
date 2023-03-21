using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game1"))
        {
            Time.timeScale = 0f;
        }

        else
        {
            Time.timeScale = 1f;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause ()
    {
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }
}
