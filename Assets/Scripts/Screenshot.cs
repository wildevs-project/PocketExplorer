using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Screenshot : MonoBehaviour, IDataPersistence
{
    // Start is called before the first frame update
    public GameObject UI;
    public GameObject successCanvas;
    public GameObject CamFrame;
    public GameObject dataStorage;
   // private PhotoManager photoManager;
   //[SerializeField] Image whereToShowScreenshot;
   //private StoreSceneData storeData;
  // public Sprite Screenie;
    void Start()
    {
        //successCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ScreenshotCapture()
    {
        yield return new WaitForEndOfFrame();
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();
        byte[] theseBytes = texture.EncodeToPNG();

        Sprite screenshotSprite = Sprite.Create(texture, new Rect(0,0, texture.width, texture.height)
            , new Vector2(0.5f, 0.5f));
        //this.Screenie = screenshotSprite;
        

    //whereToShowScreenshot.enabled = true;
    //whereToShowScreenshot.sprite = screenshotSprite;
        dataStorage.GetComponent<StoreSceneData>().loadScreenshotToJournal(screenshotSprite);
        dataStorage.GetComponent<StoreSceneData>().loadMyAnimal(theseBytes);
        DataPersistenceManager.instance.SaveGame();
        CamFrame.SetActive(true);
        successCanvas.SetActive(true);
    }
    public void TakeScreenshot()
    {
        UI.SetActive(false);
        StartCoroutine("ScreenshotCapture");
    }

    public void LoadData(GameData data) 
    {
        //do nothing
    }

    public void SaveData(ref GameData data)
    {
        data.SavedDictionary = StaticDataJournal.animalDictionary;
    }
}
