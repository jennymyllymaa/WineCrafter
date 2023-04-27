using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WineCrafter
{
    public class AudioStarter : MonoBehaviour
    {
        void Start()
        {
            if (!PlayerPrefs.HasKey("musicVolume"))
            {
                PlayerPrefs.SetFloat("musicVolume", 1);
                PlayerPrefs.GetFloat("musicVolume");
            }

            else
            {
                PlayerPrefs.GetFloat("musicVolume");
            }
        }

    }
}
