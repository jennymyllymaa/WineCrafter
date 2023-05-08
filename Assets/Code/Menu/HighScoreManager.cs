using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace WineCrafter
{
    public class HighScoreManager : MonoBehaviour
    {
        public Text highScore;
        private int highScoreNumber = 0;

        void Start()
        {

            //Display highscore in score and menu scenes
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Score") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Menu"))
            {
                highScoreNumber = PlayerPrefs.GetInt("personalHighScore", 0);
                highScore.text = highScoreNumber.ToString();

            }

            //Only set highscore if player reached score scene
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Score"))
            {
                if (highScoreNumber < PlayerPrefs.GetInt("currentGameScore", 0))
                {
                    PlayerPrefs.SetInt("personalHighScore", PlayerPrefs.GetInt("currentGameScore", 0));
                    highScoreNumber = PlayerPrefs.GetInt("personalHighScore", 0);

                    highScore.text = highScoreNumber.ToString();
                }
            }

        }

        //Resets highscore and sets highscore text to zero in highscore panel
        public void ResetHighScore()
        {
            PlayerPrefs.SetInt("personalHighScore", 0);

            highScoreNumber = 0;
            highScore.text = highScoreNumber.ToString();
        }


    }
}


