using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lenguaje_Select : MonoBehaviour
{
    [SerializeField] GameObject ls_Screen;
    //TODO - Fix - Code is in Spanish or is trash code
    enum lenguaje
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

    //TODO: TP2 - Remove unused methods/variables
    // Update is called once per frame
    void Update()
    {
        
    }

    //TODO: TP2 - SOLID
    public void SelectSpanish() 
    {
        //TODO - Fix - Hardcoded value
        PlayerPrefs.SetString("Lenguaje",lenguaje.Spanish.ToString());
        ls_Screen.SetActive(false);
    }
    public void SelectEnglish()
    {
        //TODO - Fix - Hardcoded value
        PlayerPrefs.SetString("Lenguaje", lenguaje.English.ToString());
        ls_Screen.SetActive(false);
    }
}
