using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRangeScript : MonoBehaviour
{
    [HideInInspector] public bool inRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") inRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") inRange = false;
    }
}
