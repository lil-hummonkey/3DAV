using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    

    Rigidbody _rigidbody;
    
    int HP;

    void Start()
    {
        HP = 10;
    }

    void Update()
    {
        
       
    }

    private void GetsHit()
    {
        HP -= 1;
    }


    
    

 
}
