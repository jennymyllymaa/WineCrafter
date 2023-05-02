using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WineCrafter
{
    public class ProgressBar : MonoBehaviour
    {

        public int maximum;
        public int current;
        public int totalFilled;
        public Image mask;


        void Update()
        {
            getCurrentFill();
        }

        //Add points smoothly to the fillbar, give a point when fillbar reached full
        void getCurrentFill()
        {
            float fillAmount = (float)current / (float)maximum;
            mask.fillAmount = Mathf.Lerp(mask.fillAmount, fillAmount, Time.deltaTime * 10);

            if(current > maximum ) 
            {
                current = 0;
                totalFilled++;
                ScoreManager.instance.AddPoint();
            }
        }

        //add points to fillbar
        public void AddPointsFill()
        {
            current = current + 20;
        }
    }
}

