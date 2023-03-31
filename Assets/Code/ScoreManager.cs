using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace WineCrafter
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager instance;


        public Text scoreText;
        int score = 0;
        int resourcePoints = 0;

        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            /*UUSI*/ /*Scenen alussa muutetaan pisteet resursseiks ja nollataan pisteet ja sen playerpref*/
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game2"))
            {
                LoadPoints();
                resourcePoints = score;
                Debug.Log("Resurssi: " + resourcePoints);
                score = 0;
                /*ei resetata prefi‰ viel‰ t‰‰ll‰ koska timer tarvii sit‰*/
                Debug.Log("Pisteet: " + score);

            }

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game3"))
            {
                LoadPoints();
                resourcePoints = score;
                Debug.Log("Resurssi: " + resourcePoints);
                score = 0;
                Debug.Log("Pisteet: " + score);
            }

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Score"))
            {
                LoadPoints();

            }

            Debug.Log(PlayerPrefs.GetInt("currentGameScore", 0));


            /*if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Game2"))
            {*/
            scoreText.text = "x " + score.ToString();
            /*}*/
                
        }


        public void AddPoint ()
        {
            score += 1;

            /*UUSI*/
            PlayerPrefs.SetInt("currentGameScore", score);
            PlayerPrefs.Save();

            /*if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Game2"))
            {*/
                scoreText.text = "x " + score.ToString();

            /*}*/


        }

        public void SubtractPoint()
        {
            score = score - 1;

            /*UUSI*/
            PlayerPrefs.SetInt("currentGameScore", score);
            PlayerPrefs.Save();

            /*if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Game2"))
            {
                scoreText.text = "x " + score.ToString();
            }*/

        }

        /*UUSI*/
        public void LoadPoints()
        {
            score = PlayerPrefs.GetInt("currentGameScore", 0);
        }

        /*UUSI*/
        public static void ResetPoints()
        {
            PlayerPrefs.SetInt("currentGameScore", 0);
        }

        /*UUSI*/
        public int GetResourcePoints()
        {
            return resourcePoints;
        }

        public int GetScore()
        {
            return score;
        }

        public int GetTries()
        {
            return score;
        }

    }
}

