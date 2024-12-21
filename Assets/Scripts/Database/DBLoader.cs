using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBLoader : MonoBehaviour
{
    public AnimalDatabase animalDatabase;
    public List<AnimalData> newList;
    // Start is called before the first frame update
    void Start()
    {
        LoadDB();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadDB() 
    {
    
        TextAsset jsonData = Resources.Load<TextAsset>("JournalDatabase");
        if (jsonData == null)
        {
            Debug.LogError("Json file not found in Resources folder.");
        } else {
            Debug.Log("AnimalDatabase loaded part 1.");
        }
        //Debug.Log("JSON Content: "+ jsonData.text);

        animalDatabase = JsonUtility.FromJson<AnimalDatabase>(jsonData.text);
       // animalDatabase.animals.ForEach(animal => Debug.Log(animal.toString));
        if (animalDatabase == null)
        {
            Debug.LogError("Failed to deserialize JSON to AnimalDatabase.");
        } else {
            Debug.Log("AnimalDatabase loaded successfully.");
        }
        // foreach (var animal in animalDatabase.animals)
        // {
        //     Debug.Log(animal.ToString());
        // }

        // newList = animalDatabase.animals.FindAll(animal => animal.spawnTag1 == "Grass" || animal.spawnTag2 == "Tree");

        //  if (newList == null || newList.Count == 0)
        // {
        //     Debug.LogError("Failed to deserialize JSON to AnimalDatabase.");
        // } else {
        //     foreach (var animal in newList)
        //     {
        //         Debug.Log("Yay" + "/n" + animal.ToString());
        //     }
        // }

    }

    public List<AnimalData> GetAnimalsByTag(string tag)
    {
       // List<AnimalData> newList = animalDatabase.animals.FindAll(animal => animal.spawnTag1 == tag || animal.spawnTag2 == tag);
       string Tag = tag;
       return animalDatabase.animals.FindAll(animal => animal.spawnTag1 == Tag || animal.spawnTag2 == Tag);
    }
    public void LoadDictionary(){
        //Sprite notFoundImg = Resources.Load<Texture2D>();
        foreach (var animal in animalDatabase.animals)
        {
            StaticDataJournal.animalDictionary.Add(animal.name, animal);
        }
    }
}