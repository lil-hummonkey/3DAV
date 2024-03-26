using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookContoller : MonoBehaviour
{
    [SerializeField]
    GameObject player;
   
    void Update()
    {
        transform.LookAt(player.transform);
    }
}
