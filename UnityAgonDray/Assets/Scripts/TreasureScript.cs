using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureScript : MonoBehaviour
{
    public GameObject victoryText;

    private void Awake()
    {
        victoryText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        victoryText.SetActive(true);
    }
}
