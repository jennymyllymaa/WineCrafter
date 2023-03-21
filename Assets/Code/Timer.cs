using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using WineCrafter;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public Text timerText;

    [Header("Timer Settings")]
    public float currentTime;

    [Header("Limit Settings")]
    public float timerLimit = 0;

    public bool endOfGame = false;

    GameObject spawner;
    public GameObject canvas;
    int score;

    GameObject gameOverParent;
    GameObject paneeli;


    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        score = canvas.GetComponent<ScoreManager>().GetScore();

        if ( currentTime <=0 )
        {
            currentTime = timerLimit;
            SetTimerText();
            
            
        }

        SetTimerText();

        if (currentTime == timerLimit)
        {
            endOfGame = true;

            if (score > 0)
            {
                gameOverParent = GameObject.Find("Canvas");
                paneeli = gameOverParent.transform.Find("LopetusPanel").gameObject;
                paneeli.SetActive(true);
            }

            else 
            {
                gameOverParent = GameObject.Find("Canvas");
                paneeli = gameOverParent.transform.Find("GameOverPanel").gameObject;
                paneeli.SetActive(true);
            }




            //DELETE IF TIMESCALE = 0 WORKS AND STOPS MARJAT TO SPAWN
            /*GameObject spawner = GameObject.Find("Spawner");

            if (spawner != null)
            {
                Spawner spawnerComponent = spawner.GetComponent<Spawner>();
                if (spawnerComponent == null)
                {
                    Debug.LogError($"{gameObject} is missing a component which it is dependant on!");
                }
                // this can probably be removed later when cleaning the code because this is already done with timescale
                spawner.SetActive(false);
            }*/


            Time.timeScale = 0;
        }

    }

    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0");
    }


}
