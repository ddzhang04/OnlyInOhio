using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

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

    private PlayerLook look;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;   
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        // ctx = callback context 
        // ctx calls Jump function
        // performed, started, canceled are the states of the function
        onFoot.Jump.performed += ctx => motor.Jump();
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
    }

    private void OnDisable() {
        onFoot.Disable();
    }

}
