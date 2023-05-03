using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WineCrafter
{
    public class OpenLinks : MonoBehaviour
    {
        //Linkit pelin nettisivulle
        public string gameWebsiteEn;
        public string gameWebsiteFi;

        //Linkit Teiskon Viinin nettisivulle
        public string wineryWebsiteEn;
        public string wineryWebsiteFi;

        public void OpenGameURL()
        {
            //Tarkistetaan kieli ennen linkin avaamista, default englanti
            if (PlayerPrefs.GetString("languageKey", "en") == "en")
            {
                Application.OpenURL(gameWebsiteEn);
            }

            if (PlayerPrefs.GetString("languageKey", "en") == "fi")
            {
                Application.OpenURL(gameWebsiteFi);
            }
        }

        public void OpenWineryURL()
        {

            if (PlayerPrefs.GetString("languageKey", "en") == "en")
            {
                Application.OpenURL(wineryWebsiteEn);
            }

            if (PlayerPrefs.GetString("languageKey", "en") == "fi")
            {
                Application.OpenURL(wineryWebsiteFi);
            }
        }

    }
}

