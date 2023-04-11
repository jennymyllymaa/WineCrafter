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

            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Score"))
            {
                highScoreNumber = PlayerPrefs.GetInt("personalHighScore", 0);

                if (highScoreNumber < PlayerPrefs.GetInt("currentGameScore", 0))
                {
                    PlayerPrefs.SetInt("personalHighScore", PlayerPrefs.GetInt("currentGameScore", 0));
                    highScoreNumber = PlayerPrefs.GetInt("personalHighScore", 0);
                }

                highScore.text = "Highscore: " + highScoreNumber;
                PlayerPrefs.SetInt("currentGameScore", 0);
            }

        }

        public void ResetHighScore()
        {
            PlayerPrefs.SetInt("personalHighScore", 0);
        }


    }
}


