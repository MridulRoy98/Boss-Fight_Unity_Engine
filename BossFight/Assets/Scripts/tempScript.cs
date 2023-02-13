using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempScript : MonoBehaviour
{
    public GameObject tempObject;
    void Awake()
    {
        
        Debug.Log(tempObject.name.ToString());
    }
}
