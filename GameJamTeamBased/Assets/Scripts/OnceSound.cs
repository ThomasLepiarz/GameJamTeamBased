using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnceSound : MonoBehaviour
{
    private bool hasPlayed;
    public AudioSource oncePlayer;
    // Start is called before the first frame update
    void Start()
    {
        if (!hasPlayed)
        {
            oncePlayer.Play();
            hasPlayed = true;
        }
    }
}
