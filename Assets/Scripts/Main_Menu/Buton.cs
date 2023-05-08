using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buton : MonoBehaviour
{
    [SerializeField] GameObject windowPrefab;
    [SerializeField] GameObject panelParent;

    public void Onclick() 
    {
        panelParent.GetComponent<Buttons_Controller>().InstantiateWindow(windowPrefab);
    }

    public void OnClickStart() 
    {
        SceneManager.LoadScene("Test_Scene");
        SceneManager.UnloadScene("Main_Menu");
    }

    public void CloseWindow() 
    {
        Destroy(windowPrefab);
    }
}
