using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WineCrafter
{
    public class BottleDespawner : MonoBehaviour
    {
        private BoxCollider2D coll;

        // Start is called before the first frame update
        void Awake()
        {
            coll = GetComponent<BoxCollider2D>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {

        }
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "EmptyBottle")
            {

                Destroy(GameObject.FindWithTag("EmptyBottle"));
            }

            if (collision.gameObject.tag == "FullBottle")
            {

                Destroy(GameObject.FindWithTag("FullBottle"));

            }
        }
    }
}