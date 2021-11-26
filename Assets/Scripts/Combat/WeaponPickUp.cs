using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BAB.Combat
{
    public class WeaponPickUp : MonoBehaviour
    {
        [SerializeField]
        Weapon weapon = null;
        Animator animator;

        private void Start()
        {

        }
        public void OnTriggerEnter(Collider player)
        {
            if (player.tag == "Player")
            {
                player.GetComponent<Fight>().EquipWeapon(weapon);
                Destroy(gameObject);
            }
        }
    }

}
