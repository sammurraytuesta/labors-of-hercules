using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip music;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        audioSource.clip = music;
        audioSource.Play();
    }
}
