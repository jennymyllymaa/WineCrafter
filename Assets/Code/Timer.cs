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

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

        if ( currentTime <=0 )
        {
            currentTime = timerLimit;
            SetTimerText();
        }

        SetTimerText();

        if (currentTime == timerLimit)
        {
            endOfGame = true;
            GameObject gameOverParent = GameObject.Find("LoppuRuutu");
            GameObject teksti = gameOverParent.transform.Find("teksti").gameObject;
            teksti.SetActive(true);
            GameObject spawner = GameObject.Find("Spawner");

            if (spawner != null)
            {
                Spawner spawnerComponent = spawner.GetComponent<Spawner>();
                if (spawnerComponent == null)
                {
                    Debug.LogError($"{gameObject} is missing a component which it is dependant on!");
                }
                spawner.SetActive(false);
            }
            Time.timeScale = 0;
        }

    }

    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0");
    }


}
