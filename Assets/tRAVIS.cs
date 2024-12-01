using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class tRAVIS : Interactable
{
    private ScoreManager scoreManager;
    private PlayerMotor playerMotor;

    // Start is called before the first frame update
    void Start()
    {
        promptMessage = "WATCH MY FORNITE CONCERT FE!N ";
    }

    // Update is called once per frame
    void Update()
    {
    }

    protected override void Interact()
    {
       
    Application.OpenURL("https://www.youtube.com/watch?v=wYeFAlVC8qU");
     

    }    
}
