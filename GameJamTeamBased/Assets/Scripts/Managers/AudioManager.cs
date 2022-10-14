using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour

{
    #region Fields

    [SerializeField] private AudioSource _menuMusic;
    [SerializeField] private AudioSource _backgroundMusicDayOne;
    [SerializeField] private AudioSource _correctTask;
    [SerializeField] private AudioSource _wrongTask;

    private bool _menuMusicIsOn;
    //private bool _backgroundMusicDayOneIsOn;

    private bool _backgroundMusicIsOn;

    public bool BackGroundMusicIsOn
    {
        get { return _backgroundMusicIsOn; }
        private set => _backgroundMusicIsOn = value;
    }



    #endregion

    #region Public Functions

    //starts Roomscenes background music on day 1
    //also ends the menu music 
    public void PlayBackgroundMusicDayOne()
    {
        if (_menuMusicIsOn)
        {
            Debug.Log("Playing Day1 Music");
            _menuMusic.Stop();
            _menuMusicIsOn = false;
        }
        _backgroundMusicDayOne.Play();
        _backgroundMusicIsOn = true;
    }

    //plays menu music
    public void PlayMenuMusic()
    {
        Debug.Log("Playing Menu Music");
        _menuMusic.Play();
        _menuMusicIsOn = true;
    }

    public void PlayCorrectTaskSound()
    {
        _correctTask.Play();
    }

    public void PlayWrongTaskSound()
    {
        _wrongTask.Play();
    }

    //plays and audiosource of a gameobject (use getcomponent?)
    public void PlayAudioSource(AudioSource audioSource)
    {
        audioSource.Play();
    }

    public void StopAllMusic()
    {
        _backgroundMusicDayOne.Stop();
        _menuMusic.Stop();
        _backgroundMusicIsOn = false;
    }

    public void PauseBackgroundMusic()
    {
        _backgroundMusicDayOne.Pause();
        _backgroundMusicIsOn = false;
    }

    public void UnPauseBackgroundMusic()
    {
        _backgroundMusicDayOne.UnPause();
        _backgroundMusicIsOn = true;
    }
    #endregion
}
