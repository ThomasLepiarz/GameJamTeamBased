using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayObjectSounds : MonoBehaviour
{
    #region Fields

    [SerializeField] private AudioSource objectSound;
    [SerializeField] private AudioSource voiceLinePlayer;
    [SerializeField] private AudioSource voiceLineNarrator;

    private bool soundFileIsPlaying;

    #endregion

    private void OnMouseDown()
    {
        //is any sound of this object playing?
        if (!soundFileIsPlaying)
        {
            //play the object sound first if existent
            if (objectSound != null)
            {
                objectSound.Play();
                soundFileIsPlaying = true;
                while (objectSound.isPlaying)
                {
                    if (!objectSound.isPlaying)
                    {
                        break;
                    }
                }
            }

            //play the player voice line second if existent
            if (voiceLinePlayer != null)
            {
                voiceLinePlayer.Play();
                while (voiceLinePlayer.isPlaying)
                {
                    if (!voiceLinePlayer.isPlaying)
                    {
                        break;
                    }
                }
            }

            //play narrator voice line last if existent
            if (voiceLineNarrator != null)
            {
                voiceLineNarrator.Play();
                while (voiceLineNarrator.isPlaying)
                {
                    if(!voiceLineNarrator.isPlaying)
                    {
                        break;
                    }
                }
            }
            soundFileIsPlaying = false;
        }
        else
        {
            return;
        }      
    }
}
