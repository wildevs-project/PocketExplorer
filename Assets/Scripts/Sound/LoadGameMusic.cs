using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameMusic : MonoBehaviour
{
    // Start is called before the first frame update
    public string nameStop;
    public string nameSelf;
    //private bool isPlaying = false;
    void Start()
    {
        string tag = nameStop;
        if (GameObject.FindGameObjectsWithTag(tag) != null) {
            
            GameObject[] BgmStuff = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject g in BgmStuff)
            {
                Destroy(g);
            }
        }
        string myTag = nameSelf;
        if (GameObject.FindGameObjectsWithTag(myTag) != null) {
            
            GameObject[] myStuff = GameObject.FindGameObjectsWithTag(myTag);
            if (myStuff.Length > 1){
                Destroy(myStuff[1]);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
