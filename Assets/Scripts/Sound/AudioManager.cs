using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;


public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update
    public GameObject buttonAudio;
    public float soundDelay = 0.2f;
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        //AudioSource audioSource = buttonAudio.GetComponent<AudioSource>();
        //audioSource.Play();
    }

    // Update is called once per frame
    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void ButtonPlay()
    {
        AudioSource audioSource = buttonAudio.GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void ButtonPressed()
    {
        AudioSource audioSource = buttonAudio.GetComponent<AudioSource>();
        AudioClip audioClip = audioSource.clip;
        //audioSource.Play();
        // Debug.Log("Break 1");
        StartCoroutine(HandleButtonClick(audioClip, audioSource));
        // Debug.Log("Break 3");

    }
     IEnumerator HandleButtonClick(AudioClip clickSound, AudioSource source)
    {  
        source.Play();
        Debug.Log("Break 2");
        yield return new WaitForSeconds(clickSound.length + soundDelay);
        
    }
}
// title scene: button audio + title theme
// map scene: button audio + map theme
// scenes: scene audio loop + button audio + leave rustle + water plop + grass rustle + footsteps
// journal: map theme + button audio
// animalinfo: map theme + button audio
