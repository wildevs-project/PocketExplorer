using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharacterSpawnIn1 : MonoBehaviour
{
    public GameObject[] Characters;
    private int characterIndex;
    public Transform StartPositionObject;
    private float spawnPosX;
    private float spawnPosY;
    private float spawnPosZ;
    public CinemachineVirtualCamera VCam;
    public GameObject player;

    private void Awake() 
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        spawnPosX = PlayerPrefs.GetFloat("spawnPosX", StartPositionObject.position.x);
        spawnPosY = PlayerPrefs.GetFloat("spawnPosY", StartPositionObject.position.y);
        spawnPosZ = PlayerPrefs.GetFloat("spawnPosZ", StartPositionObject.position.z);
        Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, spawnPosZ);
        player = Instantiate(Characters[characterIndex], spawnPosition, Quaternion.identity);
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
