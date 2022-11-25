using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyOpenScript : MonoBehaviour
{
    public GateScript gate;

    private KeyManagerScript keyManager;

    private void Awake()
    {
        keyManager = FindObjectOfType<KeyManagerScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && keyManager.hasKey && !gate.lever.isOn)
        {
            gate.lever.ToggleSwitch();
        }
    }
}
