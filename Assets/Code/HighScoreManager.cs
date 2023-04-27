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

                if (highScoreNumber < PlayerPrefs.GetInt("currentGameScore", 0))
                {
                    PlayerPrefs.SetInt("personalHighScore", PlayerPrefs.GetInt("currentGameScore", 0));
                    highScoreNumber = PlayerPrefs.GetInt("personalHighScore", 0);
                }

                // Muutettu pisteet niin, että tulee pelkkä pistemäärä ja highscore teksti on eri tiedostossa localizationin takia
                highScore.text = highScoreNumber.ToString();
                PlayerPrefs.SetInt("currentGameScore", 0);
            }

        }

        public void ResetHighScore()
        {
            PlayerPrefs.SetInt("personalHighScore", 0);

            // Muutettu niin että resetattu highscore tulee heti näkyviin menu paneeliin
            highScoreNumber = 0;
            highScore.text = highScoreNumber.ToString();
        }


    }
}


