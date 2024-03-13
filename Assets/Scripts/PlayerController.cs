using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 inputVector = Vector2.zero;
    CharacterController characterController;

    [SerializeField]
    float speed = 2;
    [SerializeField]
    float gravityForce = 2;
    [SerializeField]
    float jumpForce = 20;
    
    bool attackPressed = false;
    bool jumpPressed = false;
    float velocityY = 0;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {

        //Gravity
        if(characterController.isGrounded)
        {
            velocityY = -1f;
            if (jumpPressed) 
            {
            velocityY = jumpForce;
            
            }
           
        }
        // Horiz
        Vector3 movement = Camera.main.transform.right * inputVector.x + Camera.main.transform.forward * inputVector.y;

        // Move Anim
        if (movement.x != 0 || movement.z != 0)
        {
            movement.y = 0;
            transform.forward = movement;
            GetComponent<Animator>().SetBool("Walking", true);
        }
        else GetComponent<Animator>().SetBool("Walking", false);

        //Attack Anim
        AttackAnimation();

        // Vert
        velocityY += Physics.gravity.y * gravityForce * Time.deltaTime;

        movement.y = velocityY;

        GetComponent<CharacterController>().Move(movement * Time.deltaTime);
        attackPressed = false;
        jumpPressed = false;
        
    }


    void AttackAnimation()
    {
        if(attackPressed)
        {
            GetComponent<Animator>().SetTrigger("Attacking");
        }
        // else GetComponent<Animator>().SetBool("Attacking", false);
    }
    private void OnMove(InputValue value) => inputVector = value.Get<Vector2>();
    void OnJump(InputValue value) => jumpPressed = true;

    void OnFire(InputValue value) => attackPressed = true;
    
}
