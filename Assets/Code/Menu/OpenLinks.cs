using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WineCrafter
{
    public class OpenLinks : MonoBehaviour
    {
        //Links fot he game website
        public string gameWebsiteEn;
        public string gameWebsiteFi;

        //Links for Teiskon Viini
        public string wineryWebsiteEn;
        public string wineryWebsiteFi;

        public void OpenGameURL()
        {
            //Check the language before opening, default english
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

