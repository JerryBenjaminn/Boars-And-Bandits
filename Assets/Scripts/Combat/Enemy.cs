using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BAB.Combat
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        float forceOnDeath = 500f;
        [SerializeField]
        Rigidbody hipsRb;
        private void Start()
        {
            setRigidBodyState(true);
            setColliderState(false);
        }
        public void Die(GameObject damageDealer)
        {
                Destroy(gameObject, 4f); // Kun vihollinen kuolee, niin se tuhoutuu 4 sekunnin kuluttua
                GetComponent<Animator>().enabled = false;
                setRigidBodyState(false);
                setColliderState(true);
                AddForceOnDeath(damageDealer);
        }

        void setRigidBodyState(bool state)
        {
            Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

            foreach(Rigidbody rigidbody in rigidbodies)
            {
                rigidbody.isKinematic = state;
            }
            GetComponent<Rigidbody>().isKinematic = !state;
        }
        void setColliderState(bool state)
        {
            Collider[] colliders = GetComponentsInChildren<Collider>();

            foreach (Collider collider in colliders)
            {
                collider.enabled = state;
            }
            GetComponent<Collider>().enabled = !state;
        }
        void AddForceOnDeath(GameObject damageDealer) //Lisätään vihollisen kuollessa voimaa, jotta saadaa hauskemman näköinen efekti aikaan
        {
            hipsRb.AddForce(damageDealer.transform.forward * forceOnDeath);

            /*Collider[] colliders = Physics.OverlapSphere(transform.position, 10f);

            foreach(Collider closeObjects in colliders)
            {
                Rigidbody rigidbody = closeObjects.GetComponent<Rigidbody>();
                if(rigidbody != null)
                {
                    rigidbody.AddExplosionForce(2000f, transform.position, 10f);
                }
            }*/
        }
    }
}
