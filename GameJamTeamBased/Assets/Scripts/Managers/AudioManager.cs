using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour

{
    #region Fields

    [SerializeField] private AudioSource _menuMusic;
    [SerializeField] private AudioSource _backgroundMusicDayOne;
    [SerializeField] private AudioSource _bathroomMusic;
    [SerializeField] private AudioSource _garageMusic;
    [SerializeField] private AudioSource _correctTask;
    [SerializeField] private AudioSource _wrongTask;
    [SerializeField] private AudioSource _coffeeNarratorLine;
    [SerializeField] private AudioSource _nothingWithoutCoffee;
    [SerializeField] private AudioSource _coffeeGrinder;
    [SerializeField] private AudioSource _sinkSound;
    [SerializeField] private AudioSource _finallySomeQuiet;

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
        _bathroomMusic.Stop();
        _garageMusic.Stop();
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

    public void PlayCoffeeTaskLine()
    {
        _coffeeNarratorLine.Play();
    }

    public void PlayNothingWithoutCoffee()
    {
        _nothingWithoutCoffee.Play();
    }

    public void PlayCoffeeGrinderSound()
    {
        if (!_coffeeGrinder.isPlaying) { _coffeeGrinder.Play(); }
    }

    public void PlaySinkSound()
    {
        if (!_sinkSound.isPlaying) { _sinkSound.Play(); }
    }

    public void PlayFinallySomeQuiet()
    {
        _finallySomeQuiet.Play();
    }

    public void PlayBathroomMusic()
    {
        if (!_bathroomMusic.isPlaying)
        {
            _bathroomMusic.Play();
        }
    }

    public void StopBathroomMusic()
    {
        _bathroomMusic.Stop();
    }

    public void PlayGarageMusic()
    {
        if (!_garageMusic.isPlaying)
        {
            _garageMusic.Play();
        }
    }

    public void StopGarageMusic()
    {
        _garageMusic.Stop();
    }
    #endregion
}
