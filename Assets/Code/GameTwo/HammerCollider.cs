using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WineCrafter
{
    public class HammerCollider : MonoBehaviour
    {
        private BoxCollider2D hammerColl;
        private int mashPoints = 0;
        private ProgressBar progressBarScript;
        public ParticleSystem wineBurst;
        public GameObject fillBar;
        public AudioSource ASMash;

        // Start is called before the first frame update
        void Start()
        {
            hammerColl = GetComponent<BoxCollider2D>();

            fillBar = GameObject.Find("FillBarParent");

            progressBarScript = fillBar.GetComponent<ProgressBar>();

        }

        //if hammer collides with bucket, trigger sound and Fillbar points.
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

