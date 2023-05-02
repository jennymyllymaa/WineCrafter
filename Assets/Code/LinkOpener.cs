using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LinkOpener : MonoBehaviour
{
    public string englishLink;
    public string finnishLink;

    private void Start()
    {
        // Get the currently selected language
        Locale currentLocale = LocalizationSettings.SelectedLocale;

        // Set the link based on the selected language
        if (currentLocale.name == "English")
        {
            
        }
        else if (currentLocale.name == "Finnish")
        {
            
        }
    }

    public void OpenLinkInBrowser()
    {
        // Get the link based on the current language
        string link = "";
        Locale currentLocale = LocalizationSettings.SelectedLocale;
        if (currentLocale.name == "English")
        {
            link = englishLink;
        }
        else if (currentLocale.name == "Finnish")
        {
            link = finnishLink;
        }

        // Open the link in the browser
        Application.OpenURL(link);
    }
}
