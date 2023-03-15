using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WineCrafter
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager instance;


        public Text scoreText;
        int score = 0;

        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            scoreText.text = "x " + score.ToString();
        }


        public void AddPoint ()
        {
            score += 1;
            scoreText.text = "x " + score.ToString();

        }

        public void SubtractPoint()
        {
            score = score - 1; 
            scoreText.text = "x " + score.ToString();

        }

        public int GetScore()
        {
            return score;
        }

    }
}

