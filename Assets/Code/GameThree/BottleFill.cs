using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WineCrafter
{
    public class BottleFill : MonoBehaviour
    {
        private CapsuleCollider2D coll;

        // Start is called before the first frame update
        void Awake()
        {
            coll = GetComponent<CapsuleCollider2D>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {

        }
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "WineDrop")
            {

                Destroy(GameObject.FindWithTag("WineDrop"));
            }

        }
    }
}
