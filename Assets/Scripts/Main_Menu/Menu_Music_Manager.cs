using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Music_Manager : MonoBehaviour
{
    [SerializeField] AudioClip musicClip;

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
