using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WineCrafter
{
    public class WineSpawner : MonoBehaviour
    {
        [SerializeField] public GameObject wineDrop;
        [SerializeField] private int amountOfTries = 10;

        private int usedTries = 0;
        private Vector3 spawnPosition;
        private CircleCollider2D col;

        public bool outOfTries = false;
 

        void Awake()
        {
            col = GetComponent<CircleCollider2D>();
            Vector2 colCenter = col.bounds.center;
            spawnPosition = new Vector3(colCenter.x, colCenter.y, transform.position.z);

        }

        public void Spawn()
        {
            if (usedTries < amountOfTries)
            {
                Debug.Log("spawni aika");
                Instantiate(wineDrop, spawnPosition, Quaternion.identity);
                usedTries++;
                Debug.Log("käytetty: " + usedTries);
            }
            else
            {
                outOfTries= true;
            }

        }
        public int GetAmount()
        {
            return (amountOfTries - usedTries);
        }

        public bool GetTries()
        {
            return outOfTries;
        }
    }
}
