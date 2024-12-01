using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int fries = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore() {
        fries++;
        UpdateScoreText();
    }
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Fries: " + fries.ToString();
        }
    }
}
