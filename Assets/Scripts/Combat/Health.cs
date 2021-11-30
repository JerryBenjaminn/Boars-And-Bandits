using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BAB.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        float maxHp = 20;
        float currentHp;
        bool isDead = false;
        public HealthBar healthBar;
        
        public bool IsDead() //Metodi tarkastaa, onko pelaaja kuollut
        {
            return isDead;
        }
        public void TakeDamage(float damage, GameObject damageDealer) //Metodi vahingon ottamiseen. Kirjoitetaan myös consoliin, kuka teki vahingon ja kenelle
        {
            maxHp = Mathf.Max(maxHp - damage, 0);
            currentHp = maxHp - damage;
            healthBar.SetHealth(currentHp + 1);
            //print(this.gameObject.name + " took " +  damage + " damage from the " + damageDealer);
            if (maxHp == 0)
            {
                PlayerDie();
                IsDead();
                Enemy enemy = transform.GetComponent<Enemy>();
                enemy.Die(damageDealer); //Kun hp on nolla, niin kutsutaan Die()- metodia, joka triggeraa ragdoll-efektin kuollessa
                if (damageDealer == null) return;
            }
            return;
        }

        private void PlayerDie() //Metodi, joka triggeraa death animaation
        {
            
            if (isDead) return; //Jos pelaaja on hengissä, niin palautetaan arvo ja jatketaan
            isDead = true; //Jos pelaaja on kuollut, niin näytetään death animaatio
            GetComponent<Animator>().SetTrigger("Die");
        }

}   }
