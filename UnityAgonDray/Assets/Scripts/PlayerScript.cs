using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float resetDelay = 2f;
    public GameObject caughtScreen;
    public AudioClip caughtClip;
    public TextMeshProUGUI caughtText;
    public TextMeshProUGUI timerText;

    private static int timesCaught;
    private static float levelStartTime;
    private AudioSource audioSrc;

    private void Awake()
    {
        caughtScreen.SetActive(false);
        audioSrc = GetComponent<AudioSource>();

        if (timesCaught == 1) caughtText.text = "Caught 1 time";
        else caughtText.text = "Caught " + timesCaught + " times";

        if (timesCaught == 0) levelStartTime = Time.realtimeSinceStartup;
    }

    private void Update()
    {
        int elapsedTime = (int)(Time.realtimeSinceStartup - levelStartTime);
        timerText.text = (elapsedTime / 60) + ":" + (elapsedTime % 60).ToString("d2");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Caught();
        }
    }

    private void Caught()
    {
        timesCaught++;
        caughtScreen.SetActive(true);
        audioSrc.PlayOneShot(caughtClip);
        Invoke("ResetScene", resetDelay);
    }

    private void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
