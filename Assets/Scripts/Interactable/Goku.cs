using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public AudioClip interactionSound; // Drag your audio clip here in the Inspector
    private AudioSource audioSource;

    private bool isPlayerNearby = false; // Tracks if the player is within range

    void Start()
    {
        // Get or add an AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the interaction sound if not already set
        if (interactionSound != null)
        {
            audioSource.clip = interactionSound;
        }
    }

    void Update()
    {
        // Check for interaction input
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            InteractWithObject();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Detect if the player enters the trigger zone
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            Debug.Log("Player is near the object.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Detect if the player leaves the trigger zone
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            Debug.Log("Player left the object.");
        }
    }

    void InteractWithObject()
    {
        // Play the sound
        if (audioSource != null && interactionSound != null)
        {
            audioSource.Play();
        }

        // Add interaction logic here
        Debug.Log("Object interacted with!");
    }
}
