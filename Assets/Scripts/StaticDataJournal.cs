using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticDataJournal : MonoBehaviour
{
    // Start is called before the first frame update
  public static Sprite  animalScreenshot;
  public static  AnimalData animal;
  public static SerializableDictionary<string, AnimalData> animalDictionary = new SerializableDictionary<string, AnimalData>();
  public static bool isNewGame = true;
 // public static DBLoader staticDBLoader = new DBLoader();
 public static AnimalDatabase allAnimals = new AnimalDatabase();
 public static bool isTutorial = false;
}
