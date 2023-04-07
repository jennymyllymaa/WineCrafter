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

        public AudioSource ASMash;

        // Start is called before the first frame update
        void Start()
        {
            nuijaColl = GetComponent<BoxCollider2D>();

            fillBar = GameObject.Find("FillBarParent");

            progressBarScript = fillBar.GetComponent<ProgressBar>();

        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Bucket")
            {

                ASMash.Play();
            
                mashPoints += 1;
                wineBurst.Play();

                progressBarScript.AddPointsFill();

            }

        }
    }
}

