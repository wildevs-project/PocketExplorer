using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loading : MonoBehaviour
{
    private string toLoad;
    // Start is called before the first frame update
    void Start()
    {
        toLoad = PlayerPrefs.GetString("toLoad");
        SceneManager.LoadScene(toLoad);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
