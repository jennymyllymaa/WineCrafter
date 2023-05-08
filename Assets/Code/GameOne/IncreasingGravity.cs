using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace WineCrafter
{
    public class IncreasingGravity : MonoBehaviour
    {
        [SerializeField] float initialGravityScale = 10f;
        float gravityScale;
        float gravityMultiplier = 1.2f;

        // For the TrainingWheels (first 10 seconds are safer) we need scoremanager from canvas
        GameObject canvas;
        ScoreManager scoremanager;

        void Start()
        {
            //Invokes the method methodName in time seconds, then repeatedly every repeatRate seconds
            InvokeRepeating("IncreaseGravity", 10.0f, 5.0f);

            gravityScale= initialGravityScale;

            canvas = GameObject.Find("Canvas");
            scoremanager = canvas.GetComponent<ScoreManager>();

        }

        void Update()
        {
            //Multipliers increases after 50 points
            if(PlayerPrefs.GetInt("currentGameScore", 0) > 50)
            {
                gravityMultiplier = 1.6f;
            }
        }

        void IncreaseGravity()
        {
            //This method is called first time after the first 10 seconds so
            // it laso sets TrainingWheels as false

            if (scoremanager.GetTrainingWheels() == true)
            {
                scoremanager.SetTrainingWheelsToFalse();
            }
            gravityScale = gravityScale * gravityMultiplier;

        }

        public float GetGravityMultiplier()
        {
            return gravityScale;
        }

    }
 
}


