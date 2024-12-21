using System.Collections;
using System.Collections.Generic;
//using UnityEngine;

[System.Serializable]
public class AnimalData
{
   public string name;  
   public string spawnTag1;
   public string spawnTag2;  
   public string type;
   public string sciName;
   public string description;  
   public string[] ecosystems;
   public int rarity;
   public string[] funFacts;  
   public string[] location;
   public string spritePath;
   public bool isFound;
   public byte[] screenShot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override string ToString()
    {
        return "\n" + this.name + "\n" + this.spawnTag1 + "\n" + this.spawnTag2 + "\n"
        + "\n" +  this.type + "\n" + this.sciName + "\n" +this.description + "\n" + this.ecosystems + 
        "\n" + this.rarity + "\n" + this.location + "\n" + this.spritePath + "\n" + this.isFound + "\n" + this.screenShot;
    }
}