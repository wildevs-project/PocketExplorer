using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour

{
    public float time;
    private TextMeshProUGUI timerText;
    public GameObject UI;
    public GameObject failureCanvas;
    public GameObject CamFrame;
    //public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        failureCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0) 
        {
            UI.SetActive(false);
            CamFrame.SetActive(true);
            failureCanvas.SetActive(true);
        }
        timerText.text = "" + Mathf.Round(time);
    }
}
