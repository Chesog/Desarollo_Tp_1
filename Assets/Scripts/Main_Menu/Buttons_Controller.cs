using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Buttons_Controller : MonoBehaviour
{
    [SerializeField] GameObject windowMaster;
    [SerializeField] CinemachineVirtualCamera cam;

    [SerializeField] Transform mainMenu;
    [SerializeField] GameObject menu_Canvas;
    [SerializeField] Transform options;
    [SerializeField] GameObject options_Canvas;
    [SerializeField] Transform credits;
    [SerializeField] GameObject credits_Canvas;


    // Start is called before the first frame update
    void Start()
    {
        cam.Follow = mainMenu;
        cam.LookAt = mainMenu;
        menu_Canvas.active = true;
        options_Canvas.active = false;
        credits_Canvas.active = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LookOptions() 
    {
        menu_Canvas.active = false;
        options_Canvas.active = true;
        credits_Canvas.active = false;
        cam.Follow = options;
        cam.LookAt = options;
    }

    public void LookMainMenu() 
    {
        menu_Canvas.active = true;
        options_Canvas.active = false;
        credits_Canvas.active = false;
        cam.Follow = mainMenu;
        cam.LookAt = mainMenu;
    }

    public void LookCredits()
    {
        menu_Canvas.active = false;
        options_Canvas.active = false;
        credits_Canvas.active = true;
        cam.Follow = credits;
        cam.LookAt = credits;
    }

    public void InstantiateWindow(GameObject windowPrefab)
    {
        Instantiate(windowPrefab, windowMaster.transform);
    }

    public void InstantiateWindow(GameObject windowPrefab, Vector3 pos)
    {
        GameObject window = Instantiate(windowPrefab, windowMaster.transform);
        window.transform.position = pos;
    }

    public void OnExit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Debug.Log("Quit Game");
    }
}
