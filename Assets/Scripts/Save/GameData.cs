using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData 
{
    public DBLoader dBLoader;
    public SerializableDictionary<string, AnimalData> SavedDictionary;

    public GameData() 
    {
        this.SavedDictionary = StaticDataJournal.animalDictionary;
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

}
