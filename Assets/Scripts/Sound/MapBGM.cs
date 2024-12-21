using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBGM : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioSource music;

    public void Awake()
    {
        music = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(music);
    }
    void Start()
    {
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
