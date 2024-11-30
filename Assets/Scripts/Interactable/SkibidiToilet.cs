using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkibidiToilet : Interactable
{
    [SerializeField]
    private GameObject toiletSign;

    private bool signSpawned = false;
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
        if(!signSpawned) {
            Debug.Log("Hello"); 
            signSpawned = true;
            toiletSign.GetComponent<Animator>().SetBool("isRise", signSpawned);
        }
        
    }
}
