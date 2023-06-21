using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class For The Lenguage Selection
/// </summary>
public class Language_Select : MonoBehaviour
{
    [SerializeField] GameObject ls_Screen;
    //TODO - Fix - Code is in Spanish or is trash code
    enum Language
    {
        Spanish,English
    }
    void Start()
    {
        //TODO - Fix - Hardcoded value
        if (PlayerPrefs.HasKey("Lenguaje"))
        {
            ls_Screen.SetActive(false);
        }
        else 
        {
            ls_Screen.SetActive(true);
        }
    }

    //TODO: TP2 - SOLID

    /// <summary>
    /// Function For The Spanish Language Selection
    /// </summary>
    public void SelectSpanish() 
    {
        //TODO - Fix - Hardcoded value
        PlayerPrefs.SetString("Lenguaje",Language.Spanish.ToString());
        ls_Screen.SetActive(false);
    }

    /// <summary>
    /// Function For The English Language Selection
    /// </summary>
    public void SelectEnglish()
    {
        //TODO - Fix - Hardcoded value
        PlayerPrefs.SetString("Lenguaje", Language.English.ToString());
        ls_Screen.SetActive(false);
    }
}
