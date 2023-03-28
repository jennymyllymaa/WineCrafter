using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WineCrafter
{
    public class Menu : MonoBehaviour
    {

        public void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void GoBack()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        //method to go from third game to main menu
        public void GoBackMenu()
        {
            SceneManager.LoadScene(0);
        }

        //temporary method to move to the third game from game one
        public void GoToThirdGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }



        public void QuitGame()
        {
            Debug.Log("QUIT!");
            Application.Quit();
        }
    }
}
