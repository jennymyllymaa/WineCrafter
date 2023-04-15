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

    private void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game2"))
        {
            
            currentTime = PlayerPrefs.GetInt("currentGameScore", 0);
            //ScoreManager.ResetPoints(); /*resetataan prefi jotta pistelasku alkaa alusta*/
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

            if (score > 0)
            {
                gameOverParent = GameObject.Find("Canvas");
                paneeli = gameOverParent.transform.Find("EndPanel").gameObject;
                paneeli.SetActive(true);

                //ASChangeLevel.Play();
            }

            else 
            {
                gameOverParent = GameObject.Find("Canvas");
                paneeli = gameOverParent.transform.Find("NEWGAMEOVERPANEL").gameObject;
                paneeli.SetActive(true);

                //ASChangeLevel.Play(); //TÄHÄN GAME OVER
            }

            Time.timeScale = 0;
        }

    }

    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0");
    }


}
