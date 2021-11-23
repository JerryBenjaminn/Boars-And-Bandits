using BAB.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BAB.Movement;

namespace BAB.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField]
        float chaseDistance = 5f;
        Fight fight;
        GameObject player;
        NavMeshAgent navMeshAgent;
        
        

        Vector3 originalLocation;
        private void Start()
        {
            fight = GetComponent<Fight>();
            navMeshAgent = GetComponent<NavMeshAgent>();
            player = GameObject.FindWithTag("Player");
            originalLocation = transform.position;
            
        }
        private void Update()
        {            
            if (DistanceToPlayer() < chaseDistance) 
            {
                GetComponent<Fight>().Attack(player);
            }
            else
            {
                navMeshAgent.destination = originalLocation;
                fight.Cancel();
            }         
        }

        private float DistanceToPlayer()
        {
            GameObject player = GameObject.FindWithTag("Player");
            return Vector3.Distance(player.transform.position, transform.position);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }
    }
}
