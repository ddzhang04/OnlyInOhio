using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private float detectionRadius = 1f; // Radius to check
    public LayerMask caseohLayer;       // Layer mask for objects with the "Caseoh" layer


    private bool caseohTouched = false;
    public bool CaseohTouched {
        get => caseohTouched;
    }

    private PlayerMotor playerMotor;

    void Start() {
        playerMotor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        // Find all colliders in the detection radius
        Collider[] nearbyObjects = Physics.OverlapSphere(transform.position, detectionRadius, caseohLayer);

        foreach (var obj in nearbyObjects)
        {
            // Calculate distance in the YZ plane
            Vector3 objectPosition = obj.transform.position;
            Vector3 playerPosition = transform.position;

            // Check only the YZ plane
            float distanceInYZ = Vector2.Distance(
                new Vector2(playerPosition.y, playerPosition.z),
                new Vector2(objectPosition.y, objectPosition.z)
            );

            if (distanceInYZ <= detectionRadius && !caseohTouched)
            {
                caseohTouched = true;
                playerMotor.setUnmoveable();

                SceneManager.LoadScene(3, LoadSceneMode.Additive);
            }
        }
    }
}
