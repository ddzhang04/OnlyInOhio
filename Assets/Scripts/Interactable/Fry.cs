using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fry : Interactable
{

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
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.AddScore();
        }

        Destroy(gameObject);
    }
}
