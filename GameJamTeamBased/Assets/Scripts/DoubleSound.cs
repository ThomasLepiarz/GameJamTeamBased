using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSound : MonoBehaviour
{
    public AudioClip firstAudioClip;
    public AudioClip secondAudioClip;

    IEnumerator WaitForClipFinish()
    {
        yield return new WaitForSeconds(5);
    }


    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click!");
            GetComponent<AudioSource>().PlayOneShot(firstAudioClip,1);

            StartCoroutine(WaitForClipFinish());

            GetComponent<AudioSource>().PlayOneShot(secondAudioClip, 1);

        }
    }


}
