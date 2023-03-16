using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WineCrafter
{
    public class WineSpawner : MonoBehaviour
    {
        [SerializeField] public GameObject wineDrop;


        private Vector3 spawnPosition;
        private CircleCollider2D col;
 

        void Awake()
        {
            col = GetComponent<CircleCollider2D>();
            Vector2 colCenter = col.bounds.center;
            spawnPosition = new Vector3(colCenter.x, colCenter.y, transform.position.z);

        }

        void Start()
        {

        }

        public void Spawn()
        {
            GameObject newDrop = new GameObject("newDrop");
            /*newDrop = wineDrop;*/

            Debug.Log("spawni aika");
            Instantiate(newDrop, spawnPosition, Quaternion.identity);


        }
    }
}
