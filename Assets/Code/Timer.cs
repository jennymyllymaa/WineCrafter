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
    GameObject paneeli;

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
                    Debug.Log("score kunnossa");
                    gameOverParent = GameObject.Find("Canvas");
                    paneeli = gameOverParent.transform.Find("EndPanel").gameObject;
                    paneeli.SetActive(true);
                }
                else
                {
                    gameOverParent = GameObject.Find("Canvas");
                    paneeli = gameOverParent.transform.Find("NEWGAMEOVERPANEL").gameObject;
                    paneeli.SetActive(true);
                }
            }

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game2"))
            {
                if(score > 0 )
                {
                    gameOverParent = GameObject.Find("Canvas");
                    paneeli = gameOverParent.transform.Find("EndPanel").gameObject;
                    paneeli.SetActive(true);
                }
                else
                {
                    gameOverParent = GameObject.Find("Canvas");
                    paneeli = gameOverParent.transform.Find("NEWGAMEOVERPANEL").gameObject;
                    paneeli.SetActive(true);

                }

            }


            /*if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game1") && score > 0)
            {
                Debug.Log("score kunnossa");
                gameOverParent = GameObject.Find("Canvas");
                paneeli = gameOverParent.transform.Find("EndPanel").gameObject;
                paneeli.SetActive(true);
            }

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game2") && score > 0)
            {
                gameOverParent = GameObject.Find("Canvas");
                paneeli = gameOverParent.transform.Find("EndPanel").gameObject;
                paneeli.SetActive(true);
            }*/




            /*if (score > 0)
            {
                gameOverParent = GameObject.Find("Canvas");
                paneeli = gameOverParent.transform.Find("EndPanel").gameObject;
                paneeli.SetActive(true);

                /* ASChangeLevel.Play(); */ //tehdään tällekkin oma script todennäköisesti ja pois täältä.
            /*}

            else 
            {
                gameOverParent = GameObject.Find("Canvas");
                paneeli = gameOverParent.transform.Find("NEWGAMEOVERPANEL").gameObject;
                paneeli.SetActive(true);
                
                /* gameOver.Play();*/  //siirretty omaan scriptiin ja kiinnitetty game over paneeleihin.


            /*}*/

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
