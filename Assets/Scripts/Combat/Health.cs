using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BAB.Combat
{  
    public class Health : MonoBehaviour
    {
        [SerializeField]
        float hp = 10;
        public void TakeDamage(float damage)
        {
            hp = Mathf.Max(hp - damage, 0);
            print(hp);
            if (hp == 0)
            {
                Enemy enemy = transform.GetComponent<Enemy>();
                enemy.Die();
            }
        }
    }
}
