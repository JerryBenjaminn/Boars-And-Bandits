using BAB.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BAB.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField]
        float chaseDistance = 5f;
        Fight fight;
        GameObject player;
        private void Start()
        {
            fight = GetComponent<Fight>();
            player = GameObject.FindWithTag("Player");
        }
        private void Update()
        {            
            if (DistanceToPlayer() < chaseDistance) 
            {
                GetComponent<Fight>().Attack(player);
            }
            else
            {
                fight.Cancel();
            }
        }

        private float DistanceToPlayer()
        {
            GameObject player = GameObject.FindWithTag("Player");
            return Vector3.Distance(player.transform.position, transform.position);
        }
    }
}
