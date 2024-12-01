using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int fries = 0;

    [SerializeField]
    private int friesToWin = 10;
    public bool hasWon = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    public int getRequiredFries() {
        return friesToWin;
    }

    public int getNumFries() {
        return fries;
    }

    public void AddScore() {
        fries++;

        if(fries >= friesToWin) {
            hasWon = true; 
        }
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
