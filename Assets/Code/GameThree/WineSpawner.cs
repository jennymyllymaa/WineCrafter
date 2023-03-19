using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

namespace WineCrafter
{
    public class WineSpawner : MonoBehaviour
    {
        [SerializeField] public GameObject wineDrop;
        [SerializeField] private int amountOfTries = 10;

        // these two are used for the ui score text
        public Text triesText;
        private int triesScore = 0;


        private int usedTries = 0;
        private Vector3 spawnPosition;
        private CircleCollider2D col;

        public bool outOfTries = false;


        //start called only to make UI text appear right in the beginning
        private void Start()
        {
            triesScore = amountOfTries;
            triesText.text = "x " + triesScore.ToString();
        }

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
                SubtractTries();
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

        //ui text method to show how many tries are left. Will probably be moved to a different script
        public void SubtractTries()
        {
            triesScore = amountOfTries - usedTries;
            triesText.text = "x " + triesScore.ToString();

        }

        public bool GetTries()
        {
            return outOfTries;
        }
    }
}
