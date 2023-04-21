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

        // otettu pois SerializedField amountofTriesist‰ koska haetaan luku Playerprefist‰
        private int amountOfTries;

        // these two are used for the ui score text
        public Text triesText;
        private int triesScore = 0;


        // t‰t‰ ei en‰‰ tarvita jos kaikki toimii! poista jos ei bugaa kolmosen pisteet. private int usedTries = 0;
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
                Debug.Log("k‰ytetty: " + usedTries);
                SubtractTries();
            } */

            
            // UUSI KOODI NOORALTA KORVATTU YLLƒ OLEVA VANHA 
            if (amountOfTries > 0)
            {
                Instantiate(wineDrop, spawnPosition, Quaternion.identity);
                amountOfTries--;
                SubtractTries();

            }

            // UUSI KOODI NOORALTA.
            //kun vuorot loppuu ja jos on saanut edes yhden pisteen, tulee score scene
            //jos taas vuorot loppuu JA ei ole yht‰‰n scorea, tulee game over paneeli ja peli p‰‰ttyy

            if (amountOfTries == 0 && PlayerPrefs.GetInt("currentGameScore") != 0)
            {
                EndOfGame();
                
            }


            if (amountOfTries == 0 && PlayerPrefs.GetInt("currentGameScore") == 0)
            {

                EndOfGameFail();

            }

        }

        // alla olevaa ei k‰ytet‰ ollenkaan, poista jos ei tule k‰yttˆ‰
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
            yield return new WaitForSeconds(1);

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