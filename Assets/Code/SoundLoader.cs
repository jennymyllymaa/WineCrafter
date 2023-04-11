using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WineCrafter
{
    public class SoundLoader : MonoBehaviour
    {
        public AudioListener audioListener;

        // Start is called before the first frame update
        void Awake()
        {
            AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}


