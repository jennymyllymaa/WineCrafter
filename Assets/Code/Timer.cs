using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public Text timerText;

    [Header("Timer Settings")]
    public float currentTime;

    [Header("Limit Settings")]
    public float timerLimit = 0;


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

    }

    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0");
    }


}
