using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSound : MonoBehaviour
{
    #region Fields

    [SerializeField] private AudioSource firstAudioClip;
    [SerializeField] private AudioSource secondAudioClip;

    private bool waitForClipEnd = false;
    private bool firstClipPlayed = false;
    private bool secondClipPlayed = false;

    #endregion

    #region Private Functions

    private void OnMouseDown()
    {
        if (waitForClipEnd)
        {
            return;
        }
        else
        {
            PlayFirstAudioClip();
            PlaySecondAudioClip();
        }
    }

    private void PlayFirstAudioClip()
    {
        while (!firstClipPlayed)
        {
            if (!firstAudioClip.isPlaying)
            {
                firstAudioClip.Play();
                waitForClipEnd = true;
            }
            else
            {
                firstClipPlayed = true;
                waitForClipEnd = false;
            }
        }
    }

    private void PlaySecondAudioClip()
    {
        while (!secondClipPlayed)
        {
            if (!secondAudioClip.isPlaying)
            {
                secondAudioClip.Play();
                waitForClipEnd = true;
            }
            else
            {
                secondClipPlayed = true;
                waitForClipEnd = false;
            }
        }
    }
    #endregion
}
