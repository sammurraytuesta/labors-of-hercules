using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip hurtAudio;
    public float health;
    // Start is called before the first frame update
    protected virtual void Start()
    {
       
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (health < 1)
        {
            //Destroy(this.gameObject);
        }
    }

    protected void HurtSound()
    {
        audioSource.clip = hurtAudio;
        audioSource.Play();
    }
}
