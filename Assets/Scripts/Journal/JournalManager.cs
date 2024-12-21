using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
public class JournalManager : MonoBehaviour
{
    public Transform contentPanel; // Parent object for the animal entries
    public GameObject animalEntryPrefab; // Prefab for each animal entry
    public Sprite notFoundImage; // The question mark image loaded from resources
    public Sprite foundImage;

    void Start()
    {
        LoadJournal();
    }

    void LoadJournal()
    {
        foreach (var animalEntry in StaticDataJournal.animalDictionary)
        {
            GameObject newEntry = Instantiate(animalEntryPrefab, contentPanel.transform);
            AnimalData animalData = animalEntry.Value;

            Image animalImage = newEntry.transform.Find("AnimalImage").GetComponent<Image>();
            TextMeshProUGUI animalName = newEntry.transform.Find("AnimalName").GetComponent<TextMeshProUGUI>();
            Button infoButton = newEntry.transform.Find("ViewButton").GetComponent<Button>();
            Button panelButton = newEntry.GetComponent<Button>();

            animalName.text = animalData.name;
            if (animalData.isFound)
            {
               // animalImage.sprite = animalData.screenshots[animalData.screenshots.Count - 1];
               panelButton.interactable = true;
               var tex = new Texture2D(1,1); // note that the size is overridden
               tex.LoadImage(animalData.screenShot);
               var myScreenie = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width/2, tex.height/2));
               animalImage.sprite = myScreenie;
               
            }
            else
            {
                animalImage.sprite = notFoundImage;
                panelButton.interactable = false;
            }

            infoButton.onClick.AddListener(() => OpenAnimalInfo(animalData));
        }
    }

    void OpenAnimalInfo(AnimalData animalData)
    {
        if (animalData.isFound)
        {
            // Load AnimalInfoScene and pass the relevant animal data
            StaticDataJournal.animal = animalData;
            UnityEngine.SceneManagement.SceneManager.LoadScene("Journal");
        }
    }
}
