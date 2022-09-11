using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnClick : MonoBehaviour
{
    public AudioSource soundPlayer;
     
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click!");
            soundPlayer.Play();
        }
    }
}
