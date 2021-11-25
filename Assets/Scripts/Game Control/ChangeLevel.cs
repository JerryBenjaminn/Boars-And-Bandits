using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BAB.SceneManagement
{
    public class ChangeLevel : MonoBehaviour
    {
        [SerializeField]
        int loadScene = 0; 

        private void OnTriggerEnter(Collider player) //Yksinkertainen metodi eri scenejen vaihtamiseen, kun pelaaja törmää collideriin (change level)
        {
            if(player.tag == "Player") //Haetaan pelaaja tagilla
            {
                SceneManager.LoadScene(loadScene); //Vaihdetaan scene sen indexin mukaan
            }
        }
    }
}
