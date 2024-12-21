using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharacterSpawnIn : MonoBehaviour
{
    public GameObject[] Characters;
    private int characterIndex;
    public Transform StartPositionObject;
    public CinemachineVirtualCamera VCam;

    private void Awake() 
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        Vector3 StartPosition = new Vector3(StartPositionObject.position.x, StartPositionObject.position.y, StartPositionObject.position.z);
        GameObject player = Instantiate(Characters[characterIndex], StartPosition, Quaternion.identity);
        VCam.m_Follow = player.transform;
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
