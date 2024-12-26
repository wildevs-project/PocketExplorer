using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for scenes that used in both the main game and tutorial
//toggles specified GameObjects' active status depending on whether it is tutorial
public class SetObjActivity : MonoBehaviour
{
    public GameObject [] activeIfTut;
    public GameObject [] inactiveIfTut;

    // Start is called before the first frame update
    void Start()
    {
        if (StaticDataJournal.isTutorial) {
            Debug.Log("Tutorial!");
            foreach (GameObject i in activeIfTut) {
                i.SetActive(true);
            }

            foreach (GameObject i in inactiveIfTut) {
                i.SetActive(false);
            }

        } else {
            foreach (GameObject i in activeIfTut) {
                i.SetActive(false);
            }

            foreach (GameObject i in inactiveIfTut) {
                i.SetActive(true);
            }
       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
