using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;


namespace WineCrafter
{
    public class LanguageButtons : MonoBehaviour
    {
        public Button englishButton;
        public Button finnishButton;

        //private const string languageKey = "language";

        void Start()
        {
            string savedLanguage = PlayerPrefs.GetString("languageKey", "en");
            SetLocale(savedLanguage);
            Debug.Log(savedLanguage);

            englishButton.onClick.AddListener(() =>
            {
                SetLocale("en");
                PlayerPrefs.SetString("languageKey", "en");
            });

            finnishButton.onClick.AddListener(() =>
            {
                SetLocale("fi");
                PlayerPrefs.SetString("languageKey", "fi");
            });


        }

        void SetLocale(string localeCode)
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.GetLocale(localeCode);
        }

    }
}


