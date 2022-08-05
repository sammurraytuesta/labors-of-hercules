using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChange : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip battleMusic;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            audioSource.clip = battleMusic;
            audioSource.Play();
        }
    }
}
