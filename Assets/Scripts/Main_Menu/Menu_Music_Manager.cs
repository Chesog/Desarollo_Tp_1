using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Music_Manager : MonoBehaviour
{
    [SerializeField] private AudioClip musicClip;

    private void OnEnable()
    {
        SoundManager.Instance.StopMusic();
        SoundManager.Instance.PlayMusic(musicClip);
    }
}
