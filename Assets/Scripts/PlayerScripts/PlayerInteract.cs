using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    // Start is called before the first frame update

    [SerializeField]
    private float distance = 3f;

    [SerializeField]
    private LayerMask mask; // This is to check which layer to interact with 

    private PlayerUI playerUI;

    private InputManager inputManager;
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Delete text every frame
        playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        RaycastHit hitInfo; // stores collision info

        // out key word is similar to passing by reference, so that the Raycast function
        // updates the hitInfo variable 

        // Added Layer 6 in Unity - Interactable
        // Assigned the Doors the Interactable Layer
        if(Physics.Raycast(ray, out hitInfo, distance, mask)) {

            // If interacting with an interactable object
            if(hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
 
                // Update text 
                playerUI.UpdateText(interactable.promptMessage);
            
                if (inputManager.OnFoot.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            // Parent is interactable
            } else if (hitInfo.collider.GetComponentInParent<Interactable>()) {
                Interactable interactable = hitInfo.collider.GetComponentInParent<Interactable>();
 
                // Update text 
                playerUI.UpdateText(interactable.promptMessage);
            
                if (inputManager.OnFoot.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
