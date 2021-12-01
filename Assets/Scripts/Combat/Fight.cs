using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BAB.Movement;
using UnityEngine.AI;
using BAB.Control;

namespace BAB.Combat
{
    public class Fight : MonoBehaviour
    {    
        Health target;

        [SerializeField]
        float timeBetweenAttacks = 1f;
        float lastAttack = 0f;

        [SerializeField]
        Transform handTransform = null;

        [SerializeField]
        Weapon defaultWeapon = null;
        Weapon currentWeapon = null;

        [SerializeField]
        string defaultWeaponName = "Unarmed";
        
        private void Start()
        {
            Weapon weapon = Resources.Load<Weapon>(defaultWeaponName);
            EquipWeapon(weapon);
        }
        private void Update()
        {
            lastAttack += Time.deltaTime;
            if (target == null) return;
            if (target.IsDead()) return;
            MoveToRange();
        }

        public void EquipWeapon(Weapon weapon)
        {
            if (weapon == null) return;
            currentWeapon = weapon;
            Animator animator = GetComponent<Animator>();
            weapon.Spawn(handTransform, animator);
        }
        public void Attack(GameObject combatTarget)
        {
            target = combatTarget.GetComponent<Health>();
        }

        private void MoveToRange() // Metodi, joka painettaessa objektia (tässä tapauksessa vihollista), niin siirrytään vihollisen luo
        {
            if (target != null) //Tarkistetaan onko vihollinen "olemassa"
            {
                GetComponent<Move>().StartMoving(target.transform.position); //Jos vihollinen on havaittu ja sitä painetaan, niin liikutaan vihollisen luo
                float distance = Vector3.Distance(transform.position, target.transform.position); //Luodaan muuttuja distance, joka laskee kahden pisteen välisen etäisyyden. Tässä tapauksessa pelaajan ja vihollisen
                    if (distance < defaultWeapon.GetRange()) //Jos pelaajan etäisyys on pienempi kuin combatRange muuttuja, niin pelaaja pysähtyy. Tämä siksi, ettei haluta pelaajan menevän päällekkäin vihollisen kanssa combatin alkaessa
                    {
                        GetComponent<Move>().Cancel();
                        AttackAnimation();
                    }
            }
        }

        private void AttackAnimation()
        {
            transform.LookAt(target.transform); //Kun pelaaja hyökkää, niin se katsoo aina vihollista päin
            if(lastAttack > timeBetweenAttacks)
            {
                GetComponent<Animator>().SetTrigger("Attack"); //Kun lyödään, niin tämä kutsuu Hit() eventtiä
                lastAttack = 0f;
            }            
        }
        void Hit() //Tätä kutsutaan animaattorista (hit event)
        {
            if (target == null) return;
            target.TakeDamage(currentWeapon.GetDamage(), gameObject);
        }
        public void Cancel()
        {           
            GetComponent<Animator>().SetTrigger("stopAttack");
            GetComponent<Animator>().ResetTrigger("stopAttack"); 
            target = null;          
        }
     
    }
}
