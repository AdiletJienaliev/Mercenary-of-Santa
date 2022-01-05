using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocalizationManager : MonoBehaviour
{
    public List<TextTwice> TextLocalization = new List<TextTwice>();
    private void Start()
    {
        Localization();
    }
    public void Localization()
    {
        for (int i = 0; i < TextLocalization.Count; i++)
        {
            if (PlayerPrefs.GetInt("Localization") == 0)
            {
                TextLocalization[i].text.text = TextLocalization[i].ru;
            }
            else
            {
                TextLocalization[i].text.text = TextLocalization[i].eng;
            }
        }
    }
    public void LocalizationNext(int index)
    {
        PlayerPrefs.SetInt("Localization", index);
        Localization();
    }
}
[System.Serializable]
public class TextTwice
{
    public TextMeshProUGUI text;
    public string ru;
    public string eng;
}
