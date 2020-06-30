
using System;
using UnityEngine;

public class Settings : MonoBehaviour
{
    private bool _music;
    private bool _sfx;
#pragma warning disable 0649
    [SerializeField] private GameObject _musicOn;
    [SerializeField] private GameObject _musicOff;
    [SerializeField] private GameObject _sfxOn;
    [SerializeField] private GameObject _sfxOff;
#pragma warning restore 0649

    public void Setup()
    {
       _music = GetMusic();
        _sfx = GetSfx();
        _UpdateUI();
        ToggleByPrefs();
    }

    private void ToggleByPrefs()
    {
        AudioManager.ToggleBackground(_music);
        AudioManager.ToggleSfx(_sfx);
    }

    public void ToggleMusic()
    {
        _music = !_music;
        SaveMusic(_music);
        AudioManager.ToggleBackground(_music);
    }
    
    public void ToggleSfx()
    {
        _sfx = !_sfx;
        SaveSfx(_sfx);
        AudioManager.ToggleSfx(_sfx);
    }

    public bool GetMusic()
    {


        if (PlayerPrefs.GetInt("MusicSound", 1) == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SaveMusic(bool music)
    {
        if (music)
        {
            PlayerPrefs.SetInt("MusicSound", 1);
        }
        else
        {
            PlayerPrefs.SetInt("MusicSound", 0); 
        }
    }
    
    public bool GetSfx()
    {


        if (PlayerPrefs.GetInt("SfxSound", 1) == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SaveSfx(bool music)
    {
        if (music)
        {
            PlayerPrefs.SetInt("SfxSound", 1);
        }
        else
        {
            PlayerPrefs.SetInt("SfxSound", 0); 
        }
    }

    public void _UpdateUI()
    {
        if (_music)
        {
            _musicOn.SetActive(true);
            _musicOff.SetActive(false);
        }
        else
        {
            _musicOn.SetActive(false);
            _musicOff.SetActive(true);
        }
        
        if(_sfx)
        {
            _sfxOn.SetActive(true);
            _sfxOff.SetActive(false);
        }
        else
        {
            _sfxOn.SetActive(false);
            _sfxOff.SetActive(true);
        }
        
    }
}
