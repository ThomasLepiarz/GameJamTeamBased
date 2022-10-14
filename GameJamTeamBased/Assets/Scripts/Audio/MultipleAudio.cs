using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleAudio : MonoBehaviour
{

    public AudioClip firstAudioClip;
    public AudioClip secondAudioClip;
    public AudioSource audio;
  

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().PlayOneShot(firstAudioClip, 1);
            GetComponent<AudioSource>().PlayOneShot(secondAudioClip, 1);

            //AudioClip.PlayOneShot(firstAudioClip, 0.7F);
            //AudioClip.PlayOneShot(secondAudioClip, 0.7F);

        }

    }


}
