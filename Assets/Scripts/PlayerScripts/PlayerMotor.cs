using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerMotor : MonoBehaviour
{
    private ScoreManager scoreManager;
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5f;
    public bool isGrounded;
    public float gravity = -9.8f;

    [SerializeField]
    public float jumpHeight = 3f;

    private bool moveable = true;

     
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        scoreManager = GetComponent<ScoreManager>();
    }   

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;

    }

    public void ProcessMove(Vector2 input)
    {
        if(!moveable) {
            return;
        }

        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime; // constant downward force
        
        if(isGrounded && playerVelocity.y < 0) 
        {
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if(!moveable) {
            return;
        }
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    public void setUnmoveable() {
        moveable = false;
    }
}
