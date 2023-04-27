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
            GetComponent<Text>().text = "<color=blue><u>" + englishLink + "</u></color>";
        }
        else if (currentLocale.name == "Finnish")
        {
            GetComponent<Text>().text = "<color=blue><u>" + finnishLink + "</u></color>";
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

        // Open the link in the user's default browser
        Application.OpenURL(link);
    }
}
