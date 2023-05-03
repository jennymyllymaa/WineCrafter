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

        void Start()
        {
            gameOverAudio = GetComponent<AudioSource>();

        }

        // play gameover sound if gameover panel is triggered
        void Update()
        {
            if (gameOverpanel.activeInHierarchy && !soundPlayed)
            {
                soundPlayed = true;
                gameOverAudio.Play();
            }

        }
    }
}

