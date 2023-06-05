using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Music_Manager : MonoBehaviour
{
    //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc)
    [SerializeField] AudioClip musicClip;

    //TODO: TP2 - Remove unused methods/variables
    // Start is called before the first frame update
    //void Start()
    //{
    //    SoundManager.Instance.StopMusic();
    //    SoundManager.Instance.PlayMusic(musicClip);
    //}

    private void OnEnable()
    {
        SoundManager.Instance.StopMusic();
        SoundManager.Instance.PlayMusic(musicClip);
    }

    //TODO: TP2 - Remove unused methods/variables
    // Update is called once per frame
    void Update()
    {
        
    }
}
