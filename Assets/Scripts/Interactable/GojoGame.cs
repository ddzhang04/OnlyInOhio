using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;

public class GojoGame : Interactable
{

    private int dialogueIdx = 0;

    [SerializeField]
    private float timeGoal = 5f;
    
    private float timeRemaining;
    private bool timerRunning = false;

    private int backshotCount = 0;

    [SerializeField]
    private int goalBackshots = 20;

    public bool hasWon = false;

    private string[] dialogue;
    public TextMeshProUGUI timerText;

    public Fry fry1;
    public Fry fry2;

    // Start is called before the first frame update
    void Start()
    {
        

        dialogue = new string[5];   
        dialogue[0] = "Hi its me Nah I'd Win!";
        dialogue[1] = "I'll give u fries if u give me backshots";
        dialogue[2] = "Give me " + goalBackshots +  " backshots in 5 seconds senpai";
        dialogue[3] = "Thanks for the hollow backshots, brother.";

        timeRemaining = timeGoal;
        updateText();
    }

    // Update is called once per frame
    void Update()
    {
         if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                if(backshotCount >= goalBackshots) {
                    hasWon = true;
                    backshotCount = 0;
                    timerRunning = false;
                    dialogueIdx++;
                    animateFries();
                    updateText();
                } else {
                    timeRemaining -= Time.deltaTime;
                }
                
                UpdateTimerDisplay();
            }
            else
            {
                timeRemaining = timeGoal;
                timerRunning = false;

                backshotCount = 0;
                timerText.text = "";
            }
        }

        if(hasWon) {
            timerText.text = "";
        }
    }

    protected override void Interact()
    {
        if(dialogueIdx < 2) {
            dialogueIdx++;
            updateText();
        } else if(!timerRunning && !hasWon) {
            timerRunning = true; 
            UpdateTimerDisplay();
        } else if (timerRunning) {
            backshotCount++;
        }
    }

    private void UpdateTimerDisplay()
    {
        timerText.text = $"Time: {timeRemaining:F2}\nBackshots: {backshotCount}";
    }

    private void updateText() 
    {
        promptMessage = dialogue[dialogueIdx];
    }

    private void animateFries() 
    {
        fry1.GetComponent<Animator>().SetBool("hasWon", hasWon);
        fry2.GetComponent<Animator>().SetBool("hasWon", hasWon);
    } 
}
