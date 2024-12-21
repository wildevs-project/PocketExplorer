using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class ButtonScr : MonoBehaviour
{
    public AudioClip clickSound;
    public float soundDelay = 0.2f;
    private AudioSource audioSource;
    private Button button;

    // Delegate to hold the method to call
    public GameObject targetObject;
    public string methodName;
    void Start()
    {
        button = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();

        button.onClick.AddListener(() => StartCoroutine(HandleButtonClick()));
    }

    IEnumerator HandleButtonClick()
    {
        if (clickSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSound);
            yield return new WaitForSeconds(clickSound.length + soundDelay);
        }

        PerformButtonAction();
    }

    void PerformButtonAction()
    {
        if (targetObject != null && !string.IsNullOrEmpty(methodName))
        {
            targetObject.SendMessage(methodName, SendMessageOptions.DontRequireReceiver);
        }
    }
}