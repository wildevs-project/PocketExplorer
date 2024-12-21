using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AnimalSpawner : MonoBehaviour
{
    public string tag;
    public DBLoader dBLoader;
    // Start is called before the first frame update
    public GameObject Background;
    private GameObject animalPrefab;
    public GameObject dataStorage;

    void Start()
    {
        string Tag = this.tag;
        // DBLoader thisLoader = this.dBLoader;
        // thisLoader.LoadDB();
        // if (thisLoader.animalDatabase.animals.Count == 0)
        // {
        //     Debug.LogError("Database is empty");
        // } else {
        //     Debug.Log("SpawnedAnimal loaded successfully.");
        //     foreach (var animal in thisLoader.animalDatabase.animals)
        //     {
        //         Debug.Log(animal.ToString());
        //     }
        // }
         if (StaticDataJournal.animalDictionary.Count == 0)
        {
            Debug.LogError("Database is empty");
        } else {
            Debug.Log("SpawnedAnimal loaded successfully.");
            foreach (KeyValuePair<string, AnimalData> pair in StaticDataJournal.animalDictionary)
            {
                Debug.Log(pair.Value.ToString());
            }
        }

        string currLocation = PlayerPrefs.GetString("currScene");
        if (currLocation == "tut Bishan Park") {
            currLocation = "Bishan Park";
            StaticDataJournal.isTutorial = true;
        }
        currLocation = (currLocation == "tut Bishan Park") ? "Bishan Park" : currLocation;
       // List<AnimalData> filteredByTag = thisLoader.GetAnimalsByTag(Tag);
       List<AnimalData> filteredByTag = StaticDataJournal.animalDictionary.Values.Where(animal => animal.spawnTag1 == Tag || animal.spawnTag2 == Tag).ToList();
       List<AnimalData> filteredByLocation = filteredByTag.Where(animal => animal.location.Contains(currLocation) == true).ToList();
         if (filteredByLocation.Count == 0)
        {
            Debug.Log("Nothing in the filtered list :(");
        } else {
            foreach (var animal in filteredByLocation)
            {
                Debug.Log("Yay" + "/n" + animal.ToString());
            }
        }

        AnimalData[] animalArr = filteredByLocation.ToArray();
        AnimalData selectedAnimal = animalArr[Random.Range(0, animalArr.Length)];
        dataStorage.GetComponent<StoreSceneData>().loadAnimalToJournal(selectedAnimal);
        //
        string path = selectedAnimal.spritePath;
        Debug.Log("Sprite path is " + path);
       // GameObject animalPrefab = (GameObject) Resources.Load(path, typeof(GameObject));
      //  GameObject animalPrefab = Instantiate(Resources.Load(path, typeof(GameObject))) as GameObject;
     //   UnityEngine.Object animalPrefab = Resources.Load(path, typeof(UnityEngine.Object));
       //UnityEngine.GameObject animalPrefab = Instantiate(Resources.Load(path, typeof(UnityEngine.Object))) as GameObject;
      // var animalGuy = Resources.Load(path);
     //  GameObject animalPrefab = animalGuy as GameObject;
     animalPrefab = Resources.Load<GameObject>(path);
        if (animalPrefab == null)
        {
            Debug.LogError("animalPrefab is null.");
            return;
        }
       // Object o = Instantiate(animalPrefab, new Vector3(0, 0, 0), Quaternion.identity);
       Vector2 spawnPoint = this.Background.GetComponent<SpawnAreas>().getRandomPoint();
      Instantiate(animalPrefab, spawnPoint, Quaternion.identity);
     // GameObject go = Instantiate (animalPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
