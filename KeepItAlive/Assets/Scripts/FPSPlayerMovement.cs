using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class FPSPlayerMovement : MonoBehaviour
{
    [Header("Properties")]
    public float speed = 12f;
    public float gravity = 9.81f;

    [Header("Jump Settings")]
    public bool CanJump;
    public float JumpHeight = 3f;

    [Header("Sprint Settings")]
    public bool CanSprint;
    public float Multiplier = 1.2f;

    [Header("Ground Settings")]
    public float GroundDistance = 0.5f;
    public LayerMask GroundMask;

    [Header("References")]
    public CharacterController controller;
    public Transform GroundCheck;

    Vector3 velocity;
    bool isGrounded;
    MouseLook mouseCtrl;

    private void Start()
    {
        mouseCtrl = Camera.main.GetComponent<MouseLook>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!mouseCtrl.freeze)
        {
            float movespeed = speed;

            isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            if (Input.GetButton("Sprint") && CanSprint)
            {
                movespeed *= Multiplier;
            }

            controller.Move(move * movespeed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded && CanJump)
            {
                velocity.y = Mathf.Sqrt(JumpHeight * -2f * -gravity);
            }

            velocity.y -= gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }

    }


}
