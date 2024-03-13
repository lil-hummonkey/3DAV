using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    

    Rigidbody _rigidbody;
    
    float velocityY = 0;

    void Start()
    {
        
    }

    void Update()
    {
    Vector3 movement = new(0,0,0);
    velocityY += Physics.gravity.y * Time.deltaTime;
    movement.y = velocityY;
       
    }

    private void OnEnable() {
        
    }

    private void OnDisable() {
        
    }

    
    

 
}
