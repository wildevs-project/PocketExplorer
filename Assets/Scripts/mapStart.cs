using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteKey("spawnPosX");
        PlayerPrefs.DeleteKey("spawnPosY");
        PlayerPrefs.DeleteKey("spawnPosZ");
        PlayerPrefs.DeleteKey("currScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
