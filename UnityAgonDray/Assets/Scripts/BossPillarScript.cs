using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPillarScript : MonoBehaviour
{
    public GameObject[] pillars;
    public LeverScript[] onLevers;
    public LeverScript[] offLevers;
    public AudioClip clip;

    private bool active = false;
    private AudioSource audioSrc;

    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();

        foreach (GameObject pillar in pillars)
        {
            pillar.SetActive(false);
        }
    }

    private void Update()
    {
        bool leversCorrect = true;

        foreach (LeverScript lever in onLevers)
        {
            if (!lever.isOn) leversCorrect = false;
        }
        foreach (LeverScript lever in offLevers)
        {
            if (lever.isOn) leversCorrect = false;
        }

        if (leversCorrect && !active)
        {
            foreach(GameObject pillar in pillars)
            {
                pillar.SetActive(true);
            }
            audioSrc.Stop();
            audioSrc.PlayOneShot(clip);
            active = true;
        }
        else if (!leversCorrect && active)
        {
            foreach (GameObject pillar in pillars)
            {
                pillar.SetActive(false);
            }
            audioSrc.Stop();
            audioSrc.PlayOneShot(clip);
            active = false;
        }
    }
}
