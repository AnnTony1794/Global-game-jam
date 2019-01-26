using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInput : MonoBehaviour
{

    public float InputX;
    public float InputZ;
    public Vector3 desiredMoveDirection;
    public bool blockRotationPlayer;
    public float desireRotationSpeed;
    public Animator anim;
    public float Speed;
    public float allowPlayerRotation;
    public Camera cam;
    public CharacterController controller;
    public bool isGrounded;
    private float verticalVel;
    private Vector3 moveVector;

    // Start is called before the first frame update
    void Start()
    {
        anim = new Animator();
        cam = new Camera();
        controller = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        InputMagnitude();
        isGrounded = controller.isGrounded;
        if (isGrounded)
        {
            verticalVel -= 0;
        }
        else
        {
            verticalVel -= 2;
        }
        moveVector = new Vector3(0, verticalVel, 0);
        controller.Move(moveVector);




    }

    void PlayerMovementAndRotation()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        var camera = Camera.main;
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        desiredMoveDirection = forward * InputZ + right * InputX;
        if (!blockRotationPlayer)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desireRotationSpeed);
        }

    }


    void InputMagnitude()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        // anim.SetFloat("InputZ", InputZ, 0.0f, Time.deltaTime * 2f);
        // anim.SetFloat("InputX", InputX, 0.0f, Time.deltaTime * 2f);



        if (Speed > allowPlayerRotation)
        {
            // anim.SetFloat("InputMagnitude", Speed, 0.0f, Time.deltaTime);
            PlayerMovementAndRotation();
        }
        else
        {
            // anim.SetFloat("InputMagnitude", Speed, 0.0f, Time.deltaTime);
            
        }
    }
}
