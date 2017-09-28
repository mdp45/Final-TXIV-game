using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class SoundScript : MonoBehaviour {
    public AudioClip audioClip;
    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CrossPlatformInputManager.GetButtonUp("Fire"))
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
