using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    Rigidbody _rigidbody;
    int HP;
    void Start(){
        HP = 10;
    }

    void Update(){
        if (HP <= 0) Death();
    }

    void Death(){
        SceneManager.LoadScene(1);
    }

    public void GetsHit(){
        HP -= 1;
        Debug.Log(HP); 
    }


    
    

 
}
