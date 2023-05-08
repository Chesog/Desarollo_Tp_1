using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Buttons_Controller : MonoBehaviour
{
    [SerializeField] GameObject windowMaster;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
