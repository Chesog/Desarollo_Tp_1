using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effectSource;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    private void Update()
    {
        musicSource.volume = musicSlider.value;
        effectSource.volume = sfxSlider.value;
    }

    public void PlaySound(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }

    public void PlaySound(AudioClip clip,float volume)
    {
        effectSource.PlayOneShot(clip, volume);
    }

    public void PlayMusic(AudioClip clip) 
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void StopMusic() 
    {
        musicSource.Stop();
    }

    public AudioSource GetMusicSource()
    {
        return musicSource;
    }
    public void ToggleAudio()
    {
        effectSource.mute = !effectSource.mute;
        musicSource.mute = !musicSource.mute;
    }

}
