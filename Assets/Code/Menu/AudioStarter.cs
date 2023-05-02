using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WineCrafter
{
    public class AudioStarter : MonoBehaviour
    {

        GameObject volumeSlider;
        SoundManager soundManager;

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

            volumeSlider = GameObject.Find("VolumeSlider");
            soundManager = volumeSlider.GetComponent<SoundManager>();

            soundManager.ChangeVolume();
        }

    }
}
