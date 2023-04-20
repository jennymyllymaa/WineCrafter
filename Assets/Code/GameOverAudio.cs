using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WineCrafter
{
    public class GameOverAudio : MonoBehaviour
    {
        AudioSource gameOverAudio;
        public GameObject gameOverpanel;
        bool soundPlayed = false;

        // Start is called before the first frame update
        void Start()
        {
            gameOverAudio = GetComponent<AudioSource>();

        }

        // Update is called once per frame
        void Update()
        {
            if (gameOverpanel.activeInHierarchy && !soundPlayed)
            {
                soundPlayed= true;
                gameOverAudio.Play();
                Debug.Log("Gameoveraudio triggered");
            }

        }
    }
}

