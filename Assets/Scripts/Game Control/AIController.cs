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
            fight = GetComponent<Fight>(); //Haetaan fight-scripti
            navMeshAgent = GetComponent<NavMeshAgent>(); // Haetaan vihollisen navmesh-komponentti
            player = GameObject.FindWithTag("Player"); //Haetaan pelaaja tagilla
            originalLocation = transform.position;
            
        }
        private void Update()
        {            
            if (DistanceToPlayer() < chaseDistance) 
            {
                GetComponent<Fight>().Attack(player); // Jos pelaaja on aggrorangella, niin vihollinen l‰htee kohti pelaajaa
            }
            else
            {
                navMeshAgent.destination = originalLocation; // Jos pelaaja poistuu aggrorangelta, niin vihollinen palaa takaisin alkuper‰iseen paikkaansa
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
            Gizmos.DrawWireSphere(transform.position, chaseDistance); //Piirret‰‰n vihollisen ymp‰rille ympyr‰, joka visualisoi aggrorangen helpomman editoinnin vuoksi
        }
    }
}
