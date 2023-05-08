using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseManager : MonoBehaviour
{
    //At the start check if the first game is the active scene and set game to pause 
    // because the first game is the only game that starts with a panel active.
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

    //Method that pauses the game
    public void Pause ()
    {
        Time.timeScale = 0f;
    }

    //Method that will resume the game
    public void Resume()
    {
        Time.timeScale = 1f;
    }
}
