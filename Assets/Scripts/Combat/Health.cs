using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BAB.Combat
{  
    public class Health : MonoBehaviour
    {
        [SerializeField]
        float hp = 10;
        bool isDead = false;

        public bool IsDead() //Metodi tarkastaa, onko pelaaja kuollut
        {
            return isDead;
        }
        public void TakeDamage(float damage, GameObject damageDealer) //Metodi vahingon ottamiseen. Kirjoitetaan myös consoliin, kuka teki vahingon ja kenelle
        {
            hp = Mathf.Max(hp - damage, 0);
            print(this.gameObject.name + " took " + damage + " damage from the " + damageDealer);
            if (hp == 0)
            {
                PlayerDie();
                IsDead();
                Enemy enemy = transform.GetComponent<Enemy>();
                enemy.Die(damageDealer); //Kun hp on nolla, niin kutsutaan Die()- metodia, joka triggeraa ragdoll-efektin kuollessa
            } return;
        }

        private void PlayerDie() //Metodi, joka triggeraa death animaation
        {
            if (isDead) return; //Jos pelaaja on hengissä, niin palautetaan arvo ja jatketaan
            isDead = true; //Jos pelaaja on kuollut, niin näytetään death animaatio
            GetComponent<Animator>().SetTrigger("Die");             
        }
    }
}
