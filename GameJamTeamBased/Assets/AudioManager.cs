using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour

{
    #region Fields

    [SerializeField] private AudioSource _backgroundMusicDayOne;
    [SerializeField] private AudioSource _menuMusic;
    [SerializeField] private AudioSource _correctTask;
    [SerializeField] private AudioSource _wrongTask;

    private bool _menuMusicIsOn;
    //private bool _backgroundMusicDayOneIsOn;
    #endregion

    #region Public Functions

    //starts Roomscenes background music on day 1
    //also ends the menu music 
    public void playBackgroundMusicDayOne()
    {
        if (_menuMusicIsOn)
        {
            Debug.Log("Playing Day1 Music");
            _menuMusic.Stop();
            _menuMusicIsOn = false;
        }
        _backgroundMusicDayOne.Play();
        //_backgroundMusicDayOneIsOn = true;
    }

    //plays menu music
    public void playMenuMusic()
    {
        Debug.Log("Playing Menu Music");
        _menuMusic.Play();
        _menuMusicIsOn = true;
    }

    public void playCorrectTaskSound()
    {
        _correctTask.Play();
    }

    public void playWrongTaskSound()
    {
        _wrongTask.Play();
    }

    //plays and audiosource of a gameobject (use getcomponent?)
    public void playAudioSource(AudioSource audioSource)
    {
        audioSource.Play();
    }
    #endregion
}
