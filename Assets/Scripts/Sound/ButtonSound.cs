using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ButtonAudio : MonoBehaviour
{
    public AudioClip clickSound;  // The sound you want to play
    private AudioSource audioSource;
    private Button button;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(PlayClickSound);
        }
    }

    void PlayClickSound()
    {
        if (clickSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
