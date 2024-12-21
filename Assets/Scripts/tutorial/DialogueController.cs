using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    private int _index = 0;
    public float Delay;
    public float DialogueSpeed;
    private bool _speaking = false;
    public bool Done = false;
    //public GameObject Yes;
    //private Button _yesButton;
    //public GameObject No;
    //private Button _noButton;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForFirstLine());
         //_yesButton = Yes.GetComponent<Button>();
         //_noButton = No.GetComponent<Button>();
         //_yesButton.interactable = false;
         //_noButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
         if (_index > Sentences.Length - 1) 
        {
            Done = true;
            //_yesButton.interactable = true;
            //_noButton.interactable = true;
        }     
    }

    public void Next()
    {
        Debug.Log("clicked");
        if (_index <= Sentences.Length - 1)
        {
            if (_speaking == true)
            {
                _speaking = false;
                StopCoroutine(WriteSentence());
                DialogueText.text = "";
                DialogueText.text = Sentences[_index];
                _index++;
                Debug.Log(_index);
            } else {
                DialogueText.text = "";
                 StartCoroutine(WriteSentence());
            }
        } 
    }
    

    IEnumerator WaitForFirstLine() 
    {
        yield return new WaitForSeconds(Delay);
        DialogueText.text = "";
        StartCoroutine(WriteSentence());
    }

    IEnumerator WriteSentence()
    {
        _speaking = true;
        foreach(char Character in Sentences[_index].ToCharArray())
        {
            if (_speaking == true) 
            {
                DialogueText.text += Character;
                yield return new WaitForSeconds(DialogueSpeed);
            } else {
                break;
            }
        }
        if (_speaking == true) 
        {
            _speaking = false;
            _index++;
            Debug.Log(_index);

        } 
    } 
}
