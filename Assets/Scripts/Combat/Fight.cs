using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BAB.Movement;
using UnityEngine.AI;
using BAB.Control;

namespace BAB.Combat
{
    public class Fight : MonoBehaviour, IAction
    {
        [SerializeField]
        float combatRange = 2f;
        Health target;
        [SerializeField]
        float timeBetweenAttacks = 1f;
        float lastAttack = 0f;
        [SerializeField]
        float damage = 1f;

        private void Update()
        {
            lastAttack += Time.deltaTime;
            if (target.IsDead()) return;
            MoveToRange();
        }

        public void Attack(GameObject combatTarget)
        {
            GetComponent<ActionQueue>().StartAction(this);
            target = combatTarget.GetComponent<Health>();
        }

        private void MoveToRange() // Metodi, joka painettaessa objektia (t�ss� tapauksessa vihollista), niin siirryt��n vihollisen luo
        {
            if (target != null) //Tarkistetaan onko vihollinen "olemassa"
            {
                GetComponent<Move>().StartMoving(target.transform.position); //Jos vihollinen on havaittu ja sit� painetaan, niin liikutaan vihollisen luo
                float distance = Vector3.Distance(transform.position, target.transform.position); //Luodaan muuttuja distance, joka laskee kahden pisteen v�lisen et�isyyden. T�ss� tapauksessa pelaajan ja vihollisen
                    if (distance < combatRange) //Jos pelaajan et�isyys on pienempi kuin combatRange muuttuja, niin pelaaja pys�htyy. T�m� siksi, ettei haluta pelaajan menev�n p��llekk�in vihollisen kanssa combatin alkaessa
                    {
                        GetComponent<Move>().Cancel();
                        AttackAnimation();
                    }
            }
        }

        private void AttackAnimation()
        {
            transform.LookAt(target.transform); //Kun pelaaja hy�kk��, niin se katsoo aina vihollista p�in
            if(lastAttack > timeBetweenAttacks)
            {
                GetComponent<Animator>().ResetTrigger("Attack");
                GetComponent<Animator>().SetTrigger("Attack"); //Kun ly�d��n, niin t�m� kutsuu Hit() eventti�
                lastAttack = 0f;
            }            
        }
        void Hit() //T�t� kutsutaan animaattorista (hit event)
        {
            if (target == null) return;
            target.TakeDamage(damage, this.gameObject);
        }
        public void Cancel()
        {           
            GetComponent<Animator>().SetTrigger("stopAttack");
            GetComponent<Animator>().ResetTrigger("stopAttack");
            target = null;          
        }

      
    }
}
