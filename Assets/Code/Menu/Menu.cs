using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WineCrafter
{
    public class Menu : MonoBehaviour
    {

        // method to access next scene
        public void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }


        //method to go back to main menu scene
        public void GoBackMenu()
        {
            SceneManager.LoadScene(0);
        }

        //exit the game
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
