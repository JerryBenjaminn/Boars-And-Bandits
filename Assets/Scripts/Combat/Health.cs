using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BAB.Combat
{  
    public class Health : MonoBehaviour
    {
        [SerializeField]
        float hp = 10;

        
        public void TakeDamage(float damage, GameObject damageDealer)
        {
            hp = Mathf.Max(hp - damage, 0);
            print(this.gameObject.name + " took " + damage + " from the " + damageDealer);
            if (hp == 0)
            {
                Enemy enemy = transform.GetComponent<Enemy>();
                enemy.Die(damageDealer); //Kun hp on nolla, niin kutsutaan Die()- metodia, joka triggeraa ragdoll-efektin kuollessa
       
            }
        }

       
    }
}
