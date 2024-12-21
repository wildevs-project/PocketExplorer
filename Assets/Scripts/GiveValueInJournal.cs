using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

//fills the journal with the animal's information (I think)
public class GiveValueInJournal : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Image whereToShowScreenshot;
    //[SerializeField] Text AnimalName;
    public Transform contentPanel; // Parent object for the habitat tags
    public Transform rarityPanel; // parent object for rarity tags
    public GameObject descPanel; // panel to change color
    public TextMeshProUGUI AnimalName;
    public TextMeshProUGUI SciName;
    public TextMeshProUGUI NameAndLocation;
    public TextMeshProUGUI FunFact;

    public TextMeshProUGUI Description;
    public GameObject LowlandRainforest;
    public GameObject CoastalHillForest;
    public GameObject FreshwaterSwampForest;
    public GameObject FreshwaterBodies;
    public GameObject Intertidal;
    public GameObject RockyShore;
    public GameObject SandyShore;
    public GameObject SecondaryForest;
    public GameObject CoralReef;
    public GameObject Mangrove;
    public GameObject Urban;
    public GameObject Marshes;
    private AnimalData thisAnimal;
    public GameObject CommonTag;
    public GameObject UncommonTag;
    public GameObject RareTag;
    private Color rarityColor;
    public GameObject backToGameButton;
    public GameObject dialogBox;
    public void Start()
    {

       if (StaticDataJournal.isTutorial) {
        // set back button inactive
            Debug.Log("Tutorial!!");
            backToGameButton.SetActive(false);
        // popup dialogue box
            dialogBox.SetActive(true);

       }
       else {

            dialogBox.SetActive(false);
       }

       uploadSS();
       uploadAnimal();
       loadHabitatTags();
       

    }

    // Update is called once per frame
    private void uploadSS()
    {
       AnimalData animalData= StaticDataJournal.animal;
       var tex = new Texture2D(1,1); // note that the size is overridden
        tex.LoadImage(animalData.screenShot);
        var myScreenie = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width/2, tex.height/2));
        whereToShowScreenshot.enabled = true;
        whereToShowScreenshot.sprite = myScreenie;
        //Debug.Log(animalData.rarity);
        GameObject animalRarity = assignRarity();
        GameObject rarityButton = Instantiate(animalRarity, rarityPanel.transform);
        RectTransform rectTransform = rarityButton.GetComponent<RectTransform>();
        // Set the anchor to the center-left of the panel
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f); // Anchor to the center
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f); // Anchor to the center
        rectTransform.pivot = new Vector2(0.5f, 0.5f); // Set pivot to the center
        rectTransform.anchoredPosition = Vector2.zero; // Set position to the center
        Image colorPanel = this.descPanel.GetComponent<Image>();
        colorPanel.color = this.rarityColor;

    }

    private GameObject assignRarity()
    {
        AnimalData myAnimal = StaticDataJournal.animal;
        if (6 < myAnimal.rarity && myAnimal.rarity <= 10)
        {
            this.rarityColor = new Color32(83, 212, 255, 255); //common color
            return CommonTag;
        }
        else if(3 < myAnimal.rarity && myAnimal.rarity <= 6)
        {
            this.rarityColor = new Color32(216, 255, 87, 255); //uncommon color
            return UncommonTag;
        }
        else
        {
            this.rarityColor = new Color32(255, 146, 146, 255); //uncommon color
            return RareTag;
        }

    }

    private void uploadAnimal()
    {
         AnimalData myAnimal = StaticDataJournal.animal;
         this.thisAnimal = myAnimal;
         AnimalName.enabled = true;
         AnimalName.text = myAnimal.name;
         NameAndLocation.text = "Name: " + myAnimal.name +"\n\n" + "Location: " + string.Join(", ", myAnimal.location);
         //Location.text = "Location: " + + string.Join(", ", myAnimal.location);
         Description.text = myAnimal.description;
         SciName.text = myAnimal.sciName;
         string [] facts = myAnimal.funFacts;
        //  Random r = new Random();
        //  int rInt = r.Next(0, facts.Length - 1);
         FunFact.text = myAnimal.funFacts[Random.Range(0, facts.Length - 1)];

    }

    private void loadHabitatTags()
    {
        foreach (var habitatTag in StaticDataJournal.animal.ecosystems)
        {
            if (habitatTag == "Lowland rainforest"){
                Instantiate(LowlandRainforest, contentPanel.transform);
            }
            else if(habitatTag == "Mangrove"){
                Instantiate(Mangrove, contentPanel.transform);
            }
            else if(habitatTag == "Coastal hill rainforest"){
                Instantiate(CoastalHillForest, contentPanel.transform);
            }
            else if(habitatTag == "Intertidal"){
                Instantiate(Intertidal, contentPanel.transform);
            }
            else if(habitatTag == "Freshwater swamp forest"){
                Instantiate(FreshwaterSwampForest, contentPanel.transform);
            }
            else if(habitatTag == "Freshwater bodies"){
                Instantiate(FreshwaterBodies, contentPanel.transform);
            }
            else if(habitatTag == "Rocky shore"){
                Instantiate(RockyShore, contentPanel.transform);
            }
            else if(habitatTag == "Sandy shore"){
                Instantiate(SandyShore, contentPanel.transform);
            }
            else if(habitatTag == "Secondary forest"){
                Instantiate(SecondaryForest, contentPanel.transform);
            }
            else if(habitatTag == "Coral reef"){
                Instantiate(CoralReef, contentPanel.transform);
            }
            else if(habitatTag == "Urban"){
                Instantiate(Urban, contentPanel.transform);
            }
             else if(habitatTag == "Marshland"){
                Instantiate(Marshes, contentPanel.transform);
            }
            else{
                // do nothing
            }
            
        }
    }
   
}
