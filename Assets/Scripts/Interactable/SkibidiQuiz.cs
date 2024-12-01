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
    private Fry fry;

    [SerializeField]
    private AudioSource audioSource; // Reference to the AudioSource component

    [SerializeField]
    private AudioClip wrongAnswerClip; // The sound to play when the answer is wrong

    [SerializeField]
    private AudioClip correctAnswerClip; // Optional sound for the correct answer

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

    private string[] answers = {
        "Baby Gronk",
        "Sigma",
        "Nico Avocado",
        "Carnival",
        "Atlanta"
    };

    void Start()
    {
        // Ensure the AudioSource is assigned
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                Debug.LogError("AudioSource component is missing on SkibidiQuiz object.");
            }
        }

        promptMessage = questions[questionIdx];
    }

    void Update()
    {
        promptMessage = questions[questionIdx];

        if (questionIdx > 2 && questionIdx < 8)
        {
            HandleQuestion();
        }
        else if (questionIdx == 8 && !quizPassed)
        {
            CompleteQuiz();
        }
    }

    private void HandleQuestion()
    {
        if (toiletAnswer == answers[questionIdx - 3])
        {
            PlayCorrectAnswerSound();
            questionIdx++;
            StartCoroutine(DelayAnswerDisplay(1f)); // 1-second delay before showing answers
            toiletAnswer = ""; // Clear answer to avoid reuse
        }
        else if (!string.IsNullOrEmpty(toiletAnswer) && toiletAnswer != answers[questionIdx - 3])
        {
            PlayWrongAnswerSound();
            toiletAnswer = ""; // Clear answer to prevent repeated wrong triggers
        }
    }

    private void CompleteQuiz()
    {
        quizPassed = true;
        backdoor.GetComponent<Animator>().SetBool("quizPassed", quizPassed);
        fry.GetComponent<Animator>().SetBool("fryUnlocked", quizPassed);
        HideAnswers();
    }

    protected override void Interact()
    {
        if (questionIdx < 3)
        {
            questionIdx++;
            updateText();
        }
    }

    private IEnumerator DelayAnswerDisplay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
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

    private void PlayWrongAnswerSound()
    {
        if (audioSource != null && wrongAnswerClip != null)
        {
            audioSource.PlayOneShot(wrongAnswerClip);
        }
        else
        {
            Debug.LogWarning("Wrong answer clip or AudioSource is missing.");
        }
    }

    private void PlayCorrectAnswerSound()
    {
        if (audioSource != null && correctAnswerClip != null)
        {
            audioSource.PlayOneShot(correctAnswerClip);
        }
        else
        {
            Debug.LogWarning("Correct answer clip or AudioSource is missing.");
        }
    }

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
