using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BAB.Movement;
using BAB.Combat;

namespace BAB.Control
{
    public class PlayerController : MonoBehaviour
    {
        
        void Update()
        {
            if (InteractWithCombat()) return;
            if (InteractWithMovement()) return;       
        }

        private bool InteractWithCombat() //Luodaan metodi, joka tarkastaa voidaanko painettuun objektiin hyökätä. Jos ei, niin voidaan jatkaa kuitenkin liikkumista normaalisti.
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits) //Foreach- silmukka tutkii, tuleeko raycastin- säteen eteen objekti, johon hyökätä
            {
                Enemy target = hit.transform.GetComponent<Enemy>(); 
                if (target == null) continue; //Jos vihollista ei löydetä, niin säde jatkaa eteenpäin

                if (Input.GetMouseButton(0)) 
                {                   
                    GetComponent<Fight>().Attack(target);                   
                }
                return true; 
            }
            return false; 
        }

        private bool InteractWithMovement() // Luodaan metodi, joka tarkastaa voidaanko hiiren painamaan sijaintiin liikkua. Jos voi, niin palautetaan tosi, jos ei, niin ei voida liikkua.
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit); 
            if (hasHit)
            {
                if (Input.GetMouseButton(0)) //Jos säde osuu tiettyyn kohtaan kartalla (painamalla vasenta hiiren painiketta), niin liikutaan siihen. Nappia voidaan myös pitää pohjassa, jolloin pelaaja seuraa hiiren liikettä (Vrt.GetMouseButtonDown)
                {
                    GetComponent<Fight>().Cancel(); //Kutsutaan Cancel-metodia Fight-luokasta. Tämä palauttaa pelaajan aina pelaajan takaisin liikkeeseen, vaikka olisi combatissa (Toivottavasti).                   
                    GetComponent<Move>().StartMoving(hit.point);
                }
                return true; 
            }
            return false; 
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition); 
        }
    }
}
