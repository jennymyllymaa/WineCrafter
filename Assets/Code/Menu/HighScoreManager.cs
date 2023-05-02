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

            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Score") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Menu"))
            {
                highScoreNumber = PlayerPrefs.GetInt("personalHighScore", 0);

                // Muutettu pisteet niin, ett‰ tulee pelkk‰ pistem‰‰r‰ ja highscore teksti on eri tiedostossa localizationin takia
                highScore.text = highScoreNumber.ToString();

            }

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

        public void ResetHighScore()
        {
            PlayerPrefs.SetInt("personalHighScore", 0);

            // Muutettu niin ett‰ resetattu highscore tulee heti n‰kyviin menu paneeliin
            highScoreNumber = 0;
            highScore.text = highScoreNumber.ToString();
        }


    }
}


