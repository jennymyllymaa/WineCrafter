using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WineCrafter
{
    public class Despawner : MonoBehaviour
    {
        private BoxCollider2D col;
        bool isTriggered = false;

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
                isTriggered = true;
                Destroy(GameObject.FindWithTag("Marjat"));
            }

            if (collision.gameObject.tag == "Roska")
            {
                isTriggered = true;
                Destroy(GameObject.FindWithTag("Roska"));

            }
        }

        public bool IsTriggered() 
        { 
            return isTriggered; 
        }
    }
}

