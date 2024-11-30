using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet : Interactable
{
    [SerializeField]
    private GameObject SkibidiObject;
    private bool skibidiCalled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact()
    {
        if(!skibidiCalled) {
            skibidiCalled = true;
            Debug.Log("Clicked!");

        }
    }
}
