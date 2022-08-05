using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerAudio : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioListener audioListener;
    //audio arrays
    public AudioClip[] footsteps;
    public AudioClip[] swings;
    public AudioClip jumpAudio;

    void Footstep()
    {
        audioSource.clip = footsteps[Randomize(footsteps.Length)];
        audioSource.volume = 0.5f;
        audioSource.Play();
    }

    void Swing()
    {
        audioSource.clip = swings[Randomize(swings.Length)];
        audioSource.volume = 0.5f;
        audioSource.Play();
    }

   

    int Randomize(int size)
    {
        return (Random.Range(0, size));
    }
}
