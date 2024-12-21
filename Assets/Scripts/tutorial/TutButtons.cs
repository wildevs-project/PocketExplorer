using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutButtons : MonoBehaviour
{
    public DialogueController dialogueController;
    public GameObject Yes;
    private Button _yesButton;
    public GameObject No;
    private Button _noButton;

    // Start is called before the first frame update
    void Start()
    {
         _yesButton = Yes.GetComponent<Button>();
         _noButton = No.GetComponent<Button>();
         _yesButton.interactable = false;
         _noButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueController.Done == true)
        {
            _yesButton.interactable = true;
            _noButton.interactable = true;
        }
    }
}
