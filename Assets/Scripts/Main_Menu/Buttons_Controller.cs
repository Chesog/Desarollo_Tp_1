using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;


//TODO - Documentation - Add summary
/// <summary>
/// Clas For The Management Of The Buttons
/// </summary>
public class Buttons_Controller : MonoBehaviour
{
    [SerializeField] GameObject windowMaster;
    [SerializeField] CinemachineVirtualCamera cinemachine_Camera;

    [Header("Main Menu Set Up")]
    [SerializeField] Transform mainMenu;
    [SerializeField] GameObject menu_Canvas;
    [SerializeField] GameObject menu_firstButton;
    [Header("Options Menu Set Up")]
    [SerializeField] Transform options;
    [SerializeField] GameObject options_Canvas;
    [SerializeField] GameObject options_firstButton;
    [Header("Credits Menu Set Up")]
    [SerializeField] Transform credits;
    [SerializeField] GameObject credits_Canvas;
    [SerializeField] GameObject credits_firstButton;
    [Header("EventSystem Set Up")]
    [SerializeField] EventSystem system;

    private void Start()
    {
        menu_Canvas.active = true;
        options_Canvas.active = false;
        credits_Canvas.active = false;
        cinemachine_Camera.Follow = mainMenu; //Fix
        cinemachine_Camera.LookAt = mainMenu;
    }

    /// <summary>
    /// Change The Camera Target To The Options Section
    /// </summary>
    public void LookOptions() 
    {
        menu_Canvas.active = false;
        options_Canvas.active = true;
        credits_Canvas.active = false;
        cinemachine_Camera.Follow = options; // Fix
        cinemachine_Camera.LookAt = options;
        system.SetSelectedGameObject(options_firstButton);
    }

    /// <summary>
    /// Change The Camera Target To The Main Menu Section
    /// </summary>
    public void LookMainMenu() 
    {
        menu_Canvas.active = true;
        options_Canvas.active = false;
        credits_Canvas.active = false;
        cinemachine_Camera.Follow = mainMenu; // Fix
        cinemachine_Camera.LookAt = mainMenu;
        system.SetSelectedGameObject(menu_firstButton);
    }

    /// <summary>
    /// Change The Camera Target To The Credits Section
    /// </summary>
    public void LookCredits()
    {
        menu_Canvas.active = false;
        options_Canvas.active = false;
        credits_Canvas.active = true;
        cinemachine_Camera.Follow = credits; // Fix
        cinemachine_Camera.LookAt = credits;
        system.SetSelectedGameObject(credits_firstButton);
    }

    /// <summary>
    /// Instantiate a Window Prefab Panel
    /// </summary>
    /// <param name="windowPrefab"></param>
    public void InstantiateWindow(GameObject windowPrefab)
    {
        Instantiate(windowPrefab, windowMaster.transform);
    }

    /// <summary>
    /// Instantiate a Window Prefab In a Determinated Position
    /// </summary>
    /// <param name="windowPrefab"></param>
    /// <param name="pos"></param>
    public void InstantiateWindow(GameObject windowPrefab, Vector3 pos)
    {
        GameObject window = Instantiate(windowPrefab, windowMaster.transform);
        window.transform.position = pos;
    }

    /// <summary>
    /// Close The Application && The Editor Playtime
    /// </summary>
    public void OnExit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
