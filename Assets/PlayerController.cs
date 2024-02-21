using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
 Vector2 inputVector = Vector2.zero;

 [SerializeField]
 float speed = 2;
     void Update()
    {
        Vector3 movement = new(inputVector.x, 0, inputVector.y);
        movement = movement * speed * Time.deltaTime;

        GetComponent<CharacterController>().Move(movement);

        if(movement.magnitude > 0)
        {
            GetComponent<Animator>().SetBool("Walking", true);
        }
        else GetComponent<Animator>().SetBool("Walking", false);

        if(movement != Vector3.zero)
        {
            transform.forward = movement;
        }
    }

    void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
    }
}
