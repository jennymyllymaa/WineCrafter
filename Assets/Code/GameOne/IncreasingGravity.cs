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

        //TrainingWheelsiä varten haetaan canvasista ScoreManager script
        GameObject canvas;
        ScoreManager scoremanager;

        void Start()
        {
            //Invokes the method methodName in time seconds, then repeatedly every repeatRate seconds
            //InvokeRepeating("IncreaseGravity", 8.0f, 5.0f);
            InvokeRepeating("IncreaseGravity", 10.0f, 5.0f);

            //jotta se ei ole nolla ennen ekaa repeatiä
            gravityScale= initialGravityScale;

            canvas = GameObject.Find("Canvas");
            scoremanager = canvas.GetComponent<ScoreManager>();

        }

        void Update()
        {
            if(PlayerPrefs.GetInt("currentGameScore", 0) > 50)
            {
                gravityMultiplier = 1.6f;
            }
        }

        void IncreaseGravity()
        {
            if (scoremanager.GetTrainingWheels() == true)
            {
                scoremanager.SetTrainingWheelsToFalse();
                Debug.Log("Training wheels off!");
            }
            gravityScale = gravityScale * gravityMultiplier;


        }

        public float GetGravityMultiplier()
        {
            return gravityScale;
        }


    }
 
}


