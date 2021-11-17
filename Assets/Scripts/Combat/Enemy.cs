using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BAB.Combat
{
    public class Enemy : MonoBehaviour
    {
        private void Start()
        {
            setRigidBodyState(true);
            setColliderState(false);
        }
        public void Die()
        {
            Destroy(gameObject, 4f);
            GetComponent<Animator>().enabled = false;
            setRigidBodyState(false);
            setColliderState(true);
            AddForceOnDeath();
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
        void AddForceOnDeath()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);

            foreach(Collider closeObjects in colliders)
            {
                Rigidbody rigidbody = closeObjects.GetComponent<Rigidbody>();
                if(rigidbody != null)
                {
                    rigidbody.AddExplosionForce(2000f, transform.position, 5f);
                }
            }
        }
    }
}
