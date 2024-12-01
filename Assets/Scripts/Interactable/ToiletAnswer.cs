using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletAnswer : Interactable
{
    [SerializeField]
    private SkibidiQuiz quiz;
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
        quiz.toiletAnswer = promptMessage;
    }
}