using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySword : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerHP player;
    GameObject playerob;
    Vector3 knockback;
    void Start()
    {
        player.GetComponent<PlayerHP>();
    }

   
private void OnTriggerEnter(Collider other) {
     if ( other.gameObject.tag == "Player")
       {
        other.gameObject.GetComponent<PlayerHP>().GetsHit();
        // knockback = new Vector3 (transform.position.x - player.transform.position.x, 10, transform.position.z - player.transform.position.z);
        // player.transform.position += knockback;
       }
}
  

  
}
