using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class LoadGame : MonoBehaviour
{
    public string RealGame;
    public string NewGame;
    //private string NextScene;
    public DBLoader dBLoader;
    public GameObject LoadButton;
    // Start is called before the first frame update
    public GameObject buttonAudio;
    void Start()
    {
        //LoadNewDict();
        if (PlayerPrefs.HasKey("SelectedCharacter"))
        {
            Debug.Log("saved gender");
            DataPersistenceManager.instance.LoadGame();
            LoadButton.SetActive(true);
            //SceneManager.LoadScene(RealGame);
        }
        else 
        {
            //next time try to make a popup appear 
            DataPersistenceManager.instance.NewGame(); 
            LoadButton.SetActive(false);
            
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void New()
    {
        DataPersistenceManager.instance.NewGame();
        //LoadNewDict();
        ButtonPressed(NewGame);
        //SceneManager.LoadScene(NewGame);
    }

    public void LoadNewDict()
    {
         dBLoader.LoadDB();
        //StaticDataJournal.allAnimals = dBLoader.animalDatabase;
             if (dBLoader.animalDatabase.animals.Count == 0)
            {
                Debug.Log("Database is empty");
            } else {
                Debug.Log("JournalDatabase loaded successfully.");
                StaticDataJournal.allAnimals = dBLoader.animalDatabase;
                foreach (var animal in dBLoader.animalDatabase.animals)
                {
                    Debug.Log(animal.ToString());
                }
            }
        dBLoader.LoadDictionary();
        foreach (var animal in StaticDataJournal.animalDictionary)
                {
                    Debug.Log("DicName: " + animal.ToString());
                }
    }

    public void Load() 
    {
        ButtonPressed(RealGame);
        //SceneManager.LoadScene(RealGame);
    }

    public void ButtonPressed(string name)
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
