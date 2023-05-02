using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WineCrafter
{

    public class PlayAudioScript : MonoBehaviour
    {

        Button CreditsButton;


        private void Start()
        {
            CreditsButton = GetComponent<Button>();
        }


        // play the sound
        public void PlayAudio()
        {
            AudioSource audio = CreditsButton.GetComponent<AudioSource>();

            if (audio != null)
            {
                audio.Play();
            }
        }
    }
}
