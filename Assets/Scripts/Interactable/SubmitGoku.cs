using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class SubmitGoku : Interactable
{
    private ScoreManager scoreManager;
    private PlayerMotor playerMotor;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Goku Powers, Activated!");
        scoreManager = FindObjectOfType<ScoreManager>();

        int numFries = scoreManager.getRequiredFries();
        promptMessage = "Don't talk to me unless you have " + numFries + " fries";

        playerMotor = GameObject.Find("FPS").GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    protected override void Interact()
    {
        if(scoreManager.hasWon) {
            promptMessage = "Thanks for the fries huzz";

            SceneManager.LoadScene(2, LoadSceneMode.Additive);
            playerMotor.setUnmoveable();
        } else {
            promptMessage = "You are cooked! You only have " + scoreManager.getNumFries() + " fries"; 
        }

    }    
}
