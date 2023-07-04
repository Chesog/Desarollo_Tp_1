using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for The Management of The Music in the Main Menu
/// </summary>
public class Menu_Music_Manager : MonoBehaviour
{
    [SerializeField] private AudioClip musicClip;

    private void OnEnable()
    {
        SoundManager.Instance.StopMusic();
        SoundManager.Instance.PlayMusic(musicClip);
    }
}
