using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Class For The Menu Buttons
/// </summary>
public class Buton : MonoBehaviour
{
    [SerializeField] GameObject windowPrefab;
    [SerializeField] GameObject panelParent;

    /// <summary>
    /// Instantiate A Window Prefab On ClICK
    /// </summary>
    public void Onclick() 
    {
        panelParent.GetComponent<Buttons_Controller>().InstantiateWindow(windowPrefab);
    }

    /// <summary>
    /// Load The Gameplay Scene && Unloads The Menu Scene
    /// </summary>
    public void OnClickStart() 
    {
        //TODO - Fix - Hardcoded value
        SceneManager.LoadScene("wfc_Test");
        SceneManager.UnloadScene("Main_Menu");
    }

    /// <summary>
    /// Destroy The Prefab Of The Pannel
    /// </summary>
    public void OnWindowClose() 
    {
        Destroy(windowPrefab);
    }
}
