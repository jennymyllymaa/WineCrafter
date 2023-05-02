using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    GameObject panel;

    public AudioSource ASChangeLevel;

    //for animation control
    public GameObject uiTimer;

    private void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game2"))
        {
            
            currentTime = PlayerPrefs.GetInt("currentGameScore", 0) / 2;
        }

    }

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

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game1"))
            {
                if(score > 4)
                {
                    gameOverParent = GameObject.Find("Canvas");
                    panel = gameOverParent.transform.Find("EndPanel").gameObject;
                    panel.SetActive(true);
                }
                else
                {
                    gameOverParent = GameObject.Find("Canvas");
                    panel = gameOverParent.transform.Find("NEWGAMEOVERPANEL").gameObject;
                    panel.SetActive(true);
                }
            }

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game2"))
            {
                if(score > 0 )
                {
                    gameOverParent = GameObject.Find("Canvas");
                    panel = gameOverParent.transform.Find("EndPanel").gameObject;
                    panel.SetActive(true);
                }
                else
                {
                    gameOverParent = GameObject.Find("Canvas");
                    panel = gameOverParent.transform.Find("NEWGAMEOVERPANEL").gameObject;
                    panel.SetActive(true);

                }

            }

            Time.timeScale = 0;
        }

    }

    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0");
    }

    public void AddSecond()
    {
        currentTime++;
    }

    public void SubtractSecond(int amount)
    {
        currentTime = currentTime - amount;
    }


}
