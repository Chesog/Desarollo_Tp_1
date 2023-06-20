using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effectSource;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;



    private void OnEnable()
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

    /// <summary>
    /// Function To PLay An One Shot Of a Audio Clip That you Give it By Parameterr
    /// </summary>
    /// <param name="clip"></param>
    public void PlaySound(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }

    /// <summary>
    /// Function To Play An One Shot Of A Audio Clip at a certain volume That you Give it By Parameter
    /// </summary>
    /// <param name="clip"></param>
    /// <param name="volume"></param>
    public void PlaySound(AudioClip clip,float volume)
    {
        effectSource.PlayOneShot(clip, volume);
    }

    /// <summary>
    /// Play A Music That you Give it By Parameter
    /// </summary>
    /// <param name="clip"></param>
    public void PlayMusic(AudioClip clip) 
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    /// <summary>
    /// Stops The Current Music Audio Clip
    /// </summary>
    public void StopMusic() 
    {
        musicSource.Stop();
    }

    /// <summary>
    /// Returns The Audio Source For The Music
    /// </summary>
    /// <returns></returns>
    public AudioSource GetMusicSource()
    {
        return musicSource;
    }

    /// <summary>
    /// Togle The Music && SFX To Mute or UN Mute
    /// </summary>
    public void ToggleAudio()
    {
        effectSource.mute = !effectSource.mute;
        musicSource.mute = !musicSource.mute;
    }

}
