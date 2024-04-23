using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class AgentContoller : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField]
    GameObject target;

   

    public LayerMask PlayerLayer, GroundLayer;
    float Walkpointrange = 3;

    Vector3 walktarget;

    bool walkpointSet;
    public bool playerOnSight, playerInAttackDistance, PlayerInHit;
    public float sight, attackDistance;
    float attackCoolDown = 1;
    Vector3 attackArea =  new Vector3(1.5f, 0.1f, 0.5f);
   

    void Awake()
    {
       
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
         playerOnSight = Physics.CheckSphere(transform.position, sight, PlayerLayer);
         playerInAttackDistance = Physics.CheckSphere(transform.position, attackDistance, PlayerLayer);
         if (!playerOnSight && !playerInAttackDistance) Walking();
         if (playerOnSight && !playerInAttackDistance) Chasing();
         if (playerOnSight && playerInAttackDistance) Attacking();
        
    }

    private void Walking()
    {
        if(!walkpointSet) SearchWalkTarget();
        if(walkpointSet)
        {
            agent.SetDestination(walktarget);
            
        }
        Vector3 distanceFromTarget = transform.position - walktarget;
        
        if(distanceFromTarget.magnitude < 1f) walkpointSet = false;

    }

    private void SearchWalkTarget()
    {
        float randomZ = Random.Range(-Walkpointrange, Walkpointrange);
        float randomX = Random.Range(-Walkpointrange, Walkpointrange);
        
        walktarget = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        NavMeshHit hit;
        if (NavMesh.SamplePosition(walktarget, out hit, 2f, NavMesh.AllAreas)) 
        {
            walktarget = hit.position;
            walkpointSet = true;
            
        }
        
    }
      private void Chasing()
    {
        walktarget = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        if(walkpointSet) agent.SetDestination(walktarget);
        Vector3 distanceFromTarget = transform.position - walktarget;
        
        if(distanceFromTarget.magnitude < 1f) walkpointSet = false;
        
    }
      private void Attacking()
    {

        attackCoolDown -= Time.deltaTime;
        PlayerInHit = Physics.CheckBox(transform.position, attackArea, Quaternion.identity, PlayerLayer);
        if (attackCoolDown < 0)
        {
            if (PlayerInHit)
            {
                GetComponentInChildren<Animator>().SetTrigger("IsAttackTrigger"); 
               
            
            attackCoolDown = 1;
            }
        }
    }


    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sight);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f), new Vector3(1.5f, 0.1f, 0.5f));
    }
}
