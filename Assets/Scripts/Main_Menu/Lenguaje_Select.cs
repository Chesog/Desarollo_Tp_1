using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lenguaje_Select : MonoBehaviour
{
    [SerializeField] GameObject ls_Screen;
    enum lenguaje
    {
        Spanish,English
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("Lenguaje"))
        {
            ls_Screen.SetActive(false);
        }
        else 
        {
            ls_Screen.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectSpanish() 
    {
        PlayerPrefs.SetString("Lenguaje",lenguaje.Spanish.ToString());
        ls_Screen.SetActive(false);
    }
    public void SelectEnglish()
    {
        PlayerPrefs.SetString("Lenguaje", lenguaje.English.ToString());
        ls_Screen.SetActive(false);
    }
}
