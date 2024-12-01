using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granola : Interactable
{
    // Start is called before the first frame update
    private GameObject player;

    [SerializeField]
    private float speedIncrease = 1f;

    void Start()
    {
        promptMessage = "Eat me for speed";
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact()
    {

        if (player != null)
        {
            PlayerMotor playerMotor = player.GetComponent<PlayerMotor>();
            playerMotor.speed += speedIncrease;
        }
        Destroy(gameObject);
    }
}
