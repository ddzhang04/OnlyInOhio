using System.Collections;
using System.Collections.Generic;
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
    private AudioSource audioSource; // Reference to the AudioSource component

    [SerializeField]
    private AudioClip wrongAnswerClip; // The sound to play when the answer is wrong

    private bool wrongAnswerSoundPlayed = false; // Prevents repeated playback of the wrong answer sound

    private string[] questions = {
        "Welcome to the AP Brain Rot Test.",
        "Answer these 5 questions correctly to get positive aura.",
        "Interact with the toilets to answer the questions!",
        "Who rizzed up Level 5 Gyatt Livvy Dunne?",
        "Fill in the blank: Erm, what the ____?",
        "Who is two steps ahead?",
        "What song was played at the Tiktok Rizz Party?",
        "Where was John Pork allegedly murdered?",
        "GGs! You passed the brainrot quiz"
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

    // Correct answers
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

        if (questionIdx > 2 && questionIdx < 8)
        {
            // Check if the answer is correct
            if (toiletAnswer == answers[questionIdx - 3])
            {
                questionIdx++;
                StartCoroutine(DelayAnswerDisplay(1f)); // 1-second delay before showing answers
                wrongAnswerSoundPlayed = false; // Reset the flag for the next question
                toiletAnswer = ""; // Clear the answer to avoid reuse
            }
            else if (toiletAnswer != "" && toiletAnswer != answers[questionIdx - 3] && !wrongAnswerSoundPlayed)
            {
                // Play wrong answer sound only once per wrong answer
                PlayWrongAnswerSound();
                wrongAnswerSoundPlayed = true;
            }
        }
        else if (questionIdx == 8 && !quizPassed)
        {
            quizPassed = true;

            // Play success animation or sound for passing the quiz
            backdoor.GetComponent<Animator>().SetBool("quizPassed", quizPassed);

            // Clear the text above the toilets after the quiz is complete
            HideAnswers();
        }
    }

    protected override void Interact()
    {
        if (questionIdx < 3)
        {
            questionIdx++;
        }

        updateText();
    }

    // Coroutine to add a delay before showing the answers
    private IEnumerator DelayAnswerDisplay(float delayTime)
    {
        // Wait for the specified delay time (1 second)
        yield return new WaitForSeconds(delayTime);

        // After the delay, update the toilet answer prompts
        updateText();
    }

    private void updateText()
    {
        if (questionIdx > 2 && questionIdx < 8)
        {
            leftToilet.promptMessage = leftToiletText[questionIdx - 3];
            rightToilet.promptMessage = rightToiletText[questionIdx - 3];
        }
    }

    // Method to play the wrong answer sound
    private void PlayWrongAnswerSound()
    {
        if (audioSource != null && wrongAnswerClip != null)
        {
            audioSource.PlayOneShot(wrongAnswerClip); // Play the sound when the player answers incorrectly
        }
    }

    // Method to clear the text above the toilets after the quiz is complete
    private void HideAnswers()
    {
        if (leftToilet != null)
        {
            leftToilet.promptMessage = ""; // Clear the text above the left toilet
        }

        if (rightToilet != null)
        {
            rightToilet.promptMessage = ""; // Clear the text above the right toilet
        }
    }
}
