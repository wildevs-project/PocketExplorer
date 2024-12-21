using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsScreen : MonoBehaviour
{
    public string titleScene;
    public GameObject buttonAudio;


    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public virtual void Back() {
        ButtonPressed(titleScene);
        //SceneManager.LoadScene(titleScene);
    }

    public void ButtonPressed(string name)
    {
        AudioSource audioSource = buttonAudio.GetComponent<AudioSource>();
        AudioClip audioClip = audioSource.clip;
        //audioSource.Play();
        // Debug.Log("Break 1");
        StartCoroutine(HandleButtonClick(audioClip, audioSource, name));
        // Debug.Log("Break 3");

    }
     IEnumerator HandleButtonClick(AudioClip clickSound, AudioSource source, string name)
    {  
        source.Play();
        Debug.Log("Break 2");
        yield return new WaitForSeconds(clickSound.length + 0.2f);
        SceneManager.LoadScene(name);
    }

}
