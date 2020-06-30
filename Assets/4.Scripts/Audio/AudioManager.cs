using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    private static AudioManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<AudioManager>();
            return _instance;
        }
    }

#pragma warning disable 0649    
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private AudioSource _background;
    [SerializeField] private AudioSource _effects;
#pragma warning restore 0649
    
    private static bool _isQuitting;

    private void Awake()
    {
        _instance = this;
    }

    public static void ToggleBackground(bool isOn)
    {
        if(_isQuitting)
            return;
        Instance._mixer.SetFloat("BackgroundVolume", isOn ? -5f : -80f);
    }
    
    public static void ToggleSfx(bool isOn)
    {
        if(_isQuitting)
            return;
        Instance._mixer.SetFloat("SfxVolume", isOn ? 10f : -80f);
    }

    public static void SetBackground(AudioClip clip)
    {
        if(_isQuitting)
            return;
        Instance._background.Stop();
        Instance._background.clip = clip;
        Instance._background.Play();
    }

    public static void PlayEffect(AudioClip clip)
    {
        if(_isQuitting)
            return;
        Instance._effects.PlayOneShot(clip);
    }

    private void OnApplicationQuit()
    {
        _isQuitting = true;
    }
}
