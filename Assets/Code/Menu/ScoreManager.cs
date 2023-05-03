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

        //Kakkospelin pisteääntä varten
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

            /*Scenen alussa muutetaan pisteet resursseiks ja nollataan pisteet ja sen playerpref*/
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

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game1"))
            {
                timer.AddSecond();
            }

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

        //TrainingWheels ykköspeliin:

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

