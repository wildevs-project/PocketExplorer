using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveOnButtonPress : MonoBehaviour
{
    public GameObject obj;
    private Transform currPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void remove()
    {
        currPos = obj.GetComponent<Transform>(); 
        currPos.position = new Vector3(-0.75f, 3.31f, 0);
    }
}
