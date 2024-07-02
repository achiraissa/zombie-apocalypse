using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    public AudioClip musicClip;
    private AudioSource audioSource;
    // Start is called before the first frame update
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = musicClip;
        audioSource.Play();
    }
   
}
