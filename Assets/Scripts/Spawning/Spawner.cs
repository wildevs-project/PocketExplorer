using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SpawnSprite;
    //private TreeSpawnAreas[] _spawnZones;
    private GameObject[] _spawnZones;
    
    public float StartAfter = 0.5f;
    public float InBetweenTime = 1;
    public string Tag = "TreeSpawnAreas";
  //  private List<GameObject> spawnedObjects = new List<GameObject>();
     public float DestroyAfter = 5f;
    public Transform parent;
    //"TreeSpawnAreas", 
    void Start()
    {
       // parent = SpawnSprite.GetComponentInParent<Transform>();
        string tag = Tag;
        _spawnZones = GameObject.FindGameObjectsWithTag(tag);
        InvokeRepeating("Spawn", StartAfter, InBetweenTime);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void Spawn()
    {
        if (_spawnZones.Length == 0)
        {
            Debug.LogError("Spawn zones array is empty.");
            return;
        }

        GameObject selectedZone = _spawnZones[Random.Range(0, _spawnZones.Length)];

        if (selectedZone == null)
        {
            Debug.LogError("Selected spawn zone is null.");
            return;
        }

        SpawnAreas spawnArea = selectedZone.GetComponent<SpawnAreas>();

        if (spawnArea == null)
        {
            Debug.LogError("Selected spawn zone does not have a TreeSpawnAreas component.");
            return;
        }

        Vector2 spawnPoint = spawnArea.getRandomPoint();

        if (spawnPoint == Vector2.zero)
        {
            Debug.LogError("Failed to get a valid spawn point.");
            return;
        }

        //Instantiate(SpawnSprite, spawnPoint, Quaternion.identity, parent);
       // Instantiate(SpawnSprite, _spawnZones[Random.Range(0, _spawnZones.Length)].GetComponent<TreeSpawnAreas>().getRandomPoint(), Quaternion.identity);
        GameObject spawnedObject = Instantiate(SpawnSprite, spawnPoint, Quaternion.identity, parent);
       // spawnedObjects.Add(spawnedObject); // Add the spawned object to the list
        Destroy(spawnedObject, DestroyAfter);
    }
    
}
