using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BAB.Movement;
using UnityEngine.AI;

namespace BAB.Combat
{
    public class Fight : MonoBehaviour
    {
        [SerializeField]
        float combatRange = 2f;
        Transform target;
 
        private void Update()
        {
            MoveToRange();
        }

        public void Attack(Enemy combatTarget)
        {
            target = combatTarget.transform;
        }

        private void MoveToRange() // Metodi, joka painettaessa objektia (t‰ss‰ tapauksessa vihollista), niin siirryt‰‰n vihollisen luo
        {
            if (target != null) //Tarkistetaan onko vihollinen "olemassa"
            {
                GetComponent<Move>().StartMoving(target.position); //Jos vihollinen on havaittu ja sit‰ painetaan, niin liikutaan vihollisen luo
                float distance = Vector3.Distance(target.position, transform.position); //Luodaan muuttuja distance, joka laskee kahden pisteen v‰lisen et‰isyyden. T‰ss‰ tapauksessa pelaajan ja vihollisen
                print("Distance to the target is: " + distance); //Placeholder metodin testaamiseen
                    if (distance < combatRange) //Jos pelaajan et‰isyys on pienempi kuin combatRange muuttuja, niin pelaaja pys‰htyy. T‰m‰ siksi, ettei haluta pelaajan menev‰n p‰‰llekk‰in vihollisen kanssa combatin alkaessa
                    {
                        GetComponent<Move>().Stop();
                    }               
            }
        }
        public void Cancel()
        {
            target = null;          
        }
    }
}
