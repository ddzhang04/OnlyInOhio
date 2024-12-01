using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SkibidiQuiz : Interactable
{
    public int questionIdx = 0;
    public ToiletAnswer leftToilet;
    public ToiletAnswer rightToilet;

    public string toiletAnswer = "";

    private bool quizPassed = false;

    [SerializeField]
    private GameObject backdoor;

    [SerializeField]
    private Fry fry;
    
    private string[] questions = {
        "Welcome to the AP Brain Rot Test.",
        "Answer these 5 questions correctly to get positive aura.",
        "Interact with the toilets to answer the questions!",
        "Who rizzed up Level 5 Gyatt Livvy Dunne?",
        "Fill in the blank: Erm, what the ____?",
        "Who is two steps ahead?",
        "What song was played at the Tiktok Rizz Party?",
        "Where was John Pork allegedly murdered?",
        "GGs! You passed the brainrot quiz. Here's a fry"
    };

    private string[] leftToiletText = {
        "Baby Gronk",
        "Alpha",
        "Nico Avocado",
        "FE!N",
        "Detroit",
        ""
    };

    private string[] rightToiletText = {
        "Duke Dennis",
        "Sigma",
        "LeBron James",
        "Carnival",
        "Atlanta",
        ""
    };

    // True is the left most toilet, False is the right most toilet
    private string[] answers = {
        "Baby Gronk", // Baby Gronk
        "Sigma", // Sigma
        "Nico Avocado", // Nico Avocado
        "Carnival", // Carnival
        "Atlanta" // Atlanta
    };

    // Start is called before the first frame update
    void Start()
    {
        promptMessage = questions[questionIdx];
    }

    // Update is called once per frame
    void Update()
    {
        promptMessage = questions[questionIdx];

        if(questionIdx > 2 && questionIdx < 8 && toiletAnswer == answers[questionIdx - 3]) {
            questionIdx++;
            updateText();
        } else if(questionIdx == 8 && !quizPassed) {
            quizPassed = true;  

            backdoor.GetComponent<Animator>().SetBool("quizPassed", quizPassed);
            fry.GetComponent<Animator>().SetBool("fryUnlocked", quizPassed);
        }
    }

    protected override void Interact()
    {
        

        if(questionIdx < 3) {
            questionIdx++;
        }

        updateText();
    }

    private void updateText() {
        if(questionIdx > 2 && questionIdx < 8) {
            leftToilet.promptMessage = leftToiletText[questionIdx - 3];
            rightToilet.promptMessage = rightToiletText[questionIdx - 3];
        }
    }
}
