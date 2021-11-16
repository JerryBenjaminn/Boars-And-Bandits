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

                if (Input.GetMouseButton(0)) // Jos vihollinen löydetään, niin haetaan fight scriptin Attack()- metodi ja hyökätään kohteen kimppuun
                {
                    GetComponent<Fight>().Attack(target);                   
                }
                return true; //Palautetaan tosi, jos vihollinen löytyy
            }
            return false; //Palautetaan epätosi ja voidaan jatkaa liikkumista normaalisti
        }

        private bool InteractWithMovement() // Luodaan metodi, joka tarkastaa voidaanko hiiren painamaan sijaintiin liikkua. Jos voi, niin palautetaan tosi, jos ei, niin ei voida liikkua.
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit); 
            if (hasHit)
            {
                if (Input.GetMouseButton(0)) //Jos säde osuu tiettyyn kohtaan kartalla (painamalla vasenta hiiren painiketta), niin liikutaan siihen. Nappia voidaan myös pitää pohjassa, jolloin pelaaja seuraa hiiren liikettä (Vrt.GetMouseButtonDown)
                {
                    GetComponent<Move>().MoveTo(hit.point); //point propertilla tarkoitetaan kohtaa missä säde osuu lähimpään collideriin
                }
                return true; //Palautetaan säteen sijainti tosi, jos kohtaan voidaan liikkua
            }
            return false; //Jos säde ei löydä kohdetta (collideria) mihin liikkua, niin pelaaja pysyy paikallaan.
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition); //Palautetaan kursorin sijainti
        }
    }
}
