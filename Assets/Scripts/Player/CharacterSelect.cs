using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] skins;
    public int SelectedCharacter;
    public AudioManager audioMan;

    private void Awake() 
    {
        PlayerPrefs.DeleteAll();
        //^deletes all save data for new game. 
        //this means currently character select only happens when a new game is made
        //seeing the character select scene indicates that all game data is wiped and a new game is started.
        //we could shift this functionality elsewhere but rn not necessary
        SelectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        PlayerPrefs.SetInt("SelectedCharacter", SelectedCharacter);
        foreach(GameObject player in skins)
            player.SetActive(false);
        skins[SelectedCharacter].SetActive(true);
    }
    
    public void NextChar()
    {
        audioMan.ButtonPlay();
        skins[SelectedCharacter].SetActive(false);
        SelectedCharacter++;
        if(SelectedCharacter == skins.Length) 
            SelectedCharacter = 0;
        skins[SelectedCharacter].SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter", SelectedCharacter);
    }

    public void PrevChar()
    {
        audioMan.ButtonPlay();
        skins[SelectedCharacter].SetActive(false);
        SelectedCharacter--;
        if(SelectedCharacter == -1) 
            SelectedCharacter = skins.Length - 1;
        skins[SelectedCharacter].SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter", SelectedCharacter);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
