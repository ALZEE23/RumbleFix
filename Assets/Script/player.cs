using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class player : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 70.0f;

    public bool turnbase;
    

    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    public Animator lookAnimator;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;

    public SpriteRenderer spriteRenderer;
    public GameObject camera1;
    public GameObject camera2;
    public GameObject turnUi;


    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        lookAnimator = GetComponent<Animator>();
        // Lock cursor
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    void Update()
    {

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        //if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        //{
        //    moveDirection.y = jumpSpeed;
        //}
        //else
        //{
        //    moveDirection.y = movementDirectionY;
        //}


        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);
        
        if (moveDirection.x < 0)
        {
            spriteRenderer.flipX = true;
           
        } else
        {
            spriteRenderer.flipX = false;
        }

        if (moveDirection.x < 0 || moveDirection.x > 0)
        {
            lookAnimator.SetBool("run", true);
        } else
        {
            lookAnimator.SetBool("run", false);
        }

        if(turnbase == true)
        {
            moveDirection.x = 0;
            moveDirection.y = 0;
            spriteRenderer.flipX = true;
            lookAnimator.SetBool("turnbase", true);
             camera1.gameObject.SetActive(false);
            camera2.gameObject.SetActive(true);
            characterController.enabled = false;
            //turnUi.SetActive(true);
        }
        else
        {
            camera1.gameObject.SetActive(true);
            camera2.gameObject.SetActive(false);
            lookAnimator.SetBool("turnbase", false);
            characterController.enabled = true;
            
        }

        // Player and Camera rotation
        //*if (canMove)
        //{
        //    rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        //    rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        //    playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
         //   transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        //}


    }
}