using UnityEngine;
using UnityEngine.UI;

public class Volume_Controller : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Awake()
    {
        ChangeMusic_Value();
        ChangeSFX_Value();
    }

    public void ChangeMusic_Value()
    {
        SoundManager.Instance.ChangeMusic_Volume(musicSlider.value);
    }
    public void ChangeSFX_Value()
    {
        SoundManager.Instance.ChangeSFX_Volume(sfxSlider.value);
    }
}
