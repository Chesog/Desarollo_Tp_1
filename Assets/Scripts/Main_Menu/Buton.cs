using UnityEngine;
using UnityEngine.SceneManagement;

//TODO: TP2 - Syntax - Consistency in naming convention
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
        //TODO - Fix - Hardcoded value
        SceneManager.LoadScene("wfc_Test");
        SceneManager.UnloadScene("Main_Menu");
    }

    public void CloseWindow() 
    {
        Destroy(windowPrefab);
    }
}
