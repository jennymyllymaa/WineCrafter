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

            scoreText.text = "x " + score.ToString();

                
        }

        private void Update()
        {
            /*if (score != PlayerPrefs.GetInt("currentGameScore", 0))
            {*/
            SavePoints();
            /*}*/
        }


        public void AddPoint ()
        {
            score += 1;

            /*UUSI*/
            PlayerPrefs.SetInt("currentGameScore", score);
            //PlayerPrefs.Save();

            scoreText.text = "x " + score.ToString();




        }

        public void SubtractPoint()
        {
            score = score - 1;

            /*UUSI*/
            PlayerPrefs.SetInt("currentGameScore", score);
            //PlayerPrefs.Save();


            scoreText.text = "x " + score.ToString();


        }

        public void SavePoints()
        {
            PlayerPrefs.SetInt("currentGameScore", score);
            PlayerPrefs.Save();
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

