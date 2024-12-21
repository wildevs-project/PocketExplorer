using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TwoScenesSSCap : NavigateToTwoScenes
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void GoToScene1() {
        firstScene = PlayerPrefs.GetString("currScene");
        PlayerPrefs.SetString("toLoad", firstScene);
        ButtonPressed("loading");
       // SceneManager.LoadScene("loading");
    }

    

}
