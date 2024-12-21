using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasActivator : MonoBehaviour
{
    // Start is called before the first frame update
    //test
    public GameObject gameObject;

    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activate()
    {
        gameObject.SetActive(true);
    }
}
