using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

namespace WineCrafter
{
    public class ShowCurrentPoints : MonoBehaviour
    {

        public Text scoreText;
        private int score;
        
        // Show the currents points at start
        void Start()
        {
            score = PlayerPrefs.GetInt("currentGameScore", 0);
            scoreText.text = "x " + score.ToString();

        }
    }
}

