using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BAB.Control;

namespace BAB.Movement
{
    public class Move : MonoBehaviour
    {
        NavMeshAgent navMeshAgent; //Alustetaan NavMeshAgent-komponentti
        
        private void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>(); //Haetaan NavMeshAgent-komponentti 
        }

        void Update()
        {
            UpdateAnimator();
        }

        public void MoveTo(Vector3 destination)
        {
            GetComponent<NavMeshAgent>().destination = destination;
            navMeshAgent.isStopped = false;
        }
        public void StartMoving(Vector3 destination)
        {
            MoveTo(destination);
        }
        public void Cancel()
        {
            navMeshAgent.isStopped = true;
        }
    
        private void UpdateAnimator() //Metodi animaation liikuttamiseksi pelaajan nopeuteen 
        {
            Vector3 velocity = navMeshAgent.velocity; //Luodaan Vector3-muuttuja velocity ja haetaan NavMeshAgent- komponentin nopeus
            Vector3 localVelocity = transform.InverseTransformDirection(velocity); //Kun velocity on luotu, se t‰ytyy muuttaa locaaliksi InverseTransformDirectionilla.(Kts. https://docs.unity3d.com/ScriptReference/Transform.InverseTransformDirection.html)
            float speed = localVelocity.z; //Luodaan paikallinen muuttuja luettavuuden parantamiseksi
            GetComponent<Animator>().SetFloat("Velocity", speed); //L‰hetet‰‰n blendtreelle arvo, jonka mukaan animaatiota vaihdetaan
        }
    }
}
