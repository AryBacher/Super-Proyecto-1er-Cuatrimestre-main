 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AparecePiso : MonoBehaviour
{

    public GameObject ObjectToClone;
    System.Random guido = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        int ary = guido.Next(0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
