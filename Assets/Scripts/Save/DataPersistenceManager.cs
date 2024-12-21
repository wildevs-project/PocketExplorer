using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
   [Header("File Storage Config")]
   [SerializeField] private string fileName; 
   private FileDataHandler dataHandler;
   private GameData gameData; 
   private List<IDataPersistence> dataPersistenceObjects;
   public static DataPersistenceManager instance {get; private set; }
   public DBLoader dBLoader;

   private void Awake()
   {
    if (instance != null)
    {
        Debug.LogError("Found more than one Data Persistence Manager in the scene.");
    }
    instance = this;
    this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    this.dataPersistenceObjects = FindAllDataPersistenceObjects();
    Debug.Log("qqq");
   }

   private void Start()
   {
    //this.gameData = new GameData();
    this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    Debug.Log("ttttt");
    this.dataPersistenceObjects = FindAllDataPersistenceObjects();
   }

   public void LoadNewDict()
    {
        StaticDataJournal.animalDictionary.Clear();
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

   public void NewGame()
   {
        this.gameData = new GameData();
        LoadNewDict();
        Debug.Log("new dict fully loaded");
   }

   public void LoadGame()
   {
        //load data from file
        Debug.Log("poo");
        this.gameData = this.dataHandler.Load();
        Debug.Log("pee");

        if (this.gameData == null)
        {
            Debug.Log("No data was found. Initializing data to defaults.");
            NewGame();
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

   }

   public void SaveGame()
   {
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }

        foreach (var animal in gameData.SavedDictionary)
                {
                    Debug.Log("Saved DicName: " + animal.ToString());
                }
        dataHandler.Save(gameData);
   }

   private List<IDataPersistence> FindAllDataPersistenceObjects()
   {
    IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
    return new List<IDataPersistence>(dataPersistenceObjects);
   }

}
