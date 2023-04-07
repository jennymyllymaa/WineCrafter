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

        // Start is called before the first frame update
        void Awake()
        {
            col = GetComponent<BoxCollider2D>();

        }


        // Update is called once per frame
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
                Destroy(GameObject.FindWithTag("Marjat"));
                points = points + 1;
                ScoreManager.instance.AddPoint();


            }

            if (collision.gameObject.tag == "Roska")
            {
                ASMinus.Play();
                isTriggered = true;
                Destroy(GameObject.FindWithTag("Roska"));
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
