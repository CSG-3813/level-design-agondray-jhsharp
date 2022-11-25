using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LeverScript : MonoBehaviour
{
    public bool isOn;
    public AudioClip clip;

    private bool toggle;
    private Animator animator;
    private AudioSource audioSrc;
    private PlayerInput input;
    private InputAction toggleAction;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSrc = GetComponent<AudioSource>();

        input = FindObjectOfType<PlayerInput>();
        toggleAction = input.actions["Use"];
    }

    private void Update()
    {
        if (toggleAction.triggered)
        {
            toggle = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        toggle = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (toggle && other.tag == "Player")
        {
            toggleSwitch();
        }
        toggle = false;
    }

    private void toggleSwitch()
    {
        isOn = !isOn;
        animator.SetBool("isOn", isOn);
        audioSrc.PlayOneShot(clip);
    }
}
