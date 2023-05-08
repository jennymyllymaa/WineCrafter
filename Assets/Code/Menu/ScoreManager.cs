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

        Timer timer;

        private bool trainingWheelsOn = true;

        private int subractablePoint = 1;

        //For the second games bar
        public AudioSource barSound;

        private void Awake()
        {
            instance = this;
        }


        void Start()
        {

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game1"))
            {
                timer = GameObject.Find("TimerManager").GetComponent<Timer>();
            }

            //At the start of a scene convert points into resources and set points and playerpref to zero
            //Each scene has a bit of variaty in how the points convert

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game2"))
            {
                LoadPoints();
                resourcePoints = score / 2;
                score = 0;
            }

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game3"))
            {
                LoadPoints();
                resourcePoints = score;
                score = 0;
            }

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Score"))
            {
                LoadPoints();
            }

            scoreText.text = "x " + score.ToString();

                
        }

        private void Update()
        {
            SavePoints();
        }


        public void AddPoint ()
        {
            score += 1;
           
            PlayerPrefs.SetInt("currentGameScore", score);

            //In the first game points also affect timer
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game1"))
            {
                timer.AddSecond();
            }

            //In the second game a sound for the filled bar
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game2"))
            {
                barSound.Play();
            }

            scoreText.text = "x " + score.ToString();

        }

        public void SubtractPoint()
        {

            score = score - subractablePoint;

            
            PlayerPrefs.SetInt("currentGameScore", score);

            //In the first game points also affect timer
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game1"))
            {
                timer.SubtractSecond(subractablePoint);
            }

            scoreText.text = "x " + score.ToString();

        }

        public void SavePoints()
        {
            PlayerPrefs.SetInt("currentGameScore", score);
            PlayerPrefs.Save();
        }

        public void LoadPoints()
        {
            score = PlayerPrefs.GetInt("currentGameScore", 0);
        }

        public static void ResetPoints()
        {
            PlayerPrefs.SetInt("currentGameScore", 0);
        }

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

        //TrainingWheels bool for the first game:
        //So that the game is easier for the first 10 seconds
        // to ensure that the game doesnt end immediately.

        public bool GetTrainingWheels()
        {
            return trainingWheelsOn;
        }

        public void SetTrainingWheelsToFalse()
        {
            trainingWheelsOn = false;
            subractablePoint= 5;
        }

    }
}

