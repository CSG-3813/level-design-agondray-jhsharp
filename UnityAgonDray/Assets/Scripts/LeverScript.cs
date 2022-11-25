using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LeverScript : MonoBehaviour
{
    public bool isOn;
    public float cooldown = 1f;
    public AudioClip clip;

    private bool toggle;
    private float cooldownDefault;
    private Animator animator;
    private AudioSource audioSrc;
    private PlayerInput input;
    private InputAction toggleAction;


    private void Awake()
    {
        cooldownDefault = cooldown;

        animator = GetComponent<Animator>();
        audioSrc = GetComponent<AudioSource>();

        input = FindObjectOfType<PlayerInput>();
        toggleAction = input.actions["Use"];
    }

    private void Update()
    {
        if (cooldown > 0) cooldown -= Time.deltaTime;

        if (toggleAction.triggered && cooldown <= 0)
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
            ToggleSwitch();
        }
        toggle = false;
    }

    public void ToggleSwitch()
    {
        isOn = !isOn;
        cooldown = cooldownDefault;
        animator.SetBool("isOn", isOn);
        audioSrc.PlayOneShot(clip);
    }
}
