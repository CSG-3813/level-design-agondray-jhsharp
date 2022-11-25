using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManagerScript : MonoBehaviour
{
    public bool hasKey;
    public AudioClip clip;

    private AudioSource audioSrc;

    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {
            hasKey = true;
            audioSrc.PlayOneShot(clip);
            other.gameObject.SetActive(false);
        }
    }
}
