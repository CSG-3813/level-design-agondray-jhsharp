using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    public LeverScript lever;
    public AudioClip clip;

    private bool open;
    private Animator animator;
    private AudioSource audioSrc;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSrc = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if ((lever.isOn && !open) || (!lever.isOn && open))
        {
            ToggleGate();
        }
    }

    private void ToggleGate()
    {
        open = !open;
        animator.SetBool("isOpen", open);
        audioSrc.Stop();
        audioSrc.PlayOneShot(clip);
    }
}
