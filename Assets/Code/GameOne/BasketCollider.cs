using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WineCrafter
{
    public class BasketCollider : MonoBehaviour
    {
        private BoxCollider2D col;
        bool isTriggered = false;
        int points = 0;

        public AudioSource ASPoint;
        public AudioSource ASMinus;

        void Awake()
        {
            col = GetComponent<BoxCollider2D>();
        }


        void FixedUpdate()
        {

        }
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Marjat")
            {
                ASPoint.time = 0.1f;
                ASPoint.Play();
                isTriggered = true;
                //Destroy(GameObject.FindWithTag("Marjat"));
                Destroy(collision.gameObject);
                points = points + 1;
                ScoreManager.instance.AddPoint();

            }

            if (collision.gameObject.tag == "Roska")
            {
                ASMinus.Play();
                isTriggered = true;
                //Destroy(GameObject.FindWithTag("Roska"));
                Destroy(collision.gameObject);
                points = points - 1;
                ScoreManager.instance.SubtractPoint();

            }
        }

        public bool IsTriggered()
        {
            return isTriggered;
        }
    }
}
