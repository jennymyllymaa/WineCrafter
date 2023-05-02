using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WineCrafter
{
    public class WineDropDespawner : MonoBehaviour
    {
        private BoxCollider2D col;

        // Start is called before the first frame update
        void Awake()
        {
            col = GetComponent<BoxCollider2D>();
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