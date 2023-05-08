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


        //Method that checks if falling objects hit the basket. Gives points if collided with berries, deducts points if collided with trash
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Marjat")
            {
                ASPoint.time = 0.1f;
                ASPoint.Play();
                isTriggered = true;
                Destroy(collision.gameObject);
                points = points + 1;
                ScoreManager.instance.AddPoint();

            }

            if (collision.gameObject.tag == "Roska")
            {
                ASMinus.Play();
                Handheld.Vibrate();
                isTriggered = true;
 
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
