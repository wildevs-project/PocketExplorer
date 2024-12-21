using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamCaptureCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isInScreen = false;
   // public ButtonControllerOnCollision button;
   public GameObject CaptureObject;
   private Button myButton;
    
    void Start()
    {
          myButton = CaptureObject.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (!isInScreen){
        //      Debug.Log("Animal outside screen");

        // }
    }

    private void FixedUpdate()
    {
        //myButton = CaptureObject.GetComponent<Button>();
        if(!isInScreen)
        {
            myButton.interactable = false;
            Debug.Log("Animal outside screen");
        }
    }

    //private void OnCollisionE
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnedAnimal"))
        {
            isInScreen = true;
            myButton.interactable = true;
            Debug.Log("Animal in screen");
             

        } 
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("SpawnedAnimal"))
        {
            isInScreen = true;
            myButton.interactable = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D other)
    {
         if (other.CompareTag("SpawnedAnimal"))
        {
            isInScreen = false;
            myButton.interactable = false;
            Debug.Log("Animal outside screen");
        } 
    }
}
