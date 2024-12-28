using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButSavePos : OptionsScreen
{
    public CharacterSpawnIn1 CharSpawn;
    public string currScene;
    public GameObject waterButton;
    public GameObject grassButton;
    public GameObject treeButton;

    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        currScene = scene.name;
        PlayerPrefs.SetString("currScene", currScene);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    public override void Back() {
        GameObject player = CharSpawn.player;
        Transform playerTransform = player.GetComponent<Transform>();
        if (titleScene == "SSCapGrass" || titleScene =="tut SSCapGrass")
        {
            ButtonPressed(titleScene, grassButton);
        }
        else if (titleScene == "SSCapWater"|| titleScene =="tut SSCapWater")
        {
            ButtonPressed(titleScene, waterButton);
        }
        else if (titleScene == "SSCapTree"|| titleScene =="tut SSCapTree")
        {
            ButtonPressed(titleScene, treeButton);
        }
        else
        {
            ButtonPressed(titleScene, buttonAudio);
        }

        PlayerPrefs.SetFloat("spawnPosX", playerTransform.position.x);
        PlayerPrefs.SetFloat("spawnPosY", playerTransform.position.y);
        PlayerPrefs.SetFloat("spawnPosZ", playerTransform.position.z);
    }
    public void ButtonPressed(string name, GameObject buttonAudio)
    {
        AudioSource audioSource = buttonAudio.GetComponent<AudioSource>();
        AudioClip audioClip = audioSource.clip;
        //audioSource.Play();
        // Debug.Log("Break 1");
        StartCoroutine(HandleButtonClick(audioClip, audioSource, name));
        // Debug.Log("Break 3");

    }
     IEnumerator HandleButtonClick(AudioClip clickSound, AudioSource source, string name)
    {  
        source.Play();
        Debug.Log("Break 2");
        yield return new WaitForSeconds(clickSound.length + 0.2f);
        SceneManager.LoadScene(name);
    }
}
