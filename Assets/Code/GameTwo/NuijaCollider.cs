using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WineCrafter
{
    public class NuijaCollider : MonoBehaviour
    {
        private BoxCollider2D nuijaColl;
        private int mashPoints = 0;
        public ParticleSystem wineBurst;

        public GameObject fillBar;
        public ProgressBar progressBarScript;



        // Start is called before the first frame update
        void Start()
        {
            nuijaColl = GetComponent<BoxCollider2D>();

            fillBar = GameObject.Find("FillBarParent");

            progressBarScript = fillBar.GetComponent<ProgressBar>();

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Bucket")
            {

                
                mashPoints += 1;
                wineBurst.Play();



                /*UUSI*/
                //ScoreManager.instance.AddPoint();

                progressBarScript.AddPointsFill();


                /*if (progressBar != null)
                {
                    ProgressBar.AddPointsFill();
                }*/


                /*Debug.Log(mashPoints);*/
            }

        }
    }
}

