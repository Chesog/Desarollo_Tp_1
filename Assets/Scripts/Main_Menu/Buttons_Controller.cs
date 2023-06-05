using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;


//TODO - Documentation - Add summary
public class Buttons_Controller : MonoBehaviour
{
    [SerializeField] GameObject windowMaster;
    //TODO: TP2 - Syntax - Consistency in naming convention
    [SerializeField] CinemachineVirtualCamera cam;

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


    //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc)
    // Start is called before the first frame update
    void Start()
    {
        cam.Follow = mainMenu;
        cam.LookAt = mainMenu;
        menu_Canvas.active = true;
        options_Canvas.active = false;
        credits_Canvas.active = false;
    }

    //TODO: TP2 - Remove unused methods/variables
    // Update is called once per frame
    void Update()
    {
        
    }

    //TODO: TP2 - SOLID
    public void LookOptions() 
    {
        menu_Canvas.active = false;
        options_Canvas.active = true;
        credits_Canvas.active = false;
        cam.Follow = options;
        cam.LookAt = options;
        system.SetSelectedGameObject(options_firstButton);
    }

    public void LookMainMenu() 
    {
        menu_Canvas.active = true;
        options_Canvas.active = false;
        credits_Canvas.active = false;
        cam.Follow = mainMenu;
        cam.LookAt = mainMenu;
        system.SetSelectedGameObject(menu_firstButton);
    }

    public void LookCredits()
    {
        menu_Canvas.active = false;
        options_Canvas.active = false;
        credits_Canvas.active = true;
        cam.Follow = credits;
        cam.LookAt = credits;
        system.SetSelectedGameObject(credits_firstButton);
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
