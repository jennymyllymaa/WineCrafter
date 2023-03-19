using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace WineCrafter
{
    public class Attempts : MonoBehaviour
    {
        /*public Text amountText;*/
        private WineSpawner wineSpawner;

        // Start is called before the first frame update
        void Start()
        {
            /*amountText.text = "Wine left: ";*/
            this.wineSpawner = GetComponent<WineSpawner>();
        }

        // Update is called once per frame
        void Update()
        {
            /*amountText.text = "x " + wineSpawner.GetAmount().ToString();*/

            if(wineSpawner.GetTries() == true) 
            {
                Debug.Log("meni nolliin");
            }
        }
    }
}
