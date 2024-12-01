using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    private PlayerMotor motor;
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;

    // Public property to expose OnFoot
    public PlayerInput.OnFootActions OnFoot
    {
        get => onFoot;
    }

    private PlayerInput.GameManagementActions gameManagement;

    public PlayerInput.GameManagementActions GameManagement{
        get => gameManagement;
    }

    private PlayerLook look;

    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;   
        gameManagement = playerInput.GameManagement;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();


        // ctx = callback context 
        // ctx calls Jump function
        // performed, started, canceled are the states of the function
        onFoot.Jump.performed += ctx => motor.Jump();

        // Subscribe to the restart action
        gameManagement.Restart.performed += ctx => RestartGame();

        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable() {
        onFoot.Enable();
        gameManagement.Enable();
    }

    private void OnDisable() {
        onFoot.Disable();
        gameManagement.Disable();
    }

    private void RestartGame()
    {
        if (scoreManager != null && scoreManager.hasWon)
        {
            SaveMe[] saveMeObjects = FindObjectsOfType<SaveMe>();

            // Destroy each GameObject that has the SaveMe script attached
            foreach (SaveMe saveMe in saveMeObjects)
            {
                Destroy(saveMe.gameObject);
            }
            SceneManager.LoadScene(0);
        }
    }

}
