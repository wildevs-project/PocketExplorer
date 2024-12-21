using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreSceneData : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AnimalData animalDataToSend;
    [SerializeField] Sprite screenshotToSend;
    void Start()
    {
       // loadScreenshotToJournal();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadScreenshotToJournal(Sprite myScreenshot)
    {
        //animalData animaldataToKeep = animalData;
        this.screenshotToSend = myScreenshot;
        StaticDataJournal.animalScreenshot = this.screenshotToSend;
    }

    public void loadAnimalToJournal(AnimalData myAnimal){
        this.animalDataToSend = myAnimal;
        StaticDataJournal.animal = this.animalDataToSend;
         Debug.Log("ANIMAL ADDED");
    }

    public void loadMyAnimal(byte[] myBytes){
        this.animalDataToSend.isFound = true;
        this.animalDataToSend.screenShot = myBytes;
        StaticDataJournal.animalDictionary.Remove(this.animalDataToSend.name);
        StaticDataJournal.animalDictionary.Add(this.animalDataToSend.name, this.animalDataToSend);
        Debug.Log("ANIMAL ADDED TO DICT! :)");
        foreach (var animal in StaticDataJournal.animalDictionary)
                {
                    Debug.Log("DicName: " + animal.ToString());
                }
    }
}
