using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapNext : OptionsScreen
{
    public string loadingScene;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteKey("toLoad");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Back() 
    {
        PlayerPrefs.SetString("toLoad", titleScene);
        ButtonPressed(loadingScene);
        //SceneManager.LoadScene(loadingScene);
    }
    
}
