using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Music_Manager : MonoBehaviour
{
    //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc)
    [SerializeField] private AudioClip musicClip;

    private void OnEnable()
    {
        SoundManager.Instance.StopMusic();
        SoundManager.Instance.PlayMusic(musicClip);
    }
}
