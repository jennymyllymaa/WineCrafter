using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

namespace WineCrafter
{
    public class WineSpawner : MonoBehaviour
    {
        [SerializeField] public GameObject wineDrop;

        // otettu pois SerializedField amountofTriesistä koska haetaan luku Playerprefistä
        private int amountOfTries;

        // these two are used for the ui score text
        public Text triesText;
        private int triesScore = 0;

        // tätä ei enää tarvita jos kaikki toimii! poista jos ei bugaa kolmosen pisteet. private int usedTries = 0;
        private Vector3 spawnPosition;
        private CircleCollider2D col;
        public bool outOfTries = false;

        //start called only to make UI text appear right in the beginning
        private void Start()
        {
            /*UUSI*/
            amountOfTries = PlayerPrefs.GetInt("currentGameScore", 0);

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
            /* jennyn  vanha koodi, voidaan poistaa jos ei tule kolmosen pistelaskuun bugeja 
             * 
             * if (usedTries < amountOfTries)
            {
                Debug.Log("spawni aika");
                Instantiate(wineDrop, spawnPosition, Quaternion.identity);
                usedTries++;
                Debug.Log("käytetty: " + usedTries);
                SubtractTries();
            } */

            
            // UUSI KOODI NOORALTA KORVATTU YLLÄ OLEVA VANHA 
            if (amountOfTries > 0)
            {
                Instantiate(wineDrop, spawnPosition, Quaternion.identity);
                amountOfTries--;
                SubtractTries();

            }

            // Start checking the final points after running out of tries
            if (amountOfTries == 0 && !outOfTries)
            {
                outOfTries = true;
                StartCoroutine(CheckScore());
            }

        }

        // NEW
        // waits for a second before starting the score check process
        //Triggers either Score scene or Game over panel
        private IEnumerator CheckScore()
        {
            // wait for a short delay to allow the game to calculate the final score
            yield return new WaitForSeconds(1);

            if (PlayerPrefs.GetInt("currentGameScore") != 0)
            {
                EndOfGame();
            }
            else
            {
                EndOfGameFail();
            }
        }


        // alla olevaa ei käytetä ollenkaan, poista jos ei tule käyttöä
        public int GetAmount()
        {
            return amountOfTries;
        }

        //ui text method to show how many tries are left. Will probably be moved to a different script
        public void SubtractTries()
        {
            triesScore = amountOfTries;
            triesText.text = "x " + triesScore.ToString();

        }

        public bool GetTries()
        {
            return outOfTries;
        }

        public void EndOfGame()
        {
            StartCoroutine(WaitCoroutine());
        }

        private IEnumerator WaitCoroutine()
        {
            yield return new WaitForSeconds(0.5f);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

        public void EndOfGameFail()
        {
            StartCoroutine(FailCoroutine());
        }

        private IEnumerator FailCoroutine()
        {
            yield return new WaitForSeconds(1);

            GameObject gameOverParent;
            GameObject paneeli;

            gameOverParent = GameObject.Find("Canvas");
            paneeli = gameOverParent.transform.Find("NEWGAMEOVERPANEL").gameObject;
            paneeli.SetActive(true);
            Time.timeScale = 0;

        }
    }
}