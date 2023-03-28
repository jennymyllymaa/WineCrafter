using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WineCrafter
{
    public class NuijaCollider : MonoBehaviour
    {
        private BoxCollider2D nuijaColl;
        private int mashPoints = 0;
        public ParticleSystem wineBurst;

        // Start is called before the first frame update
        void Start()
        {
            nuijaColl = GetComponent<BoxCollider2D>();

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

                // ScoreManager.instance.AddPoint();
                Debug.Log(mashPoints);
            }

        }
    }
}

